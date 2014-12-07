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
using System.Numerics;
using System.Threading;
using System.IO;


namespace generatorKongruencyjny
{
    public partial class Form1 : Form
    {
        Stopwatch stoper = new Stopwatch();
        public int lenght=0;
        
       // byte[] passTab;
        public Form1()
        {
            InitializeComponent();
            textBox5.Enabled = false;
            textBox6.Enabled = false;
        }

        byte[] getLin(BigInteger[] seriesTab, BigInteger m, BigInteger a, BigInteger b, TextBox textbox, Label minelo, Label pozostalo, ProgressBar progressBar)
        {
            int temp;
            stoper.Start();
            progressBar.Maximum = seriesTab.Length;
            progressBar.Value = 1;
            textbox.AppendText(Convert.ToString(seriesTab[0] % 2) + " ");
            byte[] keyTab = new byte[seriesTab.Length];

            for (int i = 1; i < seriesTab.Length; i++)
            {
                if (i % 10 == 0)
                {
                    minelo.Text = Convert.ToString(stoper.Elapsed);
                    minelo.Update();
                    pozostalo.Text = Convert.ToString(TimeSpan.FromMilliseconds((seriesTab.Length * stoper.ElapsedMilliseconds / i) - stoper.ElapsedMilliseconds));
                    pozostalo.Update();
                }
                
                seriesTab[i] = (a * (seriesTab[i - 1]) + b) % m;
                if (seriesTab[i] < 0)
                {
                    seriesTab[i] *= -1;
                }
                temp = (int)(seriesTab[i] % 2);
                keyTab[i] = Convert.ToByte(temp);
                textbox.AppendText(Convert.ToString(seriesTab[i] % 2)+" ");
                progressBar.Value++;
                
            }
            stoper.Reset();
            return keyTab;       
        }

        byte[] getSqr(BigInteger[] seriesTab, BigInteger m, BigInteger a, BigInteger b, BigInteger c, TextBox textbox, Label minelo, Label pozostalo, ProgressBar progressBar)
        {
            int temp;
            stoper.Start();
            progressBar.Maximum = seriesTab.Length;
            progressBar.Value = 1;
            textbox.AppendText(Convert.ToString(seriesTab[0] % 2) + " ");
            byte[] keyTab = new byte[seriesTab.Length];

            for (int i = 1; i < seriesTab.Length; i++)
            {
                if (i % 10 == 0)
                {
                    minelo.Text = Convert.ToString(stoper.Elapsed);
                    minelo.Update();
                    pozostalo.Text = Convert.ToString(TimeSpan.FromMilliseconds((seriesTab.Length * stoper.ElapsedMilliseconds / i) - stoper.ElapsedMilliseconds));
                    pozostalo.Update();
                }
                seriesTab[i] = ((a * (seriesTab[i - 1]) * (seriesTab[i - 1])) + (b * (seriesTab[i - 1])) + c )% m;
                temp = (int)(seriesTab[i] % 2);
                keyTab[i] = Convert.ToByte(temp);
                textbox.AppendText(Convert.ToString(seriesTab[i] % 2) + " ");
                progressBar.Value++;
            }
            stoper.Reset();
            return keyTab;
        }

        byte[] getCub(BigInteger[] seriesTab, BigInteger m, BigInteger a, BigInteger b, BigInteger c, BigInteger d, TextBox textbox, Label minelo, Label pozostalo, ProgressBar progressBar)
        {
            int temp;
            stoper.Start();
            progressBar.Maximum = seriesTab.Length;
            progressBar.Value = 1;
            textbox.AppendText(Convert.ToString(seriesTab[0] % 2) + " ");
            byte[] keyTab = new byte[seriesTab.Length];

            for (int i = 1; i < seriesTab.Length; i++)
            {
                if (i % 10 == 0)
                {
                    minelo.Text = Convert.ToString(stoper.Elapsed);
                    minelo.Update();
                    pozostalo.Text = Convert.ToString(TimeSpan.FromMilliseconds((seriesTab.Length * stoper.ElapsedMilliseconds / i) - stoper.ElapsedMilliseconds));
                    pozostalo.Update();
                }
                seriesTab[i] = ((a * (seriesTab[i - 1]) * (a * (seriesTab[i - 1])*(a * (seriesTab[i - 1])))) 
                    + (b * (a * (seriesTab[i - 1])*b * (a * (seriesTab[i - 1])))) 
                    + (c * (a * (seriesTab[i - 1])))
                    + d) % m;
                temp = (int)(seriesTab[i] % 2);
                keyTab[i] = Convert.ToByte(temp);
                textbox.AppendText(Convert.ToString(seriesTab[i] % 2) + " ");
                progressBar.Value++;
            }

            stoper.Reset();
            return keyTab;
        }

       string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
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
            textBox2.Text=Convert.ToString(Math.Pow(2,32)-1);
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
            textBox2.Text = Convert.ToString(Math.Pow(2, 31)-1);
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
            textBox2.Text = Convert.ToString(Math.Pow(2, 49)-1);
            textBox3.Text = Convert.ToString(Math.Pow(13, 13));
            textBox4.Text = Convert.ToString(0);
        }

        //apple
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(Math.Pow(2, 49)-1);
            textBox3.Text = Convert.ToString(int.Parse("48c227", System.Globalization.NumberStyles.HexNumber));
            textBox4.Text = Convert.ToString(0);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            BigInteger a, b, c, d, m;
            int seriesLenght = Convert.ToInt32(textBox1.Text);
            lenght = seriesLenght;
            BigInteger[] seriesTab = new BigInteger[seriesLenght];
            byte[] keyTab = new byte[seriesLenght];
            Random firstBit = new Random();

