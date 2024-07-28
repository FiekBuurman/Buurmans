using System.Drawing;

namespace Buurmans.AmbiLight.Core.Interfaces
{
	public interface IColorCalculationService
    {
		Color CalculateAverageColor(Bitmap bitmap);
    }
}
