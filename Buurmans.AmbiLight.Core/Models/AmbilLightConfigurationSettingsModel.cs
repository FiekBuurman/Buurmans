using System.Collections.Generic;

namespace Buurmans.AmbiLight.Core.Models;

public class AmbilLightConfigurationSettingsModel
{
	public int PixelSkipSteps { get; set; }
	public int DelayInMilliseconds { get; set; }
	public List<AmbiLightColorSettingModel> ColorSettingModels { get; set; }
}