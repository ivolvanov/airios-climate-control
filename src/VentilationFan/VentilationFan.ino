#include <Servo.h>

Servo servo;
int pos = 0;
String inputString = "";
String commandString = "";
bool stringComplete = false;

void setup() {
  Serial.begin(9600);
  servo.attach(9);
}

void loop() {
  serialEvent();
  if (stringComplete)
  {
    getCommand();
    if (commandString == "STAR")
    {
      pos = 0;
      servo.write(pos);
      delay(15);
    }
    else if (commandString == "INCR")
    {
      if (pos < 180)
      {
        pos += 10;
        servo.write(pos);
        Serial.println(pos);
        delay(15);
      }
    }
    else if (commandString == "DECR")
    {
      if (pos > 0)
      {
        pos -= 10;
        servo.write(pos);
        Serial.println(pos);
        delay(15);
      }
    }
    else if (commandString == "STOP")
    {
      pos = 0;
      servo.write(pos);
      delay(15);
    }
    inputString = "";
    commandString = "";
    stringComplete = false;
  }
}

void serialEvent()
{
  while (Serial.available())
  {
    char inChar = (char)Serial.read();
    inputString += inChar;
    if (inChar == '\n')
    {
      stringComplete = true;
    }
  }
}

void getCommand()
{
  if (inputString.length() > 0)
  {
    commandString = inputString.substring(1, 5);
  }
}
