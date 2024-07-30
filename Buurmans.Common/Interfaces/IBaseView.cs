namespace Buurmans.Common.Interfaces
{
    public interface IBaseView
    {
		void ShowView();
		void CloseView();
		void ShowMessage(string message, string title = "");
		void ShowErrorMessage(string message, string title = "");
	}
}
