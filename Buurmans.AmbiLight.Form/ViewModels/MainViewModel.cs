using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Buurmans.AmbiLight.Core.Interfaces;
using Buurmans.AmbiLight.Form.Interfaces;
using Buurmans.Common.Extensions;
using Buurmans.Common.Interfaces;

namespace Buurmans.AmbiLight.Form.ViewModels
{
	internal class MainViewModel(
		IColorCalculationService colorCalculationService, 
		IScreenCaptureService screenCaptureService,
		IAmbiLightConfigurationProvider settingsProvider, 
		ISettingsView settingsView, 
		IObserverManager observerManager
		) : IMainViewModel
	{
		private IMainView _mainView;
		private bool _shouldKeepRunning;
		
		public void Init(IMainView mainView)
		{
			_mainView = mainView;
			observerManager.Register<Exception>(_mainView.WriteException);
			observerManager.Register<string>(_mainView.WriteMessage);
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

			var settingsModel = settingsProvider.GetSettings();
			
			Task.Factory.StartNew(() =>
			{
				while (_shouldKeepRunning)
				{
					Color color;
					try
					{
						var screen = screenCaptureService.CaptureScreen();
						color = colorCalculationService.CalculateAverageColor(screen);
						observerManager.NotifyChange($"Captured Color: R:{color.R} G:{color.G} B:{color.B}");
					}
					catch (Exception exception)
					{
						color = Color.Red;
						observerManager.NotifyChange(exception);
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
	}
}