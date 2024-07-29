using System.Collections.Generic;
using Buurmans.Mqtt.Models;

namespace Buurmans.AmbiLight.Core.Models;

public class AmbiLightConfigurationSettingsModel
{
	public int PixelSkipSteps { get; set; }
	public int DelayInMilliseconds { get; set; }
	public List<AmbiLightColorSettingModel> ColorSettingModels { get; set; }
	public MqttConfigurationSettingsModel MqttConfigurationSettingsModel { get; set; }
}