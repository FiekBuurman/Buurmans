using Buurmans.AmbiLight.Core.Models;
using Buurmans.Common.Interfaces;

namespace Buurmans.AmbiLight.Form.Interfaces
{
    internal interface ISettingsView : IBaseView
    {
		void LoadSettings(AmbiLightConfigurationSettingsModel ambiLightConfigurationSettingsModel);
	}
}
