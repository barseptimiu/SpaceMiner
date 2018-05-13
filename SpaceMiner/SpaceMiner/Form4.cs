using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceMiner
{
    public partial class Form4 : Form
    {
        int k;

        public Form4(int level, int scor)
        {
            InitializeComponent();
            if (level == 5)
            {
                button2.Enabled = false;
                button2.Visible = false;
                label1.Text = "You passed the last level with " + Convert.ToString(scor) + " points!";
            }
            else
                label1.Text = "You passed the level with " + Convert.ToString(scor) + " points!";
            k = level;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(k + 1);
            f.ShowDialog();
            this.Close();
        }
    }
}
