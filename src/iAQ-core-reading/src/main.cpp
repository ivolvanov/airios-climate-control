#include <Arduino.h>
#include <Wire.h>
#define VOCaddress 0x5a
#define VOCbytes 9

uint8_t VOCData[VOCbytes];
void requestVOC(uint8_t *VOCData);

void setup()
{
    Serial.begin(9600);
    Wire.begin();
    //edited - notice - sensor needs 5 minute warm-up to work properly and accurately
}

void loop()
{
    requestVOC(VOCData);
    uint16_t co2 = (VOCData[0] << 8) | (VOCData[1]);
    uint16_t voc = (VOCData[7] << 8) | (VOCData[8]);

    String status;
    switch (VOCData[2])
    {
    case 0x00:
        status = "OK";
        break;
    case 0x01:
        status = "BUSY";
        break;
    case 0x80:
        status = "ERROR";
        break;
    default:
        status = "UNKNOWN";
        break;
    }

    Serial.println("The status of the sensor is: " + status + ".");
    Serial.print("The CO2 reading is: ");
    Serial.print(co2); //edited - separated the print of the value on a separate print
    Serial.println(" ppm.");
    Serial.print("The VOC reading is: ");
    Serial.print(voc); //edited - separated the print of the value on a separate print
    Serial.println(" ppb.");
    delay(2000); //edited - added delay for readability, but sensor can handle the requests even without this delay, tested it
}

void requestVOC(uint8_t *VOCData)
{
    Wire.requestFrom(VOCaddress, VOCbytes);
    delay(10); // wait for the sensor to return everything
    if (Wire.available())    
        Wire.readBytes(VOCData, VOCbytes);    
}