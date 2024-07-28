using System.Drawing;
using System.Windows.Forms;

namespace ScreenAmbiLightToMQTT.Core.Controls
{
    public class ColorCheckBox : CheckBox
    {
        public Color Color { get; }

		public ColorCheckBox(Color color)
		{
			Color = color;
			Init();
		}

		private void Init()
		{
			base.BackColor = Color;
			base.Text = $@"({Color.R}, {Color.G}, {Color.B})";
			Padding = new Padding(5, 0, 0, 0);
			base.TextAlign = ContentAlignment.MiddleCenter;
			Height = 25;
		}
	}
}
