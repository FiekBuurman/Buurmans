namespace Buurmans.AmbiLight.Form.Interfaces
{
    public interface IMqttViewModel
	{
		void Init(IMqttView mqttView);
		void ConnectButtonPressed();
		void DisconnectButtonPressed();
        void PublishMessageButtonPressed();
	}
}
