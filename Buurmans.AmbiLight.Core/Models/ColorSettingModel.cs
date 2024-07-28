using System.Drawing;

namespace ScreenAmbiLightToMQTT.Core.Models;

public class ColorSettingModel
{
	public Color Color { get; set; }

	public bool Allowed { get; set; }
}