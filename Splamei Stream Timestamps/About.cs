using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Splamei_Stream_Timestamps
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            label3.Text = "Version " + Application.ProductVersion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Process.Start("https://github.com/splamei/splamei-stream-timestamps")) { }
        }
    }
}
