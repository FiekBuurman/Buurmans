using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenAmbiLightToMQTT.Core.Extensions
{
	public static class RichTextBoxExtensions
	{
		public static void AppendText(this RichTextBox box, string text, Color color)
		{
			var newText = $"{box.Text}\n{text.AddTimePrefix()}";
			box.Clear();

            box.SelectionStart = 0;
			box.SelectionLength = 0;
            box.SelectionColor = color;
            
			box.AppendText(newText);
            box.SelectionColor = box.ForeColor;
		}
    }
}
