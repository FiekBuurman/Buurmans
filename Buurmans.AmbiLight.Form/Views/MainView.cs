using System;
using System.Drawing;
using Buurmans.AmbiLight.Form.Interfaces;
using Buurmans.Common.Extensions;
using Buurmans.Common.Views;

namespace Buurmans.AmbiLight.Form.Views
{
    public partial class MainView : BaseView, IMainView
    {
		private readonly IMainViewModel _mainViewModel;

		public MainView(IMainViewModel mainViewModel)
		{
			_mainViewModel = mainViewModel;
			InitializeComponent();
		}

        private void MainView_Load(object sender, System.EventArgs e)
        {
			_mainViewModel.Init(this);
        }

		public void UpdateBackGroundColor(Color color)
		{
			this.InvokeIfRequired(() => SetBackgroundColor(color));
		}

		private void SetBackgroundColor(Color color)
		{
			CurrentColorToolStripStatusLabel.Text = color.ToString();
			OutputPanel.BackColor = color;
		}

		private void StartButton_Click(object sender, System.EventArgs e)
		{
			this.DisableUserInput();
			this.StopButton.Enabled = true;
			_mainViewModel.StartButtonPressed();
		}

        private void StopButton_Click(object sender, System.EventArgs e)
        {
			this.EnableUserInput();
			_mainViewModel.StopButtonPressed();
			this.StopButton.Enabled = false;
		}

        private void ShowSettingsButton_Click(object sender, System.EventArgs e)
		{
			_mainViewModel.ShowSettingsButtonPressed();
		}

		public void WriteException(Exception exception)
		{
			this.InvokeIfRequired(() =>
			{
				OutputRichTextBox.AppendText(exception.FlattenException(), Color.Red);
			});
		}

		public void WriteMessage(string message)
		{
            this.InvokeIfRequired(() =>
			{
                OutputRichTextBox.AppendText(message, Color.LightGreen);
			});
		}

        private void OutputRichTextBox_TextChanged(object sender, System.EventArgs e)
        {
            if (OutputRichTextBox.Lines.Length > 99)
                OutputRichTextBox.ResetText();

            OutputRichTextBox.SelectionStart = OutputRichTextBox.Text.Length;
            OutputRichTextBox.ScrollToCaret();
        }
    }
}
