using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4
{
    public partial class Form2 : Form
    {
        Form1 fmain;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fmain.MyColor2 = button1.ForeColor = colorDialog1.Color;
            }
            else
            {
                fmain.MyColor2 = button1.ForeColor = Color.Pink;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                fmain.MyColor1 = button2.ForeColor = colorDialog1.Color;
            }
            else
            {
                fmain.MyColor1 = button2.ForeColor = Color.Pink;
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            fmain.MySpeed = trackBar1.Value;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            fmain = (Form1)this.Owner;
            trackBar1.Value = fmain.MySpeed + 1;
            button1.ForeColor = fmain.MyColor2;
            button2.ForeColor = fmain.MyColor1;

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            fmain.from2Closed = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fmain.DirectionMovement = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            fmain.DirectionMovement = true;
        }
    }
}
