using System;
using System.Windows.Forms;
using Autofac;
using Buurmans.AmbiLight.Form.Interfaces;
using Buurmans.Common.Extensions;

namespace Buurmans.AmbiLight.Form;

internal static class Program
{
	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main()
	{
		try
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var container = ApplicationSetup.CreateContainer();
			using var scope = container.BeginLifetimeScope();
			var app = scope.Resolve<IMainView>();
			app.ShowView();
		}
		catch (Exception exception)
		{
			MessageBox.Show(exception.FlattenException());
		}
	}
}