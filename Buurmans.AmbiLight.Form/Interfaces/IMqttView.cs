using System;

namespace Buurmans.AmbiLight.Form.Interfaces
{
    public interface IMqttView : IBaseView
	{
		void WriteException(Exception exception);

        void WriteMessage(string message);
	}
}
