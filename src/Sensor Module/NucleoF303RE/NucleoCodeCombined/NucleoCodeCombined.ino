#include "NucleoCodeCombined.h"

SoftSerial serialco2(RXco2, TXco2, ssco2);
SoftSerial serialESP(RXesp, TXesp, ssesp);
unsigned long long checkSerialESP = 0, checkSensors = 0;
int co2 = 0, voc = 0, oldco2 = 0, oldvoc = 0;
float temperatureValue = 0, humidityValue = 0;
bool once = true;
bool co2Spike = false, vocSpike = false;

void setup()
{
  Serial.begin(9600);
  serialco2.begin(9600);
  serialESP.begin(9600);
  Wire.begin();
  SHT30setup();
  checkSerialESP = millis();
  checkSensors = millis();
  delay(5000);
  co2 = GetCO2();
  GetTempHum(&temperatureValue, &humidityValue);
  voc = GetVOC();
  delay(100);
  serialESP.print("BEGIN");
  delay(200);
}



void loop()
{
  if (co2Spike || vocSpike)
  {
    String protocol = "#";
    protocol += temperatureValue;
    protocol += ";";
    if (co2Spike)
    {
      protocol += "%";
      co2Spike = false;
    }
    protocol += co2;
    protocol += ";";
    protocol += humidityValue;
    protocol += ";";
    if (vocSpike)
    {
      protocol += "%";
      vocSpike = false;
    }
    protocol += voc;
    protocol += ";i";
    protocol += "$";
    Serial.println(protocol);
    serialESP.print(protocol);
    vocSpike = false;
    co2Spike = false;
  }
  //---------------------------------------------------------------------
  if (millis() - checkSensors > cycleCheckSensors)  //Read sensors measurements every 2 seconds.
  {
    //TO DO - MAKE IT DETECT SPIKES!
    co2 = GetCO2();
    GetTempHum(&temperatureValue, &humidityValue);
    voc = GetVOC();
    if (!once)
    {
      if (oldco2 - 80 >= co2 || oldco2 + 80 <= co2)
        co2Spike = true;
      if (oldvoc - 30 >= co2 || oldvoc + 30 <= voc)  
        vocSpike = true;
      oldco2 = co2;
      oldvoc = voc;
    }
    delay(100);
    if (once)
    {
      String protocol = "#";
      protocol += temperatureValue;
      protocol += ";";
      protocol += co2;
      protocol += ";";
      protocol += humidityValue;
      protocol += ";";
      protocol += voc;
      protocol += ";i";
      protocol += "$";
      serialESP.print(protocol);
      Serial.println(protocol);
      once = false;
    }
    checkSensors = millis();
  }
  //---------------------------------------------------------------------
  if (millis() - checkSerialESP > cycleSendInfo) //send info to ESP every 5 mins
  {
    /*
       Protocol:
       start character - #
       separating character - ;
       commands - % for spiked value
       template - 1st: temp 2nd: co2 3rd: humidity 4th IP of ESP, will be added later
       end character - $
       example - #temp_value;%co2_value;hum_value;%voc_value;Ip_value$
    */
    String protocol = "#";
    protocol += temperatureValue;
    protocol += ";";
    protocol += co2;
    protocol += ";";
    protocol += humidityValue;
    protocol += ";";
    protocol += voc;
    protocol += ";i";
    protocol += "$";
    Serial.println(protocol); //      #26.00;1291;42.75;125;i$
    serialESP.print(protocol);
    checkSerialESP = millis();
  }
  //---------------------------------------------------------------------
}

void SHT30setup()
{
  Wire.beginTransmission(SHTaddress);
  // Send 16-bit command byte
  Wire.write(0x23); // 4 mps
  Wire.write(0x22); // Medium repeatability
  Wire.endTransmission();
}

uint16_t GetVOC()
{
  uint8_t VOCData[VOCbytes];
  Wire.requestFrom(VOCaddress, VOCbytes);
  delay(10); // wait for the sensor to return everything
  if (Wire.available())
    Wire.readBytes(VOCData, VOCbytes);
  uint16_t voc = (VOCData[7] << 8) | (VOCData[8]);
  return voc;
}

void GetTempHum(float *temp, float *hum)
{
  uint8_t data[SHTbytes];
  Wire.requestFrom(SHTaddress, SHTbytes);
  delay(10); // wait for the sensor to return everything
  if (Wire.available())
  {
    Wire.readBytes(data, SHTbytes);
  }
  *temp = -45.0 + (175.0 * ((data[0] * 256.0) + data[1]) / 65535.0);
  *hum = (100.0 * ((data[3] * 256.0) + data[4])) / 65535.0;
}

int GetCO2()
{
  uint16_t ppm = 0;
  serialco2.write(0x11); // Start symbol
  serialco2.write(0x01); // Length of frame bytes
  serialco2.write(0x01); // Read measured CO2 (command)
  serialco2.write(0xED); // Checksum
  if (serialco2.available()) // Read incoming bytes
  {
    serialco2.read(); // Module response
    serialco2.read(); // Length of frame bytes
    serialco2.read(); // Performed action (command)
    ppm = (int)serialco2.read() * 256 + (int)serialco2.read(); // Calculate ppm based on fourth and fifth byte
    serialco2.read(); // Reserved
    serialco2.read(); // Reserved
    serialco2.read(); // Checksum
  }
  return ppm;
}
