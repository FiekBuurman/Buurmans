using System;
using Buurmans.AmbiLight.Core.Interfaces;
using Buurmans.AmbiLight.Form.Interfaces;
using Buurmans.Common.Interfaces;
using Buurmans.Mqtt;

namespace Buurmans.AmbiLight.Form.ViewModels;

public class MqttViewModel(
	IAmbiLightConfigurationProvider configurationProvider, 
	IMqttEngine mqttEngine, 
	IObserverManager observerManager) : IMqttViewModel
{
	private IMqttView _mqttView;

    public void Init(IMqttView mqttView)
	{
		_mqttView = mqttView;

		observerManager.Register<Exception>(_mqttView.WriteException);
		observerManager.Register<string>(_mqttView.WriteMessage);
    }

	public async void ConnectButtonPressed()
	{
		var ambiLightConfigurationSettingsModel = configurationProvider.GetSettings();
		var mqttSettings = ambiLightConfigurationSettingsModel.MqttConfigurationSettingsModel;
		mqttEngine.InitSettings(mqttSettings);	
		await mqttEngine.Connect();
	}

	public async void DisconnectButtonPressed()
	{
		await mqttEngine.Disconnect();
    }

	public void PublishMessageButtonPressed()
	{
		throw new NotImplementedException();
	}
}