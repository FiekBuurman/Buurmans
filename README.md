
# Buurmans namespace

The Buurmans namespace is just a collection of various small projects and hopefully more and more small tools in the future. Having some shared resources like Buurmans.Common and Buurmans.Mqtt makes it a bit easyer for us to control it.

The first application is AmbiLight, next idea is to get Gas prices via scrapping a website and post the result over MQTT to homeassistant.


![Ambient Light MQTT Diagram](https://raw.githubusercontent.com/FiekBuurman/Buurmans/main/Buurmans.Common/Resources/ambi-ligt-mqtt.png)
## Ambi light to MQTT

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
 
 - Capture Delay
   
 The amount of miliseconds in between each capture, adviced to set this to atleast 1000.
 - Pixel Step
 
 The amount of pixel in each screencapture, the higher the less precise the avarage color is going to be.


## Authors

- [Fiek](https://github.com/FiekBuurman)
- [Stef](https://github.com/Stef-Buurman)
- [Buurman & Buurman](https://nl.wikipedia.org/wiki/Buurman_en_Buurman)
