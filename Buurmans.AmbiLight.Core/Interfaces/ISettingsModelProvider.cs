using ScreenAmbiLightToMQTT.Core.Models;

namespace ScreenAmbiLightToMQTT.Core.Interfaces;

public interface ISettingsModelProvider
{
	SettingsModel GetSettingsModel();
	void SaveSettings(SettingsModel settingsModel);
}