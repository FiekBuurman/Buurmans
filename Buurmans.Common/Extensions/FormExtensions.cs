using System;
using System.Drawing;
using System.Windows.Forms;
using Buurmans.Common.Controls;

namespace Buurmans.Common.Extensions
{
	public static class FormExtensions
	{
		private static Form _form;

		public static void DisableUserInput(this Form form)
		{
			_form = form;
			foreach (Control control in _form.Controls)
			{
				ToggleUserInput(control, false);
			}
		}

		public static void EnableUserInput(this Form form)
		{
			_form = form;
			foreach (Control formControl in _form.Controls)
			{
				ToggleUserInput(formControl, true);
			}
		}

		public static void MoveToBottom(this Form form, bool useFullScreenMode)
		{
			var screen = Screen.FromControl(form);
			var screenBounds = useFullScreenMode ? screen.Bounds : screen.WorkingArea;

			form.StartPosition = FormStartPosition.Manual;
			form.Location = new Point(form.Location.X, screenBounds.Height - form.Height);
		}

		public static void InvokeIfRequired(this Form form, Action action)
		{
			if (form.InvokeRequired)
			{
				form.Invoke(action);
			}
			else
			{
				action();
			}
		}

		private static void ToggleUserInput(Control control, bool enabled)
		{
			foreach (Control con in control.Controls)
			{
				ToggleUserInput(con, enabled);
			}

			InvokeIfRequired(() => { control.Enabled = enabled; });

		}

		private static void InvokeIfRequired(Action action)
		{
			if (_form.InvokeRequired)
			{
				_form.Invoke(action);
			}
			else
			{
				action();
			}
		}

		public static void ToggleColorCheckBoxes(this Form form, bool setChecked)
		{
			foreach (Control control in form.Controls)
			{
				SetCheckColorCheckBox(control, setChecked);
			}
		}

		private static void SetCheckColorCheckBox(Control control, bool setChecked)
		{
			if (control is ColorCheckBox colorCheckBox)
			{
				colorCheckBox.Checked = setChecked;
			}
			else
			{
				foreach (Control nestedControl in control.Controls)
				{
					SetCheckColorCheckBox(nestedControl, setChecked);
				}
			}
		}
    }
}
