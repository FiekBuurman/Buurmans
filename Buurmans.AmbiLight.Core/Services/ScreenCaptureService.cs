// Ignore Spelling: Ambi

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Buurmans.AmbiLight.Core.Extensions;
using Buurmans.AmbiLight.Core.Interfaces;

namespace Buurmans.AmbiLight.Core.Services
{
	internal class ScreenCaptureService : IScreenCaptureService
	{
		private Bitmap _currentBitmap;

		public Bitmap CaptureScreen()
		{
			try
			{
				EnsureBitmapInitialized();
				CreateGraphics();
				return _currentBitmap;
			}
			catch (Exception exception)
			{
				Debug.Write(exception.FlattenException());
				DisposePreviousBitmap();
				return CaptureScreen();
			}
		}
		
		private void CreateGraphics()
		{
			using var gfx = Graphics.FromImage(_currentBitmap);
			gfx.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, _currentBitmap.Size);
		}
		private void EnsureBitmapInitialized() => _currentBitmap ??= new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

        private void DisposePreviousBitmap()
		{
			_currentBitmap?.Dispose();
			_currentBitmap = null;
		}
	}
}