using Buurmans.AmbiLight.Core.Models;
using Buurmans.Common.Interfaces;

namespace Buurmans.AmbiLight.Core.Interfaces;

internal interface IAmbiLightConfigurationProvider : IBaseConfigurationProvider<AmbilLightConfigurationSettingsModel>
{
	new AmbilLightConfigurationSettingsModel GetSettings();
}