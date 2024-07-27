using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buurmans.Mqtt.Models
{
    public class MqttPayloadModel
    {
        public MqttPayloadModel(string topic)
        {
            Topic = topic;
        }
        public string Topic { private get; set; }
        public string Payload { get; set; }

        //public int Brightness { get; set; }
        //public Color Color { get; set; }
        //public string ColorMode { get; set; }
        //public object ColorOptions { get; set; }
        //public int ColorTemp { get; set; }
        //public int ColorTempStartup { get; set; }
        //public LevelConfig LevelConfig { get; set; }
        //public int LinkQuality { get; set; }
        //public string PowerOnBehavior { get; set; }
        //public string State { get; set; }
        ////public Update Update { get; set; }
        //public bool UpdateAvailable { get; set; }
    }
}

//public class LevelConfig
//{
//    public string OnLevel { get; set; }
//}

//public class Color
//{
//    public int H { get; set; }
//    public int Hue { get; set; }
//    public double X { get; set; }
//    public double Y { get; set; }
//}

/* Example:
 * {
  "brightness": 254,
  "color": {
    "h": 204,
    "hue": 204,
    "x": 0.58,
    "y": 0.244
  },
  "color_mode": "xy",
  "color_options": null,
  "color_temp": 250,
  "color_temp_startup": 65535,
  "level_config": {"on_level": "previous"
  },
  "linkquality": 167,
  "power_on_behavior": "previous",
  "state": "OFF",
  "update": {
    "installed_version": 268572245,
    "latest_version": 268572245,
    "state": "idle"
  },
  "update_available": false
}
 */