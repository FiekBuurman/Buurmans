using Buurmans.AmbiLight.Core.Models;

namespace Buurmans.AmbiLight.Core.Interfaces;

public interface ISettingsModelProvider
{
	SettingsModel GetSettingsModel();
	void SaveSettings(SettingsModel settingsModel);
}