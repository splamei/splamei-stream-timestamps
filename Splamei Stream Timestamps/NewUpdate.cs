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

namespace Splamei_Stream_Timestamps
{
    public partial class NewUpdate : Form
    {
        public Form1 mainform;

        public NewUpdate(string patch, Form1 mainForm)
        {
            InitializeComponent();

            textBox1.Text = patch;
            mainform = mainForm;
        }

        private void NewUpdate_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Process process = Process.Start("https://github.com/splamei/splamei-stream-timestamps")) { }
            mainform.forceClose = true;
            Application.Exit();
        }
    }
}
