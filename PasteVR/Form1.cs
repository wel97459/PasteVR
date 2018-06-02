using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasteVR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int SW_RESTORE = 9;

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("Neos");
            BringProcessToFront(localByName[0]);
            System.Threading.Thread.Sleep(1000);
            SendKeys.Send("^V");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("Neos");
            BringProcessToFront(localByName[0]);
            System.Threading.Thread.Sleep(1000);
            SendKeys.Send("^C");
        }

        public static void BringProcessToFront(Process process)
        {
            IntPtr handle = process.MainWindowHandle;
            if (IsIconic(handle))
            {
                ShowWindow(handle, SW_RESTORE);
            }

            SetForegroundWindow(handle);
        }
    }
}
