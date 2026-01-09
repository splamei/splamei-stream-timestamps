using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splamei_Stream_Timestamps
{
    public partial class Form1 : Form
    {
        public long elapsedMilliseconds = 0;
        public float timeToWait = 0;
        public int timeToWaitTotal = 0;

        public bool waiting = false;
        public bool paused = false;
        public bool displayElapsedTime = true;

        public List<long> timestamps = new List<long>();

        public Form1()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (paused)
            {
                paused = false;
                pauseBtn.Enabled = true;
                stopBtn.Enabled = true;
                recordTime.Enabled = true;
                startBtn.Enabled = false;
                timer1.Start();

                if (timeToWait <= 0)
                {
                    progressBar.Style = ProgressBarStyle.Marquee;
                    progressBar.Value = 0;
                    progressBar.Maximum = 1;
                }

                return;
            }

            if (MessageBox.Show("All timestamps you currently have added will be lost and can't be recovered. Do you want to continue?", "Splamei Stream Timestamps", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            clearStamps();

            timeToWaitTotal = (int)(delayNum.Value * 10);
            timeToWait = (float)delayNum.Value;
            progressBar.Maximum = (int)(delayNum.Value * 10);
            progressBar.Style = ProgressBarStyle.Blocks;

            waiting = true;
            paused = false;

            elapsedMilliseconds = 0;
            timer1.Start();

            pauseBtn.Enabled = true;
            stopBtn.Enabled = true;
            recordTime.Enabled = false;
            startBtn.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeToWait > 0)
            {
                timeToWait -= 0.1f;

                statusTxt.Text = "Recording in " + timeToWait.ToString("0.0");

                progressBar.Value = timeToWaitTotal - (int)(timeToWait * 10);

                return;
            }

            if (waiting)
            {
                waiting = false;
                recordTime.Enabled = true;

                progressBar.Style = ProgressBarStyle.Marquee;
                progressBar.Value = 0;
                progressBar.Maximum = 1;
            }

            elapsedMilliseconds += 100;

            if (displayElapsedTime)
            {
                statusTxt.Text = TimeSpan.FromMilliseconds(elapsedMilliseconds).ToString(@"hh\:mm\:ss\.f");
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to stop recording? You'll have to clear all timestamps to record again and the timer will be reset.", "Splamei Stream Timestamps", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            timer1.Stop();
            elapsedMilliseconds = 0;
            statusTxt.Text = "Not recording. Data recorded";

            pauseBtn.Enabled = false;
            stopBtn.Enabled = false;
            recordTime.Enabled = false;
            startBtn.Enabled = true;
            clearBtn.Enabled = true;

            progressBar.Value = 0;
            progressBar.Style = ProgressBarStyle.Blocks;
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            pauseBtn.Enabled = false;
            stopBtn.Enabled = false;
            recordTime.Enabled = false;
            startBtn.Enabled = true;

            progressBar.Value = 0;
            progressBar.Style = ProgressBarStyle.Blocks;

            paused = true;

            timer1.Stop();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all timestamps? This action can't be undone.", "Splamei Stream Timestamps", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            clearStamps();

            statusTxt.Text = "Timestamps cleared.";
        }

        private void recordTime_Click(object sender, EventArgs e)
        {
            recordedDisplayTimer.Start();

            timestamps.Add(elapsedMilliseconds);

            timeDisplay.Items.Add(TimeSpan.FromMilliseconds(elapsedMilliseconds).ToString(@"hh\:mm\:ss\.f"));

            statusTxt.Text = "Recorded " + TimeSpan.FromMilliseconds(elapsedMilliseconds).ToString(@"hh\:mm\:ss\.f");
            displayElapsedTime = false;
            recordedDisplayTimer.Start();
        }

        public void clearStamps()
        {
            timestamps.Clear();
            clearBtn.Enabled = false;

            timeDisplay.Items.Clear();

            updateTimestamps();
        }

        public void updateTimestamps()
        {
            timeDisplay.Items.Clear();
            foreach (long timestamp in timestamps)
            {
                timeDisplay.Items.Add(TimeSpan.FromMilliseconds(timestamp).ToString(@"hh\:mm\:ss\.f"));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit? All timestamps will be lost!", "Splamei Stream Timestamps", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void recordedDisplayTimer_Tick(object sender, EventArgs e)
        {
            displayElapsedTime = true;
            recordedDisplayTimer.Stop();
        }
    }
}
