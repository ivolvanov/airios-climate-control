
#include <Wire.h>

#define SensorAddr 0x44


int data[6];

void setup()
{
  // Initialise I2C communication as MASTER
  Wire.begin();

  // Initialise serial communication
  Serial.begin(9600);
}

void loop()
{

  // Start I2C Transmission
  Wire.beginTransmission(SensorAddr);
  // Send 16-bit command byte
  Wire.write(0x2C); //0x2C //reset 0x30A2 //0xF32D
  Wire.write(0x06); //0x06
  // Stop I2C transmission
   Wire.endTransmission();
  delay(1000);

  // Request 6 bytes of data
   Wire.requestFrom(SensorAddr, 6);
  

  // Read 6 bytes of data
  // temp msb, temp lsb, temp crc, hum msb, hum lsb, hum crc

  if (Wire.available()  == 6)
  {
    data[0] = Wire.read();
    
    data[1] = Wire.read();
   
    data[2] = Wire.read();
   
    data[3] = Wire.read();
   
    data[4] = Wire.read();
    
    data[5] = Wire.read();
    
  }
  // Convert data
  int Temp = (data[0] * 256) + data[1];
  float TempC = -45.0 + (175.0 * Temp / 65535.0);
  //float fTemp = (cTemp * 1.8) + 32.0;
  float TempF = -49 + (315*Temp/65535.0);
  float humidity = (100.0 * ((data[3] * 256.0) + data[4])) / 65535.0;

  
  Serial.print("Temperature in Celsius :");
  Serial.print(TempC);
  Serial.println(" C");
  Serial.print("Temperature in Fahrenheit :");
  Serial.print(TempF);
  Serial.println(" F");
  Serial.print(" Humidity :");
  Serial.print(humidity);
  Serial.println(" %RH");
  delay(1000);
}