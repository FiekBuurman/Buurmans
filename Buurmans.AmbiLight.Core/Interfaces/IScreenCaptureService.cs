using System.Drawing;

namespace ScreenAmbiLightToMQTT.Core.Interfaces
{
	public interface IScreenCaptureService
    {
		Bitmap CaptureScreen();
    }
}
