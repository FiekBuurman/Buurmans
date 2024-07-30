using System;
using System.Drawing;
using Buurmans.Common.Interfaces;

namespace Buurmans.AmbiLight.Form.Interfaces
{
    public interface IMainView : IBaseView
	{
		void UpdateBackGroundColor(Color color);
		void SetBitmap(Bitmap bitmap);
		void WriteException(Exception exception);
		void WriteMessage(string message);
    }
}
