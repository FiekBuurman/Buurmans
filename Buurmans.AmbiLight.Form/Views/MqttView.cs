using System;
using System.Drawing;
using Buurmans.AmbiLight.Form.Interfaces;
using Buurmans.Common.Extensions;

namespace Buurmans.AmbiLight.Form.Views
{
    public partial class MqttView : BaseView, IMqttView
    {
		private readonly IMqttViewModel _mqttViewModel;
		
		public MqttView(IMqttViewModel mqttViewModel)
		{
			_mqttViewModel = mqttViewModel;
			InitializeComponent();
        }

		private void MqttView_Load(object sender, System.EventArgs e) => _mqttViewModel.Init(this);

		private void ConnectButton_Click(object sender, System.EventArgs e) => _mqttViewModel.ConnectButtonPressed();

		private void Disconnectbutton_Click(object sender, System.EventArgs e)
		{
			_mqttViewModel.DisconnectButtonPressed();
		}

        private void PublishMessageButton_Click(object sender, System.EventArgs e) => _mqttViewModel.PublishMessageButtonPressed();

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

		private void OutputRichTextBox_TextChanged(object sender, EventArgs e)
        {
			OutputRichTextBox.SelectionStart = OutputRichTextBox.Text.Length;
			OutputRichTextBox.ScrollToCaret();
        }
    }
}
