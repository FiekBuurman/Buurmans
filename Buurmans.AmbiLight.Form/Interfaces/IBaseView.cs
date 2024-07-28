namespace Buurmans.AmbiLight.Form.Interfaces
{
    public interface IBaseView
    {
		void ShowView();
		void CloseView();
		void ShowMessage(string message, string title = "");
		void ShowErrorMessage(string message, string title = "");
	}
}
