using System;
using System.Drawing;
using System.Windows.Forms;

namespace BSOD
{
    public partial class BlankForm : Form
    {
        public BlankForm(Rectangle bounds)
        {
            InitializeComponent();

            // Support full screen window
            Bounds = bounds;
        }

        private void BlankForm_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;
        }
    }
}