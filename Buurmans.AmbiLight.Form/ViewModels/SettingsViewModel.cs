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

internal class SettingsViewModel(IAmbiLightConfigurationProvider configurationProvider, IMqttEngine mqttEngine, IObserverManager observerManager) : ISettingsViewModel
{
	private ISettingsView _settingsView;

	public void Init(ISettingsView settingsView)
	{
		_settingsView = settingsView;
	}

	public void SaveSettingsButtonPressed(AmbilLightConfigurationSettingsModel ambilLightConfigurationSettingsModel)
	{
		configurationProvider.SaveSettings(ambilLightConfigurationSettingsModel);
		_settingsView.CloseView();
	}

	public void LoadSettings()
	{
		var settingsModel = configurationProvider.GetSettings();
		_settingsView.LoadSettings(settingsModel);
    }

	public void ResetSettingsButtonPressed()
	{
		var settingsModel = configurationProvider.GetSettings();
		_settingsView.LoadSettings(settingsModel);
    }

	public void TestMqttSettingsButtonPressed(MqttConfigurationSettingsModel mqttConfigurationSettingsModel)
	{
		RegisterObservers();

		mqttEngine.InitSettings(mqttConfigurationSettingsModel);
		mqttEngine.TestSettings(mqttConfigurationSettingsModel);

        UnregisterObservers();

		_settingsView.ShowMessage(_messageBuilder.ToString());
		_messageBuilder.Clear();
    }

	private void UnregisterObservers()
	{
		observerManager.Unregister<string>(AddObserverMessage);
		observerManager.Unregister<Exception>(AddObserverMessage);
	}

	private void RegisterObservers()
	{
		observerManager.Register<string>(AddObserverMessage);
		observerManager.Register<Exception>(AddObserverMessage);
	}

	private void AddObserverMessage(Exception exception) => AddObserverMessage(exception.FlattenException());
	private void AddObserverMessage(string message) => _messageBuilder.Append(message);
	private readonly StringBuilder _messageBuilder = new();
}