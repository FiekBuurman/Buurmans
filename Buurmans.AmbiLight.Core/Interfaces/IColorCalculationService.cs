using System.Drawing;

namespace ScreenAmbiLightToMQTT.Core.Interfaces
{
	public interface IColorCalculationService
    {
		Color CalculateAverageColor(Bitmap bitmap);
    }
}
