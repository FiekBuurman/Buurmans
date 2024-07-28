using Buurmans.AmbiLight.Core.Interfaces;
using Buurmans.AmbiLight.Core.Models;
using Buurmans.AmbiLight.Form.Interfaces;
using Buurmans.Common.Extensions;
using Buurmans.Common.Interfaces;
using Buurmans.Mqtt;
using Buurmans.Mqtt.Models;
using System;
using System.Text;

namespace Buurmans.AmbiLight.Form.ViewModels;

internal class SettingsViewModel(ISettingsModelProvider settingsModelProvider, IMqttEngine mqttEngine, IObserverManager observerManager) : ISettingsViewModel
{
	private ISettingsView _settingsView;

	public void Init(ISettingsView settingsView)
	{
		_settingsView = settingsView;
	}

	public void SaveSettingsButtonPressed(AmbilLightConfigurationSettingsModel ambilLightConfigurationSettingsModel)
	{
		settingsModelProvider.SaveSettings(ambilLightConfigurationSettingsModel);
		_settingsView.CloseView();
	}

	public void LoadSettings()
	{
		var settingsModel = settingsModelProvider.GetSettingsModel();
		_settingsView.LoadSettings(settingsModel);
    }

	public void ResetSettingsButtonPressed()
	{
		var settingsModel = settingsModelProvider.GetSettingsModel();
		_settingsView.LoadSettings(settingsModel);
    }

	public void TestMqttSettingsButtonPressed(MqttConfigurationSettingsModel mqttConfigurationSettingsModel)
	{
		observerManager.Register<string>(AddObserverMessage);
        observerManager.Register<Exception>(AddObserverMessage);

        mqttEngine.InitSettings(mqttConfigurationSettingsModel);
		mqttEngine.TestSettings(mqttConfigurationSettingsModel);

        observerManager.Unregister<string>(AddObserverMessage);
        observerManager.Unregister<Exception>(AddObserverMessage);

		_settingsView.ShowMessage(_messageBuilder.ToString());
		_messageBuilder.Clear();
    }

	private void AddObserverMessage(Exception exception)
	{
		AddObserverMessage(exception.FlattenException());
    }

    private void AddObserverMessage(string message)
	{
        _messageBuilder.Append(message);
    }

	private StringBuilder _messageBuilder = new StringBuilder();
}