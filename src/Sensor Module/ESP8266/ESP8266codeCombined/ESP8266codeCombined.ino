#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <SoftwareSerial.h>

#define SSIDWiFi "TP-Link_5C6C"
#define passwordWiFi "49188714"

const String IP = "192.168.0.105";
const String PORT = "42069";
const String uriServer = "http://" + IP + ":" + PORT;

SoftwareSerial ss(D7, D8);

String POSTrequest(String dataSent);
String GETrequest();

void setup() {
  Serial.begin(9600);
  ss.begin(9600);
  Serial.println("Setup initiated.");
  WiFi.begin(SSIDWiFi, passwordWiFi);
  while (WiFi.status() != WL_CONNECTED)
  {
    Serial.println(".");
    delay(50);
    if (WiFi.status() == WL_CONNECTED)
    {
      Serial.print("ESP module connected at local IP: ");
      Serial.println(WiFi.localIP());
    }
  }
}

void loop() {
  //String localIP = WiFi.localIP().toString();
  //String dataToBeSent = "#%temp_value;co2_value;hum_value;voc_value;" + localIP + "$";
  //Serial.println(POSTrequest(dataToBeSent));
  //Serial.println(GETrequest());
  //delay(5000);
  while(ss.available())
  Serial.print((char)ss.read());
}


String POSTrequest(String dataSent)
{
  if (WiFi.status() == WL_CONNECTED)
  {
    HTTPClient http;

    Serial.println("HTTP client opened at uri: " + uriServer);
    http.begin(uriServer);

    int httpCode = http.POST(dataSent);
    if (httpCode > 0) {
      // HTTP header has been send and Server response header has been handled
      Serial.printf("HTTP response code: %d\n", httpCode);

      if (httpCode == HTTP_CODE_OK)
      {
        String payload = http.getString();
        Serial.println("Response from server: " + payload);
        return payload;
      }
    }
    else
    {
      Serial.printf("Request Failed - %s\n", http.errorToString(httpCode).c_str());
    }

    http.end();
  }
  else
  {
    Serial.println("WiFi not connected, please check connection!");
  }
}

String GETrequest()
{
  if (WiFi.status() == WL_CONNECTED)
  {
    HTTPClient http;

    Serial.println("HTTP client opened at uri: " + uriServer);
    http.begin(uriServer);

    int httpCode = http.GET();
    if (httpCode > 0) {
      // HTTP header has been send and Server response header has been handled
      Serial.printf("HTTP response code: %d\n", httpCode);

      if (httpCode == HTTP_CODE_OK)
      {
        String payload = http.getString();
        Serial.println("Response from server: " + payload);
        return payload;
      }
    }
    else
    {
      Serial.printf("Request Failed - %s\n", http.errorToString(httpCode).c_str());
      return "NotWorking";

    }
    http.end();
  }
  else
  {
    Serial.println("WiFi not connected, please check connection!");
    return "NotWorking";
  }
}
