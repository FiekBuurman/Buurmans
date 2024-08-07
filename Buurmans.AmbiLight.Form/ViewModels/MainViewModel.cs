﻿using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Buurmans.AmbiLight.Core.Interfaces;
using Buurmans.AmbiLight.Core.Models;
using Buurmans.AmbiLight.Form.Interfaces;
using Buurmans.Common.Enums;
using Buurmans.Common.Extensions;
using Buurmans.Common.Interfaces;
using Buurmans.Mqtt;
using Buurmans.Mqtt.Models;

namespace Buurmans.AmbiLight.Form.ViewModels
{
	internal class MainViewModel(
		IColorCalculationService colorCalculationService, 
		IScreenCaptureService screenCaptureService,
		IAmbiLightConfigurationProvider settingsProvider, 
		ISettingsView settingsView, 
		IObserverManager observerManager,
		IMqttEngine mqttEngine,
		ILogger logger
		) : IMainViewModel
	{
		private IMainView _mainView;
		private bool _shouldKeepRunning;
		
		public void Init(IMainView mainView)
		{
			_mainView = mainView;
			
			observerManager.Register<Exception>(_mainView.WriteException);
			observerManager.Register<Exception>(WriteToErrorLog);
			observerManager.Register<string>(_mainView.WriteMessage);
			observerManager.Register<string>(WriteToLog);

			logger.SetLogLevels(LogLevelType.All);
        }

		private void WriteToLog(string message) => logger.Info(message);

		private void WriteToErrorLog(Exception exception) => logger.Error(exception);

		public void StopButtonPressed()
		{
			_shouldKeepRunning = false;
			var color = Color.FromArgb(255, 255, 255);
			_mainView.UpdateBackGroundColor(color);
		}

		public void StartButtonPressed()
		{
			_shouldKeepRunning = true;

			var settingsModel = settingsProvider.GetSettings();
			logger.SetLogLevels(settingsModel.LogLevel);

            var mqttMessage = CreateMqttMessage(settingsModel);
			mqttEngine.InitSettings(settingsModel.MqttConfigurationSettingsModel);

            Task.Factory.StartNew(() =>
			{
				var previousColor = Color.Empty;

				while (_shouldKeepRunning)
				{
					Color currentColor;
					try
                    {
                        var capturedScreen = screenCaptureService.CaptureScreen();
                        currentColor = colorCalculationService.CalculateAverageColor(capturedScreen);
						
                        if (currentColor != previousColor)
						{
							observerManager.NotifyChange($"Captured {currentColor.ToRgbString()}");
							UpdateMqttColorModel(mqttMessage, currentColor);
							mqttEngine.Publish(mqttMessage);
							previousColor = currentColor;
						}
						else 
						{
                            observerManager.NotifyChange($"Skipped {currentColor.ToRgbString()}");
                        }
						
						_mainView.SetBitmap(capturedScreen);
                    }
                    catch (Exception exception)
					{
						currentColor = Color.Red;
						observerManager.NotifyChange(exception);
					}

					_mainView.UpdateBackGroundColor(currentColor);
                    Thread.Sleep(settingsModel.DelayInMilliseconds);
				}
			});
		}

        private static void UpdateMqttColorModel(MqttMessageModel mqttMessage, Color color)
        {
            var lightColorModel = new MqttLightColorModel();
            lightColorModel.UpdateColor(color);

            mqttMessage.MqttPayloadModel = new LightMqttPayloadModel
            {
                State = "ON",
                ColorModel = lightColorModel
            };
        }

        private static MqttMessageModel CreateMqttMessage(AmbiLightConfigurationSettingsModel settingsModel)
        {
            return new MqttMessageModel(settingsModel.MqttConfigurationSettingsModel.Topic)
            {
                MqttPayloadModel = new LightMqttPayloadModel
                {
                    State = "ON",
                    ColorModel = new MqttLightColorModel
                    {
                        Red = 255,
                        Green = 0,
                        Blue = 0
                    }
                }
            };
        }

        public void ShowSettingsButtonPressed()
		{
			settingsView.ShowView();
		}
	}
}