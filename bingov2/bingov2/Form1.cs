using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bingov2
{
    public partial class Form1 : Form
    {
        // Form1 [Design], button1 (start), button2 (reset), pictureBox1 (bingobal), picturebox2 (timer), label1 (bingoballabel), label4 (timerlabel).
        public Form1()
        {
            InitializeComponent();
            startScherm();
        }

        Button[] arrayButtonSpeler = new Button[30];
        Button[] arrayButtonComputer = new Button[30];
        Random r = new Random();
        List<int> listBal = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, };
        List<int> listRijB = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, };
        List<int> listRijI = new List<int> { 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, };
        List<int> listRijN = new List<int> { 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, };
        List<int> listRijG = new List<int> { 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, };
        List<int> listRijO = new List<int> { 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, };
        int intTeller = 0;
        int intBingoBal = 0;
        string letter;

        // Plaatjes Ophalen
        private Bitmap[] bingoImages =
        {
            bingov2.Properties.Resources.bingobal1, bingov2.Properties.Resources.bingobal2, bingov2.Properties.Resources.bingobal3, bingov2.Properties.Resources.bingobal4, 
            bingov2.Properties.Resources.bingobal5, bingov2.Properties.Resources.bingobal6, bingov2.Properties.Resources.bingobal7, bingov2.Properties.Resources.timerfoto,
        };

        // Methode voor het start scherm, Haalt de twee bingo kaarten op, en laat twee plaatjes zien.
        public void startScherm()
        {
            kaartSpeler();
            kaartComputer();
            cijferShuffleSpeler();
            cijferShuffleComputer();
            label1.Text = "---";
            pictureBox1.Image = Properties.Resources.bingobal1;
            pictureBox2.Image = Properties.Resources.timerfoto;
        }

        // Methode om de bingo kaart van de Speler te laten zien.
        public void kaartSpeler()
        {
            int j = 0;
            int k = 0;
            int l = 0;
            int m = 0;
            int n = 0;
            for (int i = 0; i < arrayButtonSpeler.Length; i++)
            {
                arrayButtonSpeler[i] = new Button();
                arrayButtonSpeler[i].BackColor = Color.White;
                arrayButtonSpeler[i].Font = new Font("Clarendon BT", 25);
                arrayButtonSpeler[i].TextAlign = ContentAlignment.MiddleCenter;
                arrayButtonSpeler[i].Text = (i + 1).ToString();
                arrayButtonSpeler[i].Tag = (i);
                arrayButtonSpeler[i].Size = new Size(75, 75);
                if (i < 5)
                {
                    arrayButtonSpeler[i].Location = new Point(13 + i * 75, 238);
                }
                else if (i < 10)
                {
                    arrayButtonSpeler[i].Location = new Point(13 + j * 75, 313);
                    j++;
                }
                else if (i < 15)
                {
                    arrayButtonSpeler[i].Location = new Point(13 + k * 75, 388);
                    k++;
                }
                else if (i < 20)
                {
                    arrayButtonSpeler[i].Location = new Point(13 + l * 75, 463);
                    l++;
                }
                else if (i < 25)
                {
                    arrayButtonSpeler[i].Location = new Point(13 + m * 75, 538);
                    m++;
                }
                else
                {
                    arrayButtonSpeler[i].Location = new Point(13 + n * 75, 613);
                    n++;
                }
                if (i == 0)
                {
                    arrayButtonSpeler[i].Enabled = false;
                    arrayButtonSpeler[i].BackColor = Color.Red;
                    arrayButtonSpeler[i].Text = "B";
                }
                if (i == 1)
                {
                    arrayButtonSpeler[i].Enabled = false;
                    arrayButtonSpeler[i].BackColor = Color.DodgerBlue;
                    arrayButtonSpeler[i].Text = "I";
                }
                if (i == 2)
                {
                    arrayButtonSpeler[i].Enabled = false;
                    arrayButtonSpeler[i].BackColor = Color.MediumSpringGreen;
                    arrayButtonSpeler[i].Text = "N";
                }
                if (i == 3)
                {
                    arrayButtonSpeler[i].Enabled = false;
                    arrayButtonSpeler[i].BackColor = Color.Orange;
                    arrayButtonSpeler[i].Text = "G";
                }
                if (i == 4)
                {
                    arrayButtonSpeler[i].Enabled = false;
                    arrayButtonSpeler[i].BackColor = Color.Fuchsia;
                    arrayButtonSpeler[i].Text = "O";
                }
                if (i == 17)
                {
                    arrayButtonSpeler[i].Enabled = false;
                    arrayButtonSpeler[i].BackColor = Color.Cyan;
                    arrayButtonSpeler[i].Font = new Font("Clarendon BT", 12);
                    arrayButtonSpeler[i].Text = "Gratis";
                }
                arrayButtonSpeler[i].Click += arrayButtonklik;
                this.Controls.Add(arrayButtonSpeler[i]);
            }
        }

        // Methode om de bingo kaart van de Computer te laten zien.
        public void kaartComputer()
        {
            int o = 0;
            int p = 0;
            int q = 0;
            int r = 0;
            int s = 0;
            for (int t = 0; t < arrayButtonComputer.Length; t++)
            {
                arrayButtonComputer[t] = new Button();
                arrayButtonComputer[t].BackColor = Color.LightGray;
                arrayButtonComputer[t].Font = new Font("Clarendon BT", 25);
                arrayButtonComputer[t].TextAlign = ContentAlignment.MiddleCenter;
                arrayButtonComputer[t].Text = (t + 1).ToString();
                arrayButtonComputer[t].Tag = (t);
                arrayButtonComputer[t].Size = new Size(75, 75);
                arrayButtonComputer[t].Enabled = false;
                if (t < 5)
                {
                    arrayButtonComputer[t].Location = new Point(413 + t * 75, 238);
                }
                else if (t < 10)
                {
                    arrayButtonComputer[t].Location = new Point(413 + o * 75, 313);
                    o++;
                }
                else if (t < 15)
                {
                    arrayButtonComputer[t].Location = new Point(413 + p * 75, 388);
                    p++;
                }
                else if (t < 20)
                {
                    arrayButtonComputer[t].Location = new Point(413 + q * 75, 463);
                    q++;
                }
                else if (t < 25)
                {
                    arrayButtonComputer[t].Location = new Point(413 + r * 75, 538);
                    r++;
                }
                else
                {
                    arrayButtonComputer[t].Location = new Point(413 + s * 75, 613);
                    s++;
                }
                if (t == 0)
                {
                    arrayButtonComputer[t].BackColor = Color.Red;
                    arrayButtonComputer[t].Text = "B";
                }
                if (t == 1)
                {
                    arrayButtonComputer[t].BackColor = Color.DodgerBlue;
                    arrayButtonComputer[t].Text = "I";
                }
                if (t == 2)
                {
                    arrayButtonComputer[t].BackColor = Color.MediumSpringGreen;
                    arrayButtonComputer[t].Text = "N";
                }
                if (t == 3)
                {
                    arrayButtonComputer[t].BackColor = Color.Orange;
                    arrayButtonComputer[t].Text = "G";
                }
                if (t == 4)
                {
                    arrayButtonComputer[t].BackColor = Color.Fuchsia;
                    arrayButtonComputer[t].Text = "O";
                }
                if (t == 17)
                {
                    arrayButtonComputer[t].BackColor = Color.Cyan;
                    arrayButtonComputer[t].Font = new Font("Clarendon BT", 12);
                    arrayButtonComputer[t].Text = "Gratis";
                }
                this.Controls.Add(arrayButtonComputer[t]);
            }
        }

        // Methode om de cijfers op de kaart the schudden.
        public void cijferShuffleSpeler()
        {
            intTeller = 0;
            for (int i = 5; i < 26; i += 5)
            {
                int intRandomGetal = r.Next(listRijB.Count);
                int intGetal = listRijB[intRandomGetal];
                arrayButtonSpeler[i].Text = intGetal.ToString();
                listRijB.Remove(intGetal);
            }
            for (int i = 6; i < 27; i += 5)
            {
                int intRandomGetal = r.Next(listRijI.Count);
                int intGetal = listRijI[intRandomGetal];
                arrayButtonSpeler[i].Text = intGetal.ToString();
                listRijI.Remove(intGetal);
            }
            for (int i = 7; i < 13; i += 5)
            {
                int intRandomGetal = r.Next(listRijN.Count);
                int intGetal = listRijN[intRandomGetal];
                arrayButtonSpeler[i].Text = intGetal.ToString();
                listRijN.Remove(intGetal);
            }
            for (int i = 22; i < 28; i += 5)
            {
                int intRandomGetal = r.Next(listRijN.Count);
                int intGetal = listRijN[intRandomGetal];
                arrayButtonSpeler[i].Text = intGetal.ToString();
                listRijN.Remove(intGetal);
            }
            for (int i = 8; i < 29; i += 5)
            {
                int intRandomGetal = r.Next(listRijG.Count);
                int intGetal = listRijG[intRandomGetal];
                arrayButtonSpeler[i].Text = intGetal.ToString();
                listRijG.Remove(intGetal);
            }
            for (int i = 9; i < 30; i += 5)
            {
                int intRandomGetal = r.Next(listRijO.Count);
                int intGetal = listRijO[intRandomGetal];
                arrayButtonSpeler[i].Text = intGetal.ToString();
                listRijO.Remove(intGetal);
            }
        }

        // Methode om de cijfers op de kaart the schudden.
        public void cijferShuffleComputer()
        {
            for (int t = 5; t < 26; t += 5)
            {
                int intRandomGetal = r.Next(listRijB.Count);
                int intGetal = listRijB[intRandomGetal];
                arrayButtonComputer[t].Text = intGetal.ToString();
                listRijB.Remove(intGetal);
            }
            for (int t = 6; t < 27; t += 5)
            {
                int intRandomGetal = r.Next(listRijI.Count);
                int intGetal = listRijI[intRandomGetal];
                arrayButtonComputer[t].Text = intGetal.ToString();
                listRijI.Remove(intGetal);
            }
            for (int t = 7; t < 13; t += 5)
            {
                int intRandomGetal = r.Next(listRijN.Count);
                int intGetal = listRijN[intRandomGetal];
                arrayButtonComputer[t].Text = intGetal.ToString();
                listRijN.Remove(intGetal);
            }
            for (int t = 22; t < 28; t += 5)
            {
                int intRandomGetal = r.Next(listRijN.Count);
                int intGetal = listRijN[intRandomGetal];
                arrayButtonComputer[t].Text = intGetal.ToString();
                listRijN.Remove(intGetal);
            }
            for (int t = 8; t < 29; t += 5)
            {
                int intRandomGetal = r.Next(listRijG.Count);
                int intGetal = listRijG[intRandomGetal];
                arrayButtonComputer[t].Text = intGetal.ToString();
                listRijG.Remove(intGetal);
            }
            for (int t = 9; t < 30; t += 5)
            {
                int intRandomGetal = r.Next(listRijO.Count);
                int intGetal = listRijO[intRandomGetal];
                arrayButtonComputer[t].Text = intGetal.ToString();
                listRijO.Remove(intGetal);
            }
        }

        // ( ͡° ͜ʖ ͡°)
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Start spel button, laat de timer lopen, roept methodes aan om de kaarten te schudden en zet de button uit.
        private void button1_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            label4.Text = "3";
            timer1.Start();
        }

        // Reset Button.
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }

        // Timer, Klok word gereset, Nieuwe bal getrokken, en gecontroleerd op bingo voor de computer.
        private void timer1_Tick(object sender, EventArgs e)
        {
            int timer = Convert.ToInt32(label4.Text);
            timer = timer - 1;
            label4.Text = Convert.ToString(timer);
            if (timer == -1)
            {
                label4.Text = "2";
                pictureBox1.Image = Properties.Resources.bingobal1;

                int intRandomGetal = r.Next(listBal.Count);
                intBingoBal = listBal[intRandomGetal];
                label1.Text = intBingoBal.ToString();
                listBal.Remove(intBingoBal);
                controleerComputer();
                controleerBingo(arrayButtonComputer);
            }
            if (timer == 0)
            {
                pictureBox1.Image = Properties.Resources.bingobal4;
            }
            if (timer == 1)
            {
                pictureBox1.Image = Properties.Resources.bingobal3;
            }
            if (timer == 2)
            {
                pictureBox1.Image = Properties.Resources.bingobal2;
            }
        }

        // Als je op een button klikt word de knop groen en word de knop uitgeschakeld. Controleert ook bingo voor de speler.
        private void arrayButtonklik(object sender, EventArgs eventArgs)
        {
            Button button = (Button)sender;
            letter = button.Text;
            if (letter == intBingoBal.ToString())
            {
                button.BackColor = Color.Cyan;
                button.Enabled = false;
            }
            controleerBingo(arrayButtonSpeler);
        }

        // Zodra de bingo bal op de kaart van de Computer staat, word die verranderd.
        private void controleerComputer()
        {
            for (int i = 5; i < arrayButtonComputer.Length; i++)
            {
                if (arrayButtonComputer[i].Text == intBingoBal.ToString())
                {
                    arrayButtonComputer[i].BackColor = Color.Cyan;
                }
            }
        }

        // Hier word er gecontroleerd of er bingo is. (3e Horizontale Rij)
        private void controleerBingo(Button[] arrayButtonSpeler)
        {
            int intTeller = 0;
            for (int i = 15; i < 20; i++)
            {
                if (arrayButtonSpeler[i].BackColor == Color.Cyan)
                {
                    intTeller++;
                }
            }

            if (intTeller == 5)
            {
                timer1.Stop();
                MessageBox.Show("Bingo!");
            }
        }
    }
}
