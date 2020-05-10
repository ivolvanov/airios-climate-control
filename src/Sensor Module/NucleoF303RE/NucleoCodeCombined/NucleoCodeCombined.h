#ifndef NucleoCodeCombibed.h
#define NucleoCodeCombibed.h
#endif

#include <Wire.h>
#include <SoftSerial.h>

#define VOCaddress 0x5a
#define SHTaddress 0x44
#define VOCbytes 9
#define SHTbytes 6
#define RXco2 D12
#define TXco2 D13
#define RXesp D2
#define TXesp D4
#define ssco2 3
#define ssesp 4
#define cycleSendInfo 300000
#define cycleCheckSensors 2000


uint16_t GetVOC(); //returns voc value

void SHT30setup(); //configures the sensor in continous measurement mode, executed once in setup()

void GetTempHum(float temp, float hum); // &float and &float are passed to get Temperature value and Huimdity value

int GetCO2(); // returns CO2 in parts per million (ppm)
