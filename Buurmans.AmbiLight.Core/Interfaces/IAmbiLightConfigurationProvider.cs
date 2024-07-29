using Buurmans.AmbiLight.Core.Models;
using Buurmans.Common.Interfaces;

namespace Buurmans.AmbiLight.Core.Interfaces;

public interface IAmbiLightConfigurationProvider : IBaseConfigurationProvider<AmbilLightConfigurationSettingsModel>
{
	new AmbilLightConfigurationSettingsModel GetSettings();
}