namespace Splamei_Stream_Timestamps
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.delayNum = new System.Windows.Forms.NumericUpDown();
            this.delayTxt = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.startBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.timeDisplay = new System.Windows.Forms.ListView();
            this.recordTime = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusTxt = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.delayNum)).BeginInit();
            this.SuspendLayout();
            // 
            // delayNum
            // 
            this.delayNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.delayNum.Location = new System.Drawing.Point(165, 11);
            this.delayNum.Name = "delayNum";
            this.delayNum.Size = new System.Drawing.Size(262, 20);
            this.delayNum.TabIndex = 0;
            // 
            // delayTxt
            // 
            this.delayTxt.AutoSize = true;
            this.delayTxt.Location = new System.Drawing.Point(13, 13);
            this.delayTxt.Name = "delayTxt";
            this.delayTxt.Size = new System.Drawing.Size(146, 13);
            this.delayTxt.TabIndex = 1;
            this.delayTxt.Text = "Stream delay offset (seconds)";
            this.toolTip1.SetToolTip(this.delayTxt, "The time it takes for your stream to be displayed to views (It\'s often 8 seconds " +
        "on normal latency)");
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(16, 53);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 2;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Enabled = false;
            this.pauseBtn.Location = new System.Drawing.Point(98, 53);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(75, 23);
            this.pauseBtn.TabIndex = 3;
            this.pauseBtn.Text = "Pause";
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Enabled = false;
            this.stopBtn.Location = new System.Drawing.Point(179, 53);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 4;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Enabled = false;
            this.clearBtn.Location = new System.Drawing.Point(260, 53);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 5;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // timeDisplay
            // 
            this.timeDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeDisplay.HideSelection = false;
            this.timeDisplay.Location = new System.Drawing.Point(12, 102);
            this.timeDisplay.Name = "timeDisplay";
            this.timeDisplay.Size = new System.Drawing.Size(560, 296);
            this.timeDisplay.TabIndex = 6;
            this.timeDisplay.UseCompatibleStateImageBehavior = false;
            this.timeDisplay.View = System.Windows.Forms.View.List;
            // 
            // recordTime
            // 
            this.recordTime.Enabled = false;
            this.recordTime.Location = new System.Drawing.Point(342, 53);
            this.recordTime.Name = "recordTime";
            this.recordTime.Size = new System.Drawing.Size(85, 23);
            this.recordTime.TabIndex = 7;
            this.recordTime.Text = "Record Time";
            this.recordTime.UseVisualStyleBackColor = true;
            this.recordTime.Click += new System.EventHandler(this.recordTime_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(13, 416);
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 13);
            this.progressBar.TabIndex = 8;
            // 
            // statusTxt
            // 
            this.statusTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusTxt.AutoSize = true;
            this.statusTxt.Location = new System.Drawing.Point(119, 416);
            this.statusTxt.Name = "statusTxt";
            this.statusTxt.Size = new System.Drawing.Size(115, 13);
            this.statusTxt.TabIndex = 9;
            this.statusTxt.Text = "Not recording. No data";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 441);
            this.Controls.Add(this.statusTxt);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.recordTime);
            this.Controls.Add(this.timeDisplay);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.delayTxt);
            this.Controls.Add(this.delayNum);
            this.MinimumSize = new System.Drawing.Size(457, 320);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splamei Stream Timestamps";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.delayNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown delayNum;
        private System.Windows.Forms.Label delayTxt;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.ListView timeDisplay;
        private System.Windows.Forms.Button recordTime;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label statusTxt;
        private System.Windows.Forms.Timer timer1;
    }
}

