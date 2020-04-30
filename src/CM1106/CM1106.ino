#include <SoftSerial.h>
#include "_HEADER_H.h"

SoftSerial serial(RX, TX, ID);
int measured [MSR_ARRAY_SIZE];
unsigned int average = 0;
unsigned short int limit_ppm = 2000;
int measurement_count = 0;
unsigned short int ppm = 0;

void setup()
{
  serial.begin(9600);
  Serial.begin(9600);
  Serial.println("COMMANDS: current average minmax limit (i.e. limit2000)");
  Serial.println("=======================================================");
  pinMode(WARNING_LED, OUTPUT);
}

unsigned short int maximum_ppm() // Calculate maximum ppm measured
{
  unsigned short int maximum_ppm = 0;
  for (int i = 0; i < measurement_count; i++)
  {
    if (measured[i] >= maximum_ppm)
    {
      maximum_ppm = measured[i];
    }
  }
  return maximum_ppm;
}

unsigned short int minimum_ppm() // Calculate minimum ppm measured
{
  unsigned short int minimum_ppm = 65535;
  for (int i = 0; i < measurement_count; i++)
  {
    if (measured[i] <= minimum_ppm)
    {
      minimum_ppm = measured[i];
    }
  }
  return minimum_ppm;
}

void set_led() // Set warning LED
{
  static bool sent_warning = false; // Remember if warning sent

  if (ppm >= limit_ppm)
  {
    digitalWrite(WARNING_LED, HIGH);
    if (sent_warning == false) // Send warning only once
    {
      Serial.println("[!] WARNING: PPM EXCEEDED LIMIT [!]");
      Serial.println("-     -     -     -     -     -     -     -     -     -" );
      sent_warning = true;
    }
  }
  else
  {
    digitalWrite(WARNING_LED, LOW);
    if (sent_warning == true)
    {
      Serial.println("[!] MESSAGE: PPM VALUE BACK UNDER LIMIT [!]");
      Serial.println("-     -     -     -     -     -     -     -     -     -" );
      sent_warning = false;
    }
  }
}

void serial_input() // Get user input serial monitor
{
  if (Serial.available())
  {
    String incoming_data = Serial.readStringUntil('\n'); // Get string
    if (incoming_data == "current") // Get current ppm measured
    {
      Serial.print("Current parts per million measured: ");
      Serial.println(ppm);
      Serial.println("-     -     -     -     -     -     -     -     -     -" );
    }
    else if (incoming_data == "average") // Calculate average
    {
      Serial.print("Average parts per million: ");
      Serial.println(average);
      Serial.println("-     -     -     -     -     -     -     -     -     -" );
    }
    else if (incoming_data == "minmax") // Get mininum and maximum measured values
    {
      Serial.print("Maximum ppm measured: ");
      Serial.print(maximum_ppm());
      Serial.print(" / minimum ppm measured: ");
      Serial.println(minimum_ppm());
      Serial.println("-     -     -     -     -     -     -     -     -     -" );
    }
    else if (incoming_data.substring(0, 5) == "limit") // Set limit maximum allowed ppm
    {
      if (incoming_data.substring(5, 10).toInt() > 0 && incoming_data.substring(5, 10).toInt() <= 65535)
      {
        limit_ppm = incoming_data.substring(5, 10).toInt();
        Serial.print("Limit set to: ");
        Serial.println(limit_ppm);
        Serial.println("-     -     -     -     -     -     -     -     -     -" );
        set_led();
      }
      else
      {
        Serial.println("Wrong input! Choose an amount between 1 and 65535!");
        Serial.println("-     -     -     -     -     -     -     -     -     -" );
      }
    }
    else // Command not found
    {
      Serial.println("Command not found! Try again!");
      Serial.println("-     -     -     -     -     -     -     -     -     -" );
    }
  }
}

void calc_average() // Calculate average of previous half hour
{
  static int index = 0;
  if (ppm > 0 ) // Update measured data
  {
    measured[index] = ppm;
    index++; // Update index
    if (measurement_count < MSR_ARRAY_SIZE) // Count elements array
    {
      measurement_count++;
    }
  }

  unsigned int sum = 0;
  for (int i = 0; i < measurement_count; i++) // Calculate average
  {
    sum += measured[i];
  }
  average = sum / measurement_count; // Get average

  if (index  == MSR_ARRAY_SIZE) // Set index
  {
    index = 0;
  }
}

int measure_co2() // Measure co2 in parts per million (ppm)
{
  ppm = 0; // Reset ppm

  serial.write(0x11); // Start symbol
  serial.write(0x01); // Length of frame bytes
  serial.write(0x01); // Read measured CO2 (command)
  serial.write(0xED); // Checksum

  if (serial.available()) // Read incoming bytes
  {
    serial.read(); // Module response
    serial.read(); // Length of frame bytes
    serial.read(); // Performed action (command)
    ppm = (int)serial.read() * 256 + (int)serial.read(); // Calculate ppm based on fourth and fifth byte
    serial.read(); // Reserved
    serial.read(); // Reserved
    serial.read(); // Checksum
  }
  set_led();
  calc_average();
  return ppm;
}

void loop()
{
  static unsigned long previous_time = 0;
  unsigned long current_time = millis();

  if (current_time - previous_time > MEASURE_EVENT)
  {
    measure_co2();
    previous_time = current_time;
  }
  serial_input();
}
