
# Buurmans namespace

The Buurmans namespace is just a collection of various small projects and hopefully more and more small tools in the future. Having some shared resources like Buurmans.Common and Buurmans.Mqtt makes it a bit easyer for us to control it.

The first application is AmbiLight, next idea is to get Gas prices via scrapping a website and post the result over MQTT to homeassistant.


![Ambient Light MQTT Diagram](https://raw.githubusercontent.com/FiekBuurman/Buurmans/main/Buurmans.Common/Resources/ambi-light-2-mqtt-logo-small.png)
## What does it do?

- Captures the avarage color of your screen.
- Find one of the allowed Colors.
- Sends a message over MQTT to set the light color.


## Setup

 - Start AmbiLight2Mqtt.exe
 - Open Settings:

![main-form](https://raw.githubusercontent.com/FiekBuurman/Buurmans/main/Buurmans.Common/Resources/main-form-settings.jpg)

All settings are stored in AmbiLightConfigurationSettingsModel.config

![main-form](https://raw.githubusercontent.com/FiekBuurman/Buurmans/main/Buurmans.Common/Resources/settings-form.png)
 
## Configuration Settings

### PixelSkipSteps: `10`
-  The number of pixels to skip during processing. A higher number can reduce processing time but may lower the quality of the output.

### DelayInMilliseconds: `1000`
-  The delay, in milliseconds, between each action or update. This determines the frequency of updates, with a lower number leading to more frequent updates.

### LogLevel:
Each log level determines the verbosity and type of messages that will be recorded in the log files.
- **NoLog:** No logging will be performed.

- **Info:** Logs informational messages, warnings, and errors.

- **Warning:** Logs warnings and errors only.

- **Error:** Logs errors only.

- **All:** Logs informational messages, warnings, and errors (same as `Info`).

### Allowed Colors
- Set the allowed Colors which van be used by the light.

### MQTT settings

  - **BrokerUrl**: `"127.0.0.1"`
    - The URL or IP address of the MQTT broker.
  - **Port**: `1883`
    - The port number used for the MQTT connection.
  - **Topic**: `"MyTopic"`
    -  The topic to which the client subscribes or publishes messages.
  - **ClientId**: `"MyClientId"`
    -  A unique identifier for the MQTT client.
  - **UserName**: `"MyUserName"`
    -  The username for authentication with the MQTT broker.
  - **Password**: `"MyPassword"`
    -  The password for authentication with the MQTT broker.
  - **Timeout**: `60.0`
    -  The timeout period, in seconds, for the MQTT connection.
 
 The amount of pixel in each screencapture, the higher the less precise the avarage color is going to be.


## Authors

- [Fiek](https://github.com/FiekBuurman)
- [Stef](https://github.com/Stef-Buurman)
- [Buurman & Buurman](https://nl.wikipedia.org/wiki/Buurman_en_Buurman)
