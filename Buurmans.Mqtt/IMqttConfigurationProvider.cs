namespace Buurmans.Mqtt
{
	internal interface IMqttConfigurationProvider
	{
		MqttConfigurationSettingsModel GetSettings();
	}
}