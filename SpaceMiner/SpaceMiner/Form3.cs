using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceMiner
{
    public partial class Form3 : Form
    {
        int[,] a = new int[16, 16];
        PictureBox[,] b = new PictureBox[16, 16];
        string fis;
        int n, lo, co, bile = 0, lp, cp, i, j, deschis = 0, k, l, scor = 0, miscare, teleportare = 0, tl, tc, cade = 0, x;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lo <= 0)
            {
                timer1.Enabled = false;
                this.Close();
                Form5 g = new Form5(x);
                g.ShowDialog();
                teleportare = 0;

            }
            if (teleportare == 1)
            {
                b[lo, co].Image = Image.FromFile(a[lo, co] + ".png");
                b[tl, tc].Image = Image.FromFile("7.png");
                b[lo - 1, co].Image = Image.FromFile("teleportare.jpg");
                lo--;

                if (a[lo, co] != -1 && (a[lo + 1, co] == -1 || a[lo + 1, co] == 2 || a[lo + 1, co] == 8) && a[lo, co] != 2 && a[lo, co] != 8)
                {
                    if (a[lo, co] == 3)
                    {
                        bile++;
                        scor = scor + 100;
                        label1.Text = Convert.ToString(scor) + " points";
                    }
                    teleportare = 0;
                    a[lo, co] = 1;
                    b[lo, co].Image = Image.FromFile("1.png");
                }
            }
            if (cade == 1 && lo + 1 <= n)
            {
                a[lo, co] = 0;//
                b[lo, co].Image = Image.FromFile("0.png");
                b[lo + 1, co].Image = Image.FromFile("1.png");
                lo++;

                if (a[lo, co] == 6)
                {
                    Form4 g = new Form4(x, scor);
                    g.ShowDialog();
                    this.Close();
                }
                if (a[lo, co] == 3)
                {
                    bile++;
                    scor = scor + 100;
                    label1.Text = Convert.ToString(scor) + " points";
                }
                if (a[lo, co] == 4)
                {
                    scor = scor + 50;
                    label1.Text = Convert.ToString(scor) + " points";
                }
                if (a[lo + 1, co] == -1 || a[lo + 1, co] == 2 || lo >= n || a[lo + 1, co] == 8)
                {

                    cade = 0;
                    a[lo, co] = 1;
                    b[lo, co].Image = Image.FromFile("1.png");
                }

            }
    }


        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            i = lo; j = co;
            miscare = 0;
            if (cade == 0 && teleportare == 0)
            {
                if (e.KeyCode == Keys.Left)
                {


                    if (a[i - 1, j - 1] == 2 || a[i - 1, j - 1] == -1 || a[i - 1, j - 1] == 8 || a[i - 1, j - 1] == 10 || a[i - 1, j - 1] == 0)
                        miscare = 1;

                    if (a[i, j - 1] == 0 && miscare == 1)
                    {


                        a[i, j - 1] = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j - 1].Image = Image.FromFile("1.png");
                        co--;
                        if (a[lo + 1, co] == 0 && lo + 1 <= n)
                        {
                            cade = 1;
                            a[lo, co] = 0;
                            b[lo, co].Image = Image.FromFile("0.png");

                            b[lo, co].Image = Image.FromFile("1.png");
                        }

                    }
                    else
                        if (a[i, j - 1] == 2 && miscare == 1)
                    {
                        a[i, j - 1] = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j - 1].Image = Image.FromFile("1.png");
                        co--;
                        if (a[lo + 1, co] == 3 && lo + 1 <= n)
                        {

                            cade = 1;
                            a[lo, co] = 0;
                            b[lo, co].Image = Image.FromFile("0.png");

                            b[lo, co].Image = Image.FromFile("1.png");
                        }
                    }
                    else
                            if (a[i, j - 1] == 9 && deschis == 0 && miscare == 1)
                    {
                        deschis = 1;
                        for (k = 0; k <= n; k++)
                            for (l = 0; l <= n; l++)
                                if (a[k, l] == 10)
                                {
                                    a[k, l] = 11;
                                    b[k, l].Image = Image.FromFile("11.png");
                                }

                        a[i, j - 1] = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j - 1].Image = Image.FromFile("1.png");
                        co--;
                    }
                    else
                                if (a[i, j - 1] == 3 && miscare == 1)
                    {
                        bile++;
                        scor = scor + 100;
                        label1.Text = Convert.ToString(scor) + " points";
                        a[i, j - 1] = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j - 1].Image = Image.FromFile("1.png");
                        co--;
                        if (bile == 3)
                        {
                            a[lp, cp] = 6;
                            b[lp, cp].Image = Image.FromFile("6.png");
                        }
                    }
                    else
                                    if (a[i, j - 1] == 4 && miscare == 1)
                    {
                        scor = scor + 50;
                        label1.Text = Convert.ToString(scor) + " points";
                        a[i, j - 1] = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j - 1].Image = Image.FromFile("1.png");
                        co--;
                    }
                    else
                                        if (a[i, j - 1] == 8 && miscare == 1)
                    {
                        scor = scor + 50;
                        label1.Text = Convert.ToString(scor) + " points";
                        a[i, j - 1] = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j - 1].Image = Image.FromFile("1.png");
                        co--;
                    }
                    else
                                            if (a[i, j - 1] == 7)
                    {
                        teleportare = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j - 1].Image = Image.FromFile("1.png");
                        co--;
                    }
                    else
                                                if (a[i, j - 1] == 5)
                    {
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j - 1].Image = Image.FromFile("1.png");
                        co--;
                    }
                    else
                                                    if (a[i, j - 1] != -1 && a[i - 1, j - 1] == 0)//??
                    {
                        cade = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j - 1].Image = Image.FromFile("1.png");
                        co--;
                    }
                    else
                                                        if (a[i, j - 1] == 6)
                    {
                        Form4 g = new Form4(x, scor);
                        g.ShowDialog();
                        this.Close();
                    }



                }
                if (e.KeyCode == Keys.Right)
                {

                    if (a[i - 1, j + 1] == 2 || a[i - 1, j + 1] == -1 || a[i - 1, j + 1] == 8 || a[i - 1, j + 1] == 10 || a[i - 1, j + 1] == 0)
                        miscare = 1;

                    if (a[i, j + 1] == 0 && miscare == 1)
                    {
                        a[i, j + 1] = 1;

                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");

                        b[i, j + 1].Image = Image.FromFile("1.png");
                        co++;
                        if (a[lo + 1, co] == 11)
                        {
                            cade = 1;
                            a[lo, co] = 0;
                            b[lo, co].Image = Image.FromFile("0.png");

                            b[lo, co].Image = Image.FromFile("1.png");

                        }
                    }
                    else
                        if (a[i, j + 1] == 2 && miscare == 1)
                    {
                        a[i, j + 1] = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j + 1].Image = Image.FromFile("1.png");
                        co++;
                        if (a[lo + 1, co] == 3 && lo + 1 <= n)
                        {

                            cade = 1;
                            a[lo, co] = 0;
                            b[lo, co].Image = Image.FromFile("0.png");

                            b[lo, co].Image = Image.FromFile("1.png");
                        }
                    }
                    else
                            if (a[i, j + 1] == 3 && miscare == 1)
                    {
                        bile++;
                        scor = scor + 100;
                        label1.Text = Convert.ToString(scor) + " points";
                        a[i, j + 1] = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j + 1].Image = Image.FromFile("1.png");
                        co++;
                        if (bile == 3)
                        {
                            a[lp, cp] = 6;
                            b[lp, cp].Image = Image.FromFile("6.png");
                        }
                    }
                    else
                                if (a[i, j + 1] == 4 && miscare == 1)
                    {
                        scor = scor + 50;
                        label1.Text = Convert.ToString(scor) + " points";
                        a[i, j + 1] = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j + 1].Image = Image.FromFile("1.png");
                        co++;
                    }
                    else
                                    if (a[i, j + 1] == 8 && miscare == 1)
                    {
                        scor = scor + 50;
                        label1.Text = Convert.ToString(scor) + " points";
                        a[i, j + 1] = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j + 1].Image = Image.FromFile("1.png");
                        co++;
                    }
                    else
                                        if (a[i, j + 1] == 7)
                    {
                        teleportare = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j + 1].Image = Image.FromFile("1.png");
                        co++;
                    }
                    else
                                            if (a[i, j + 1] == 5)
                    {
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j + 1].Image = Image.FromFile("1.png");
                        co++;
                    }
                    else
                                                if (a[i, j + 1] != -1 && a[i + 1, j + 1] != -1)
                    {
                        co++;
                        cade = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i, j + 1].Image = Image.FromFile("1.png");

                    }
                    else
                                                    if (a[i, j + 1] == 6)
                    {
                        Form4 g = new Form4(x, scor);
                        g.ShowDialog();
                        this.Close();
                    }


                }
                if (e.KeyCode == Keys.Down)
                {
                    if (a[lo + 1, co] == 2)
                    {
                        cade = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i + 1, j].Image = Image.FromFile("1.png");
                    }
                    else
                        if (a[lo + 1, co] == 8)
                    {
                        scor = scor + 50;
                        label1.Text = Convert.ToString(scor) + " puncte";
                        cade = 1;
                        a[lo, co] = 0;
                        b[i, j].Image = Image.FromFile("0.png");
                        b[i + 1, j].Image = Image.FromFile("1.png");
                    }
                }
            }
            if (x == 3 || bile == 3)
            {
                a[lp, cp] = 6;
                b[lp, cp].Image = Image.FromFile("6.png");
            }
            else
            {
                a[lp, cp] = 5;
                b[lp, cp].Image = Image.FromFile("5.png");
            }
        }


        void read(string fisier)
        {
            int i, j;
            string linie;
            string[] s = new string[100];
            StreamReader sr = new StreamReader(fisier);
            linie = sr.ReadLine();
            n = Convert.ToInt32(linie);
            i = 1;
            while ((linie = sr.ReadLine()) != null)
            {
                j = 1;
                s = linie.Split(' ');
                foreach (string c in s)
                {
                    a[i, j] = Convert.ToInt32(c);
                    if (a[i, j] == 1)
                    {
                        lo = i;
                        co = j;
                    }

                    j++;
                }
                i++;
            }

        }

        void generate_lab()
        {
            int i, j;
            for (i = 0; i <= n + 1; i++)
                for (j = 0; j <= n + 1; j++)
                {
                    b[i, j] = new PictureBox();
                    b[i, j].Width = 40;
                    b[i, j].Height = 40;
                    b[i, j].Left = 80 + 40 * j;
                    b[i, j].Top = 40 + 40 * i;
                    this.Controls.Add(b[i, j]);
                    b[i, j].Visible = false;
                }
        }

        void show()
        {
            int i, j;
            for (i = 0; i <= n + 1; i++)
                for (j = 0; j <= n + 1; j++)
                {
                    if (i == 0 || j == 0 || i == n + 1 || j == n + 1)
                    {
                        b[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        b[i, j].Image = Image.FromFile("-1.png");
                    }
                    else
                    if (a[i, j] == -1)
                    {
                        b[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        b[i, j].Image = Image.FromFile("-1.png");
                    }
                    else
                        if (a[i, j] == 1)
                    {
                        lo = i;
                        co = j;
                        b[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        b[i, j].Image = Image.FromFile("1.png");
                    }
                    else
                            if (a[i, j] == 0)
                    {
                        b[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        b[i, j].Image = Image.FromFile("0.png");
                    }
                    else
                                if (a[i, j] == 2)
                    {
                        b[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        b[i, j].Image = Image.FromFile("2.png");
                    }
                    else
                                    if (a[i, j] == 3)
                    {
                        b[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        b[i, j].Image = Image.FromFile("3.png");
                    }
                    else
                                        if (a[i, j] == 4)
                    {
                        b[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        b[i, j].Image = Image.FromFile("4.png");
                    }
                    else
                                            if (a[i, j] == 5)
                    {
                        b[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        b[i, j].Image = Image.FromFile("5.png");
                        lp = i; cp = j;
                    }
                    else
                                                if (a[i, j] == 7)
                    {
                        b[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        b[i, j].Image = Image.FromFile("7.png");
                        tl = i; tc = j;
                    }
                    else
                                                    if (a[i, j] == 8)
                    {
                        b[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        b[i, j].Image = Image.FromFile("8.png");
                    }
                    else
                                                        if (a[i, j] == 9)
                    {
                        b[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        b[i, j].Image = Image.FromFile("9.png");
                    }
                    else
                                                            if (a[i, j] == 10)
                    {
                        b[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        b[i, j].Image = Image.FromFile("10.png");
                    }
                    else
                                                                if (a[i, j] == 11)
                    {
                        b[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        b[i, j].Image = Image.FromFile("11.png");
                    }
                    else
                                                                    if (a[i, j] == 6)
                    {
                        b[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        b[i, j].Image = Image.FromFile("6.png");
                        lp = i; cp = j;
                    }
                    b[i, j].Visible = true;
                }
        }

        public Form3(int level)
        {
            InitializeComponent();
            fis = "lvl" + Convert.ToString(level) + ".txt";
            x = level;
            read(fis);
            generate_lab();
            show();
            label1.Text = Convert.ToString(scor) + " points";
            pictureBox2.Image = Image.FromFile("gif" + Convert.ToString(x) + ".gif");
        }
    }
}