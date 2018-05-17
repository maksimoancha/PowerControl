using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PowerControl
{
    public partial class MainForm : Form
    {
        private bool allowExit = false;

        [DllImport("DemoCLibrary.dll")]
        static extern void LockUser();

        [DllImport("DemoCLibrary.dll")]
        static extern void PowerOff();

        [DllImport("DemoCLibrary.dll")]
        static extern void UserLogOut();

        [DllImport("DemoCLibrary.dll")]
        static extern void RestartSystem();

        [DllImport("DemoCLibrary.dll")]
        static extern void SeepSystem();

        [DllImport("DemoCLibrary.dll")]
        static extern void HibernateSystem();





        public MainForm()
        {
            InitializeComponent();

            notifyIcon1.Visible = false;
            this.notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            this.Resize += this.MainForm_Resize;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void button_Click(object sender, EventArgs e)
        {
            var butt = (sender as Button);
            switch (butt.Tag.ToString())
            {
                case "power":
                        PowerOff();
                        break;
                case "restart":
                    RestartSystem();
                    break;
                case "sleep":
                    SeepSystem();
                    break;
                case "hibernate":
                    HibernateSystem();
                    break;
                case "lock":
                    LockUser();
                    break;
                case "logout":
                    UserLogOut();
                    break;
            }
        }

        private void powerOFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PowerOff();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allowExit = true;
            Application.Exit();
        }

        private void sleepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeepSystem();
        }

        private void hybernateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HibernateSystem();
        }

        private void logOFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogOut();
        }

        private void lockUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LockUser();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            if (allowExit)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }

        }
    }
}
