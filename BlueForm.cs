using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BSOD
{
    public partial class BlueForm : Form
    {
        private Point _mouseLocation;
        private readonly bool _previewMode;
        
        public BlueForm(Rectangle bounds)
        {
            InitializeComponent();

            // Support full screen window
            Bounds = bounds;
            _previewMode = false;
        }

        public BlueForm(IntPtr handle)
        {
            InitializeComponent();

            // Support the preview window
            _previewMode = true;
            SetParent(Handle, handle);
            SetWindowLong(Handle, -16, new IntPtr(GetWindowLong(Handle, -16) | 0x40000000));
            GetClientRect(handle, out var parentRect);
            Size = parentRect.Size;
            Location = new Point(0, 0);
        }

        private void BlueForm_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;
        }

        private void BlueForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (_previewMode) return;
            if (!_mouseLocation.IsEmpty)
                if (Math.Abs(_mouseLocation.X - e.X) > 5 ||
                    Math.Abs(_mouseLocation.Y - e.Y) > 5)
                    Application.Exit();

            // Set mouse location
            _mouseLocation = e.Location;
        }

        private void BlueForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_previewMode)
                Application.Exit();
        }

        private void BlueForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_previewMode)
                Application.Exit();
        }

        #region user32.dll functions

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        #endregion
    }
}
