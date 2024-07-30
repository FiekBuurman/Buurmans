using Buurmans.AmbiLight.Core.Models;
using Buurmans.Common.Interfaces;

namespace Buurmans.AmbiLight.Core.Interfaces;

public interface IAmbiLightConfigurationProvider : IBaseConfigurationProvider<AmbiLightConfigurationSettingsModel>
{
	new AmbiLightConfigurationSettingsModel GetSettings();
}