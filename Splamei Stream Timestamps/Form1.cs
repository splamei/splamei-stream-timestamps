using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splamei_Stream_Timestamps
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll")]
        static extern short GetAsyncKeyState(Int32 vKey);

        public Stopwatch stopwatch = new Stopwatch();
        public Stopwatch delayStopwatch = new Stopwatch();

        public int recordKey = 0x70; // F1 key - https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes

        public string verCode = "1000";

        //public long elapsedMilliseconds = 0;
        //public float timeToWait = 0;
        public int timeToWaitTotal = 0;
        public bool delayStart = false;

        public bool forceClose = false;

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
                startBtn.Enabled = false;
                timer1.Start();

                if (delayStart)
                {
                    delayStopwatch.Start();
                }
                else
                {
                    stopwatch.Start();
                    recordTime.Enabled = true;
                }

                keyBindingComboBox.Enabled = false;

                if (delayStopwatch.ElapsedMilliseconds <= 0)
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

            timeToWaitTotal = (int)(delayNum.Value * 1000);
            progressBar.Maximum = timeToWaitTotal;
            progressBar.Style = ProgressBarStyle.Blocks;

            waiting = true;
            paused = false;

            timer1.Start();
            keyBindTimer.Start();

            if (timeToWaitTotal > 0)
            {
                delayStart = true;
                delayStopwatch.Reset();
                delayStopwatch.Start();
            }
            else
            {
                stopwatch.Reset();
                stopwatch.Start();
            }

            pauseBtn.Enabled = true;
            stopBtn.Enabled = true;
            recordTime.Enabled = false;
            startBtn.Enabled = false;

            keyBindingComboBox.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (delayStart)
            {
                statusTxt.Text = "Recording in " + TimeSpan.FromMilliseconds(timeToWaitTotal - delayStopwatch.ElapsedMilliseconds).ToString(@"mm\:ss\.ff");

                if (delayStopwatch.ElapsedMilliseconds >= timeToWaitTotal)
                {
                    delayStart = false;
                    delayStopwatch.Reset();
                    delayStopwatch.Stop();
                    progressBar.Value = 0;

                    statusTxt.Text = "Recording";
                    stopwatch.Reset();
                    stopwatch.Start();

                    return;
                }

                progressBar.Value = (int)(delayStopwatch.ElapsedMilliseconds);

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

            if (displayElapsedTime)
            {
                statusTxt.Text = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds).ToString(@"hh\:mm\:ss\.ff");
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to stop recording? You'll have to clear all timestamps to record again and the timer will be reset.", "Splamei Stream Timestamps", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            timer1.Stop();
            stopwatch.Stop();
            delayStopwatch.Stop();

            keyBindTimer.Stop();
            keyBindingComboBox.Enabled = true;
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
            stopwatch.Stop();
            delayStopwatch.Stop();

            keyBindingComboBox.Enabled = true;

            statusTxt.Text = $"Paused at {TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds).ToString(@"hh\:mm\:ss\.ff")}";
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
            addTimeStamp();
        }

        public void clearStamps()
        {
            timestamps.Clear();
            clearBtn.Enabled = false;

            timeDisplay.Items.Clear();

            recordedTxt.Text = "Recorded 0 times";

            updateTimestamps();
        }

        public void updateTimestamps()
        {
            timeDisplay.Items.Clear();
            foreach (long timestamp in timestamps)
            {
                timeDisplay.Items.Add(TimeSpan.FromMilliseconds(timestamp).ToString(@"hh\:mm\:ss\.ff"));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!forceClose)
            {
                if (MessageBox.Show("Are you sure you want to exit? All timestamps will be lost!", "Splamei Stream Timestamps", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void recordedDisplayTimer_Tick(object sender, EventArgs e)
        {
            displayElapsedTime = true;
            recordedDisplayTimer.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (recordKey == 0)
            {
                return;
            }

            short keyStatus = GetAsyncKeyState(recordKey);

            if ((keyStatus & 1) == 1 && !recordedDisplayTimer.Enabled)
            {
                addTimeStamp();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(keyBindingComboBox.SelectedItem.ToString()))
            {
                return;
            }

            if (keyBindingComboBox.SelectedItem.ToString() == "Num 0")
            {
                recordKey = 0x60;
                return;
            }
            else if (keyBindingComboBox.SelectedItem.ToString() == "Disabled")
            {
                recordKey = 0;
            }

            recordKey = 0x70 + keyBindingComboBox.SelectedIndex;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            keyBindingComboBox.SelectedIndex = 0;
        }

        public void addTimeStamp()
        {
            if (!timer1.Enabled || delayStart || paused || recordedDisplayTimer.Enabled)
            {
                return;
            }

            recordedDisplayTimer.Start();

            timestamps.Add(stopwatch.ElapsedMilliseconds);

            timeDisplay.Items.Add(TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds).ToString(@"hh\:mm\:ss\.ff"));

            statusTxt.Text = "Recorded " + TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds).ToString(@"hh\:mm\:ss\.ff");
            displayElapsedTime = false;
            recordedDisplayTimer.Start();

            recordedTxt.Text = $"Recorded {timestamps.Count} times";
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void starOnGitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Process.Start("https://github.com/splamei/splamei-stream-timestamps")) { }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        public static Task<string> makeWebRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "text/html";
            request.Method = "GET";

            request.Timeout = 2000;

            Task<WebResponse> task = Task.Factory.FromAsync(
                request.BeginGetResponse,
                asyncResult =>
                {
                    try
                    {
                        return request.EndGetResponse(asyncResult);
                    }
                    catch (WebException ex)
                    {
                        if (ex.Response != null)
                        {
                            return ex.Response;
                        }
                        throw;
                    }
                },
                (object)null);

            return task.ContinueWith(t => readStreamFromResponse(t.Result));
        }

        private static string readStreamFromResponse(WebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader sr = new StreamReader(responseStream))
            {
                string strContent = sr.ReadToEnd();
                return strContent;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            var task = makeWebRequest("https://www.veemo.uk/net/stream%20tools/timestamps/ver");

            if (!task.IsFaulted)
            {
                string result = task.Result;

                if (result != verCode)
                {
                    var task2 = makeWebRequest("https://www.veemo.uk/net/stream%20tools/timestamps/patch");
                    string patchResult = task2.Result;

                    using (NewUpdate newUpdate = new NewUpdate(patchResult, this))
                    {
                        newUpdate.ShowDialog();
                    }
                }
            }
            else
            {
                Debug.WriteLine("hello");
            }
        }
    }
}