            if (checkBox1.Checked == false)
            {
                seriesTab[0] = (int)Math.Pow(firstBit.Next(2, 30), firstBit.Next(2, 15));
            }
            else
            {
                seriesTab[0] = Convert.ToInt32(textBox15.Text);
            }
            

            if (radioButton1.Checked == true)
            {
               m = BigInteger.Parse(textBox2.Text);
               a = BigInteger.Parse(textBox3.Text);
               b = BigInteger.Parse(textBox4.Text);


               keyTab = getLin(seriesTab, m, a, b, textBox7, label8, label9, progressBar1);
            }
            if (radioButton2.Checked == true)
            {
                m = BigInteger.Parse(textBox2.Text);
                a = BigInteger.Parse(textBox3.Text);
                b = BigInteger.Parse(textBox4.Text);
                c = BigInteger.Parse(textBox5.Text);


                keyTab = getSqr(seriesTab, m, a, b, c, textBox7, label8, label9, progressBar1);
            }
            if (radioButton3.Checked == true)
            {
                m = BigInteger.Parse(textBox2.Text);
                a = BigInteger.Parse(textBox3.Text);
                b = BigInteger.Parse(textBox4.Text);
                c = BigInteger.Parse(textBox4.Text);
                d = BigInteger.Parse(textBox5.Text);


                keyTab = getCub(seriesTab, m, a, b, c, d, textBox7, label8, label9, progressBar1);
            }
        }

   
        private void zapiszDoPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Generator Kongruencyjny \nMarcin Gluza \n2014 \n\ngumball300@gmail.com", "Autor");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            textBox8.Text = File.ReadAllText(openFileDialog1.FileName);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd. Nie można odczytać wskazenego pliku! \n " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tekst = textBox8.Text;
            textBox9.Text = StringToBinary(textBox8.Text);

        }
        string usunSpacje(string lancuch)
        {
            string bezSpacji;
            bezSpacji = lancuch.Replace(" ", "");
            return bezSpacji;
        }
        public byte[] keyTab;
        private void button5_Click(object sender, EventArgs e)
        {
            string textJawnyBinString = textBox9.Text;
            string keyString = usunSpacje(textBox7.Text);
            
            char[] temp;
            temp = keyString.ToCharArray();
            int[] numKey = new int[temp.Length];
            for (int oooUq = 0; oooUq < temp.Length; oooUq++)
                numKey[oooUq] = (int)temp[oooUq] - 48;

            char[] temp2;
            temp2 = textJawnyBinString.ToCharArray();
            int[] numText = new int[temp2.Length];
            for (int oooU = 0; oooU < temp2.Length; oooU++)
                numText[oooU] = (int)temp2[oooU] - 48;

            int[] _zaszyfr = new int[textJawnyBinString.Length];

            if (keyString.Length < textJawnyBinString.Length)
            {
                MessageBox.Show("Wygenerowano za krótki klucz!");
            }
            else
            {
                for (int i = 0; i < textJawnyBinString.Length; i++)
                {
                    _zaszyfr[i] = (numText[i] ^ numKey[i]);
                    textBox10.AppendText(Convert.ToString(_zaszyfr[i]));
                }
               
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            try
            {

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    {

                        using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                        {

                            sw.Write(textBox7.Text);

                        }

                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Błąd. Nie można zapisać wskazenego pliku! \n " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
         SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            try
            {

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    {

                        using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                        {

                            sw.Write(textBox10.Text);

                        }

                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Błąd. Nie można zapisać wskazenego pliku! \n " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
        Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            textBox11.Text = File.ReadAllText(openFileDialog1.FileName);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd. Nie można odczytać wskazenego pliku! \n " + ex.Message);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            textBox12.Text = File.ReadAllText(openFileDialog1.FileName);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd. Nie można odczytać wskazenego pliku! \n " + ex.Message);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string textZaszyfBinString = textBox11.Text;
            string keyString = usunSpacje(textBox12.Text);

            
            char[] temp;
            temp = keyString.ToCharArray();
            int[] numKey = new int[temp.Length];
            for (int oooUq = 0; oooUq < temp.Length; oooUq++)
                numKey[oooUq] = (int)temp[oooUq] - 48;

            char[] temp2;
            temp2 = textZaszyfBinString.ToCharArray();
            int[] numZaszyf = new int[temp2.Length];
            for (int oooU = 0; oooU < temp2.Length; oooU++)
                numZaszyf[oooU] = (int)temp2[oooU] - 48;


            int[] _odszyfr = new int[textZaszyfBinString.Length];

            if (keyString.Length < textZaszyfBinString.Length)
            {
                MessageBox.Show("Za krótki klucz!");
            }
            else
            {
                for (int i = 0; i < textZaszyfBinString.Length; i++)
                {
                    _odszyfr[i] = (numKey[i] ^ numZaszyf[i]);
                    textBox13.AppendText(Convert.ToString(_odszyfr[i]));
                }

               
            }
        }


        Byte[] GetBytesFromBinaryString(String binary)
        {
            var list = new List<Byte>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                String t = binary.Substring(i, 8);
                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }

        

        private void button10_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var data = GetBytesFromBinaryString(textBox13.Text);
            var text = Encoding.ASCII.GetString(data);
            textBox14.Text = Convert.ToString(text);
        }
        }

       
        
        }




    

