using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace NotSleepy1
{
    public partial class NotSleepy : Form
    {
        public NotSleepy()
        {
            InitializeComponent();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartWorker();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopWorker();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopWorker();
            Close();
        }
        private void StartWorker()
        {
            Debug.WriteLine("Starting worker...");
            bkgWorker.RunWorkerAsync();
        }
        private void StopWorker()
        {
            Debug.WriteLine("Stoping worker...");
            bkgWorker.CancelAsync();
        }
        private void bkgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                Debug.WriteLine("Doing Work after a nap....");
                Thread.Sleep(480000);
                ((BackgroundWorker)sender).ReportProgress(1);
            } while (!bkgWorker.CancellationPending);

        }
        
        private void bkgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //hiting numlock twice set it back to what it was
            SendKeys.Send("{NUMLOCK 2}");
        }
    }
}
