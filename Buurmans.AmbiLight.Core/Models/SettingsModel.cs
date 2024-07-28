using System.Collections.Generic;

namespace ScreenAmbiLightToMQTT.Core.Models
{
    public class SettingsModel
    {
        public int PixelSkipSteps { get; set; }
		public int DelayInMilliseconds { get; set; }
		public List<ColorSettingModel> ColorSettingModels { get; set; }
		public MqttSettingsModel MqttSettings { get; set; }
	}
}
