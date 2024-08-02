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

        private void MainView_Load(object sender, EventArgs eventArgsventArgs)
        {
			_mainViewModel.Init(this);
        }

		public void UpdateBackGroundColor(Color color)
		{
			this.InvokeIfRequired(() =>
			{
				OutputBitmapPictureBox.BackColor = color;
                //OutputColorPanel.BackColor = color;
				OutputColorLabel.Text = color.ToRgbString();
            });
		}

        public void SetBitmap(Bitmap bitmap)
        {
			this.InvokeIfRequired(() => OutputBitmapPictureBox.Image = bitmap);
        }

		private void StartButton_Click(object sender, EventArgs eventArgs)
		{
			this.DisableUserInput();
			StopButton.Enabled = true;
			_mainViewModel.StartButtonPressed();
		}

        private void StopButton_Click(object sender, EventArgs eventArgs)
        {
			this.EnableUserInput();
			_mainViewModel.StopButtonPressed();
			StopButton.Enabled = false;
		}

        private void ShowSettingsButton_Click(object sender, EventArgs eventArgs)
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

        private void OutputRichTextBox_TextChanged(object sender, EventArgs eventArgs)
        {
            if (OutputRichTextBox.Lines.Length > 99)
                OutputRichTextBox.ResetText();

            OutputRichTextBox.SelectionStart = OutputRichTextBox.Text.Length;
            OutputRichTextBox.ScrollToCaret();
        }
    }
}
