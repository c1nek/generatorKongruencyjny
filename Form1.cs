using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generatorKongruencyjny
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox5.Enabled = false;
            textBox6.Enabled = false;
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(trackBar1.Value);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = false;
            textBox6.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
            textBox6.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
            textBox6.Enabled = true;
        }

        //ANSI
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text=Convert.ToString(Math.Pow(2,32));
            textBox3.Text = Convert.ToString(int.Parse("41c64e6d", System.Globalization.NumberStyles.HexNumber));
            textBox4.Text = Convert.ToString(123456);
        }

        //MINSTD
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(Math.Pow(2, 31)-1);
            textBox3.Text = Convert.ToString(Math.Pow(7, 5));
            textBox4.Text = Convert.ToString(0);
        }

        //RANDU
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(Math.Pow(2, 31));
            textBox3.Text = Convert.ToString(630360016);
            textBox4.Text = Convert.ToString(0);
        }

        //Fortan
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(Math.Pow(2, 32)-1);
            textBox3.Text = Convert.ToString(int.Parse("10003", System.Globalization.NumberStyles.HexNumber));
            textBox4.Text = Convert.ToString(0);
        }

        //NAG
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(Math.Pow(2, 59));
            textBox3.Text = Convert.ToString(int.Parse("10003", System.Globalization.NumberStyles.HexNumber));
            textBox4.Text = Convert.ToString(0);
        }

        //apple
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(Math.Pow(2, 59));
            textBox3.Text = Convert.ToString(int.Parse("10003", System.Globalization.NumberStyles.HexNumber));
            textBox4.Text = Convert.ToString(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
               // genLin();
            }
            if (radioButton2.Checked == true)
            {
                // genSqr();
            }
            if (radioButton3.Checked == true)
            {
                // genCub();
            }
        }




    }
}
