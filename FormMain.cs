// ------------------------------------------------------------------------
// 
// This is free and unencumbered software released into the public domain.
// 
// Anyone is free to copy, modify, publish, use, compile, sell, or
// distribute this software, either in source code form or as a compiled
// binary, for any purpose, commercial or non-commercial, and by any
// means.
// 
// In jurisdictions that recognize copyright laws, the author or authors
// of this software dedicate any and all copyright interest in the
// software to the public domain. We make this dedication for the benefit
// of the public at large and to the detriment of our heirs and
// successors. We intend this dedication to be an overt act of
// relinquishment in perpetuity of all present and future rights to this
// software under copyright law.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
// OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// 
// For more information, please refer to <http://unlicense.org/>
// 
// ------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Slideshow
{
    public partial class FormMain : Form
    {
        private FileImage _fileImage;

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(string[] args)
        {
            InitializeComponent();

            DoubleBuffered = true;
            ResizeRedraw = true;

            _fileImage = new FileImage(args[0], LoadImage(args[0]));
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
			StringBuilder stringBuilder = new StringBuilder();
			if (e.Control) stringBuilder.Append("Ctrl+");
			if (e.Shift) stringBuilder.Append("Shift+");
			if (e.Alt) stringBuilder.Append("Alt+");
			switch (e.KeyCode)
			{
				case Keys.Left:
					stringBuilder.Append("Left");
					break;
				case Keys.Right:
					stringBuilder.Append("Right");
					break;
				case Keys.Home:
					stringBuilder.Append("Home");
					break;
				case Keys.End:
					stringBuilder.Append("End");
					break;
				default:
					stringBuilder.Append(e.KeyCode.ToString());
					break;
			}

			string key = stringBuilder.ToString();
			switch (key)
			{
				case "Left":
					{
						string file = _fileImage.File;
						string directory = System.IO.Path.GetDirectoryName(file);
						string[] files = System.IO.Directory.GetFiles(directory, "*.png");
						System.Array.Sort(files, new StringLogicalComparer());
						int index = System.Array.IndexOf(files, file);
						file = files[(index - 1 + files.Length) % files.Length];
						_fileImage = new FileImage(file, LoadImage(file));

						Invalidate();
						break;
					}
				case "Right":
					{
						string file = _fileImage.File;
						string directory = System.IO.Path.GetDirectoryName(file);
						string[] files = System.IO.Directory.GetFiles(directory, "*.png");
						System.Array.Sort(files, new StringLogicalComparer());
						int index = System.Array.IndexOf(files, file);
						file = files[(index + 1) % files.Length];
						_fileImage = new FileImage(file, LoadImage(file));

						Invalidate();
						break;
					}
				case "Escape":
					{
						Application.Exit();
						break;
					}
				case "F5":
					{
						_fileImage = new FileImage(_fileImage.File, LoadImage(_fileImage.File));

						Invalidate();
						break;
					}
				case "F11":
					{
						if (WindowState == FormWindowState.Maximized)
						{
							FormBorderStyle = FormBorderStyle.SizableToolWindow;
							WindowState = FormWindowState.Normal;
						}
						else
						{
							FormBorderStyle = FormBorderStyle.None;
							WindowState = FormWindowState.Maximized;
						}
						break;
					}
			}

            base.OnKeyDown(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            System.Drawing.Image image = _fileImage.Image;

            System.Drawing.Size size = ClientSize;

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            double rx = (double)size.Width / (double)image.Width;
            double ry = (double)size.Height / (double)image.Height;
            double ratio = (rx < ry) ? rx : ry;

            e.Graphics.DrawImage(
                image, 
                (int)((size.Width - (image.Width * ratio)) / 2), 
                (int)((size.Height - (image.Height * ratio)) / 2), 
                (int)(image.Width * ratio), 
                (int)(image.Height * ratio));
        }

        private System.Drawing.Bitmap LoadImage(string path)
        {
            System.IO.Stream stream = System.IO.File.OpenRead(path);
            System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(stream);
            stream.Close();
            return bitmap;
        }

        private class FileImage
        {
            public readonly string File;
            public readonly System.Drawing.Image Image;

            public FileImage(string file, System.Drawing.Image image)
            {
                File = file;
                Image = image;
            }
        }

        [System.Runtime.InteropServices.DllImport("shlwapi.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode, ExactSpelling = true)]
        private static extern int StrCmpLogicalW(string strA, string strB);

        private class StringLogicalComparer : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                return StrCmpLogicalW((string)x, (string)y);
            }
        }

    }
}