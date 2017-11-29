using System;
using System.Windows.Forms;

namespace BSOD
{
    internal static class Program
    {
        /// <summary>
        ///     Entry for the screen saver.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                var argumentOne = args[0].ToLower().Trim();
                string argumentTwo = null;

                // Arguments allow colon specification.  ex. /P:543210
                if (argumentOne.Length > 2)
                {
                    // The first two characters compose first argument
                    argumentOne = argumentOne.Substring(0, 2);
                    // Characters 3+ compose second argument
                    argumentTwo = argumentOne.Substring(3).Trim();
                }
                else if (args.Length > 1)
                {
                    argumentTwo = args[1];
                }
                // Configuration
                switch (argumentOne)
                {
                    case "/c":
                    case "/C":
                        MessageBox.Show(@"There are no options to configure.", @"BSOD Screen Saver",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case "/p":
                    case "/P":
                        if (argumentTwo == null)
                        {
                            MessageBox.Show(@"Preview mode failure.",
                                @"BSOD Screen Saver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        var previewWndHandle = new IntPtr(long.Parse(argumentTwo));
                        Application.Run(new BlueForm(previewWndHandle));
                        break;
                    case "/s":
                    case "/S":
                        bool blueScreen = false;
                        foreach (var screen in Screen.AllScreens)
                        {
                            if (!blueScreen)
                            {
                                blueScreen = true;
                                var screensaver = new BlueForm(screen.Bounds);
                                screensaver.Show();
                            }
                            else
                            {
                                var screensaver = new BlankForm(screen.Bounds);
                                screensaver.Show();
                            }
                        }
                        Application.Run();
                        break;
                    default:
                        MessageBox.Show(@"Invalid command line argument """ + argumentOne +
                                        @"""", @"BSOD Screen Saver",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }
            }
            else
            {
                MessageBox.Show(@"Start with CLI options ""/s"" for full screen.", @"BSOD Screen Saver",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
