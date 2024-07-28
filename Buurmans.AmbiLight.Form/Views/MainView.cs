using System.Drawing;
using Buurmans.AmbiLight.Form.Interfaces;
using Buurmans.Common.Extensions;

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

        private void MqttButton_Click(object sender, System.EventArgs e)
        {
			_mainViewModel.ShowMqttButtonPressed();
        }
    }
}
