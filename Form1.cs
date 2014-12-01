using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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

        Int64[] getLin(Int64[] seriesTab, Int64 m, Int64 a, Int64 b, TextBox textbox, ProgressBar progressBar)
        {
            progressBar.Maximum = seriesTab.Length;
            progressBar.Value = 1;
            textbox.AppendText(Convert.ToString(seriesTab[0]) + " ");

            for (int i = 1; i < seriesTab.Length; i++)
            {
                seriesTab[i] = (i * Convert.ToInt64(seriesTab[i - 1]) + b) % m;
                textbox.AppendText(Convert.ToString(seriesTab[i])+" ");
                progressBar.Value++;
            }

            return seriesTab;
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
            Int64 a, b, c, d, m;
            int seriesLenght = Convert.ToInt32(textBox1.Text);
            Int64[] seriesTab = new Int64[seriesLenght];
            Random firstBit = new Random();

            int firstbit = firstBit.Next(0, 1000);

            seriesTab[0] = firstbit;
            

            if (radioButton1.Checked == true)
            {
               m = Convert.ToInt64(textBox2.Text);
               a = Convert.ToInt64(textBox3.Text);
               b = Convert.ToInt64(textBox4.Text);


              getLin(seriesTab, m, a, b, textBox7, progressBar1);
            }
            if (radioButton2.Checked == true)
            {
                // getSqr();
            }
            if (radioButton3.Checked == true)
            {
                // getCub();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
        }




    }
}
