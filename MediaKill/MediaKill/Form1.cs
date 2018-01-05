using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Windows;
using System.IO;




namespace MediaKill
{
    public partial class Form1 : Form
    {
        private BackgroundWorker bw = new BackgroundWorker();

        public Form1()
        {
            InitializeComponent();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

           
        }

       
        private void quitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (cancel.Enabled = true)
            {
                labelprogress.Text = "0";
            }
            else
            {
                labelprogress.Text = (e.ProgressPercentage.ToString() + " Minutes");
            }
        }

        private void bArm_Click(object sender, EventArgs e)
        {

           if (bw.IsBusy == false)
            {
              bArm.Enabled = false;
              cancel.Enabled = true;
             int TimetoAdd = Convert.ToInt32(iCountDownDisplay.Value);
             DateTime now = DateTime.Now;
                LabelStopTime.Text = Convert.ToString(now.AddMinutes(TimetoAdd));
                labelprogress.Text = Convert.ToString(iCountDownDisplay.Value) +" Minutes";
            bw.RunWorkerAsync();
               
           }
         }


        public void bw_DoWork(object sender, DoWorkEventArgs e)
        {
                      
            BackgroundWorker worker = sender as BackgroundWorker;
            {
                for (int iCounter = Convert.ToInt32(iCountDownDisplay.Value); iCounter >= 1; iCounter--)
                {

                    if ((worker.CancellationPending == true))
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    if (iCounter > 1)
                    {

                        System.Threading.Thread.Sleep(60000);
                        worker.ReportProgress(iCounter);
                        //worker.ReportProgress((iCounter * 10));
                    }
                    else if (iCounter == 1)
                    {

                        System.Threading.Thread.Sleep(60000);

                        Process[] processes = Process.GetProcessesByName(editapptoclose.Text);

                        foreach (Process process in processes)
                        {
                            process.Kill();


                        }
                    }
                }

            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                cancel.Enabled = false;
           
            }
            else if (!(e.Error == null))
            {
               LabelStopTime.Text = ("Error: " + e.Error.Message);
            }
            else
            {
            LabelStopTime.Text = "Done";
            this.LabelStopTime.Refresh();
            bArm.Enabled = true;
            cancel.Enabled = false;
            labelprogress.Text = ("0");
             }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
          
               if (bw.WorkerSupportsCancellation == true)
               {
                bw.CancelAsync();
                bw.Dispose();
             
                LabelStopTime.Text = "Please wait... Cancelling Job";
                LabelStopTime.Refresh();
                System.Threading.Thread.Sleep(1000); 
                
                cancel.Enabled = false;
                bArm.Enabled = true;
                   LabelStopTime.Text = "Job Cancelled";
                   LabelStopTime.Refresh();
                   labelprogress.Text = ("0");
                   labelprogress.Refresh();
                   
               }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cancel.Enabled = false;
            this.iCountDownDisplay.Value = Properties.Settings.Default.myKillValue; 

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            // C#
            Properties.Settings.Default.myKillValue = this.iCountDownDisplay.Value;

            Properties.Settings.Default.Save();

        }

        
         
    }
}