namespace Buurmans.AmbiLight.Form.Interfaces
{
    public interface IMainViewModel
	{
		void Init(IMainView mainView);
		void StopButtonPressed();
		void StartButtonPressed();
		void ShowSettingsButtonPressed();
	}
}
