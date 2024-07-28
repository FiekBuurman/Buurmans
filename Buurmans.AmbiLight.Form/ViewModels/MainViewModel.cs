using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Buurmans.AmbiLight.Core.Interfaces;
using Buurmans.AmbiLight.Form.Interfaces;
using Buurmans.Common.Extensions;

namespace Buurmans.AmbiLight.Form.ViewModels
{
	internal class MainViewModel(
		IColorCalculationService colorCalculationService, 
		IScreenCaptureService screenCaptureService,
		ISettingsModelProvider settingsModelProvider, 
		ISettingsView settingsView, IMqttView mqttView) : IMainViewModel
	{
		private IMainView _mainView;
		private bool _shouldKeepRunning;
		
		public void Init(IMainView mainView)
		{
			_mainView = mainView;
		}

		public void StopButtonPressed()
		{
			_shouldKeepRunning = false;
			var color = Color.FromArgb(255, 255, 255);
			_mainView.UpdateBackGroundColor(color);
		}

		public void StartButtonPressed()
		{
			_shouldKeepRunning = true;

			var settingsModel = settingsModelProvider.GetSettingsModel();
			
			Task.Factory.StartNew(() =>
			{
				while (_shouldKeepRunning)
				{
					Color color;
					try
					{
						var screen = screenCaptureService.CaptureScreen();
						color = colorCalculationService.CalculateAverageColor(screen);
                    }
					catch (Exception exception)
					{
						color = Color.Red;
						Debug.Write(exception.FlattenException());
					}

					_mainView.UpdateBackGroundColor(color);
                    Thread.Sleep(settingsModel.DelayInMilliseconds);
				}
			});
		}

		public void ShowSettingsButtonPressed()
		{
			settingsView.ShowView();
		}

		public void ShowMqttButtonPressed()
		{
			mqttView.ShowView();
		}
	}
}