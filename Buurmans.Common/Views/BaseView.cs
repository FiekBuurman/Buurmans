using System.Windows.Forms;
using Buurmans.Common.Interfaces;

namespace Buurmans.Common.Views;

public class BaseView : System.Windows.Forms.Form, IBaseView
{
	public void ShowView() => ShowDialog();

	public void CloseView() => Close();

	public void ShowMessage(string message, string title = "")
	{
		MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
	}
	public void ShowErrorMessage(string message, string title = "")
	{
		MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
	}
}