using System;
using System.Drawing;

namespace Buurmans.AmbiLight.Form.Interfaces
{
    public interface IMainView : IBaseView
	{
		void UpdateBackGroundColor(Color color);
		void WriteException(Exception exception);
		void WriteMessage(string message);
    }
}
