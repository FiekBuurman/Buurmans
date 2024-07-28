using Buurmans.AmbiLight.Core.Models;

namespace Buurmans.AmbiLight.Form.Interfaces
{
    internal interface ISettingsView : IBaseView
    {
		void LoadSettings(AmbilLightConfigurationSettingsModel ambilLightConfigurationSettingsModel);
	}
}
