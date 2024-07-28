using Buurmans.AmbiLight.Core.Models;

namespace Buurmans.AmbiLight.Core.Interfaces;

public interface ISettingsModelProvider
{
	// TODO Use Buurmans.Common settingsProvider
	AmbilLightConfigurationSettingsModel GetSettingsModel();
	void SaveSettings(AmbilLightConfigurationSettingsModel settingsModel);
}