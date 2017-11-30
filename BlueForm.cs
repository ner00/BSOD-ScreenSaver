using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using BSOD.Properties;

namespace BSOD
{
    public partial class BlueForm : Form
    {
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

        private readonly bool _previewMode;
        private Point _mouseLocation;

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

        private void BlueForm_Activated(object sender, EventArgs e)
        {
            asyncWorker.DoWork +=
                asyncWorker_DoWork;
            if (asyncWorker.IsBusy != true)
                asyncWorker.RunWorkerAsync();
        }

        // This event handler is the asynchronous operation.
        private void asyncWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                // System Boot Sequence
                picture.Image = Resources.blank;
                Thread.Sleep(5000);
                picture.Image = Resources.bios;
                Thread.Sleep(3000);
                picture.Image = Resources.blank;
                Thread.Sleep(3000);

                // Windows Boot Progress Ring
                ProgressRing();
                ProgressRing();
                ProgressRing();

                // Display Lock Screen
                picture.Image = Resources.lockscreen;
                Thread.Sleep(3000);

                // Blue Screen with incremented percentage
                ProgressBlueScreen();
            }
        }

        private void ProgressBlueScreen()
        {
            picture.Image = Resources.bsod;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod03;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod05;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod11;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod12;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod14;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod17;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod25;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod29;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod30;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod31;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod34;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod37;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod42;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod46;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod47;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod48;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod54;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod59;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod60;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod66;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod71;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod74;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod77;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod79;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod86;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod99;
            Thread.Sleep(5000);
            picture.Image = Resources.bsod100;
            Thread.Sleep(10000);
        }

        private void ProgressRing()
        {
            Thread.Sleep(50); picture.Image = Resources.BootScreen0000;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0001;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0002;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0003;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0004;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0005;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0006;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0007;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0008;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0009;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0010;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0011;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0012;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0013;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0014;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0015;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0016;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0017;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0018;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0019;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0020;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0021;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0022;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0023;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0024;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0025;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0026;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0027;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0028;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0029;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0030;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0031;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0032;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0033;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0034;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0035;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0036;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0037;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0038;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0039;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0040;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0041;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0042;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0043;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0044;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0045;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0046;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0047;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0048;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0049;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0050;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0051;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0052;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0053;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0054;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0055;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0056;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0057;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0058;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0059;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0060;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0061;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0062;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0063;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0064;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0065;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0066;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0067;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0068;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0069;
            Thread.Sleep(50); picture.Image = Resources.BootScreen0070;
        }

        private void BlueForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_previewMode)
                Application.Exit();
        }

        private void BlueForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!_previewMode)
                Application.Exit();
        }

        private void BlueForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_previewMode)
                Application.Exit();
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
    }
}