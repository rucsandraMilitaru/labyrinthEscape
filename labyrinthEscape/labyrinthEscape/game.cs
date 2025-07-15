using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labyrinthEscape
{
    public partial class game : Form
    {
        Button[,] b = new Button[20, 20];// button array
        int[,] a = new int[20, 20];// normal array
        int[,] c = new int[20, 20];// regions array
        bool dr, st, sus, jos;

        int row = 0, col = 0;
        int n = 11, m = 20;
        //int i_finish = 10, j_finish = 0;
        int[] i_finish = new int[20];
        int[] j_finish = new int[20];

        bool stillPlaying = true;
        int moves = 0;
        String startTime;

        Color[] colorsTeleportingSpots = {
            Color.MediumPurple,
            Color.Coral,
            Color.MediumSlateBlue,
            Color.CornflowerBlue,
            Color.MediumVioletRed,
            Color.MediumOrchid
        };

        int[] x1_coordinates = new int[20];
        int[] y1_coordinates = new int[20];
        int[] x2_coordinates = new int[20];
        int[] y2_coordinates = new int[20];
        bool[] visited = new bool[20];
        int countSpots = 0;
        int countEnds = 0;

        string filename = "";

        public static string user = login.user;

        public game()
        {
            InitializeComponent();
        }

        private void game_Load(object sender, EventArgs e)
        {
            startTime = DateTime.Now.ToString("hh:mm:ss");            
        }

        private void game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                dr = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                st = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                sus = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                jos = true;
            }

        }

        private void game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                dr = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                st = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                sus = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                jos = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {// select level
            if (filename == "")
            {
                filename = "level0lab01";
            }

            int gameNumber = Convert.ToInt32(comboBox1.SelectedItem.ToString());
            // TODO: CHANGE TO => int gameNumber = menu.game; 
            if (gameNumber == 1)
            {
                filename = "level0lab01";
            }
            else if (gameNumber == 2)
            {
                filename = "level0lab02";
            }
            else if (gameNumber == 3)
            {
                filename = "level0lab03";
            }
            else if (gameNumber == 4)
            {
                filename = "level0lab04";
            }
            else if (gameNumber == 5)
            {
                filename = "level0lab05";
            }
            else if (gameNumber == 6)
            {
                filename = "level0lab06";
            }
            else if (gameNumber == 7)
            {
                filename = "level0lab07";
            }
            else if (gameNumber == 8)
            {
                filename = "level0lab08";
            }
            else if (gameNumber == 9)
            {
                filename = "level0lab09";
            }
            else if (gameNumber == 10)
            {
                filename = "level0lab10";
            }
            else if (gameNumber == 11)
            {
                filename = "level0lab11";
            }
            else if (gameNumber == 12)
            {
                filename = "level0lab12";
            }
            else if (gameNumber == 13)
            {
                filename = "level0lab13";
            }
            else if (gameNumber == 14)
            {
                filename = "level0lab14";
            }

            matrix();
            labyrinth();

            timer1.Start();

            comboBox1.Enabled = false;
            comboBox1.Visible = false;
            button1.Enabled = false;

            textBox1.Enabled = false;

            if (user != null)
            {
                textBox1.Text = user.ToString();
            }
            else
            {
                textBox1.Text = "user 2.0";
            }

            stillPlaying = true;
            startTime = DateTime.Now.ToString("hh:mm:ss");
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stillPlaying)
            {
                if (sus == true && row != n - 1 && c[row + 1, col] != 1)
                {
                    row += 1;
                    moves++;
                }
                if (jos == true && row != 0 && c[row - 1, col] != 1)
                {
                    row -= 1;
                    moves++;
                }
                if (dr == true && col != m - 1 && c[row, col + 1] != 1)
                {
                    col += 1;
                    moves++;
                }
                if (st == true && col != 0 && c[row, col - 1] != 1)
                {
                    col -= 1;
                    moves++;
                }
            }

            if (c[row, col] == 3)
            {
                //find the index
                for (int i = 0; i < countSpots; i++)
                {
                    if (x1_coordinates[i] == row && y1_coordinates[i] == col)//found a teleporting spot
                    {
                        row = x2_coordinates[i];
                        col = y2_coordinates[i];
                        visited[i] = true;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (c[i, j] == 0)
                    {
                        b[i, j].BackColor = Color.ForestGreen;
                    }
                    else if (c[i, j] == 1)
                    {
                        b[i, j].BackColor = Color.DarkGreen;
                    }
                    /*
                    else
                    {
                        b[i, j].BackColor = Color.DimGray;
                    }*/
                }
            }

            for (int i = 0; i < countSpots; i++)
            {
                b[x1_coordinates[i], y1_coordinates[i]].BackColor = colorsTeleportingSpots[i];
                b[x2_coordinates[i], y2_coordinates[i]].BackColor = colorsTeleportingSpots[i];
            }

            for (int i = 0; i < countSpots; i++)
            {
                if (visited[i] == true)
                {
                    b[x1_coordinates[i], y1_coordinates[i]].BackColor = Color.DimGray;
                    b[x2_coordinates[i], y2_coordinates[i]].BackColor = Color.DimGray;

                    if (i != 0)
                    {
                        b[x2_coordinates[i - 1], y2_coordinates[i - 1]].BackColor = Color.DimGray;
                    }
                }
            }

            for (int k = 0; k < countEnds; k++)
            {
                if (countEnds == 1)
                {// one end
                    b[row, col].BackColor = Color.DarkGoldenrod;
                    b[i_finish[k], j_finish[k]].BackColor = Color.Goldenrod;
                }
                else
                {
                    b[row, col].BackColor = Color.DarkGoldenrod;
                    //b[i_finish[k], j_finish[k]].BackColor = colorsTeleportingSpots[k];
                    b[i_finish[k], j_finish[k]].BackColor = Color.Crimson;
                }

                if (row == i_finish[k] && col == j_finish[k])
                {
                    b[row, col].BackColor = Color.DimGray;
                    endOfGame();

                    //b[row, col].BackColor = Color.DimGray;
                    /*
                    for (int i = 0; i < countSpots; i++)
                    {
                        b[x1_coordinates[i], y1_coordinates[i]].BackColor = Color.DimGray;
                        b[x2_coordinates[i], y2_coordinates[i]].BackColor = Color.DimGray;
                    }*/

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            b[i, j].BackColor = Color.DimGray;
                        }
                    }
                    button1.Visible = true;
                    comboBox1.Visible = true;
                    comboBox1.Enabled = true;

                    clearLabyrinth();

                    //break;
                    timer1.Stop();




                }

            }

            String nowTime = DateTime.Now.ToString("hh:mm:ss");
            string[] nowTime_v = nowTime.Split(':');
            int hours_now = Convert.ToInt32(nowTime_v[0].ToString());
            int minutes_now = Convert.ToInt32(nowTime_v[1].ToString());
            int seconds_now = Convert.ToInt32(nowTime_v[2].ToString());

            string[] startTime_v = startTime.Split(':');
            int hours_start = Convert.ToInt32(startTime_v[0].ToString());
            int minutes_start = Convert.ToInt32(startTime_v[1].ToString());
            int seconds_start = Convert.ToInt32(startTime_v[2].ToString());

            int hours = hours_now - hours_start;
            int minutes = minutes_now - minutes_start;
            int seconds = seconds_now - seconds_start;

            if (seconds < 0)
            {
                seconds += 60;
                minutes--;
            }
            if (minutes < 0)
            {
                minutes += 60;
                hours--;
            }

            if (stillPlaying)
            {
                label1.Text = hours + " hours, " + minutes + " minutes and " + seconds + " seconds";
            }
            label2.Text = "Number of moves : " + moves;

        }

        private void matrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Button button = new Button();

                    button.Width = 50;
                    button.Height = 50;
                    button.Text = i + "," + j;
                    button.Font = new Font("Nirmala UI", 8);
                    button.FlatStyle = FlatStyle.Flat;
                    button.Enabled = false;

                    button.Location = new Point(100 + j * (50), 100 + i * (50));
                    b[i, j] = button;
                    button.Click += button1_Click;
                    this.Controls.Add(button);
                }
            }

        }
        private void labyrinth()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    c[i, j] = 0;
                }
            }

            using (StreamReader fin = new StreamReader(filename + ".txt"))
            {
                while (!fin.EndOfStream)
                {
                    string linie = fin.ReadLine();
                    if (linie.Contains('*'))
                    {
                        linie = fin.ReadLine();
                        string[] v = linie.Split(',');
                        row = Convert.ToInt32(v[0].ToString());
                        col = Convert.ToInt32(v[1].ToString());

                        linie = fin.ReadLine();
                        if (linie.Contains('%'))
                        {
                            //%
                            //1,0/0,19/10,19
                            linie = fin.ReadLine();
                            string[] v1 = linie.Split('/');

                            countEnds = v1.Count();
                            for (int i = 0; i < v1.Count(); i++)
                            {
                                string[] v2 = v1[i].Split(',');
                                i_finish[i] = Convert.ToInt32(v2[0].ToString());
                                j_finish[i] = Convert.ToInt32(v2[1].ToString());
                            }
                        }
                        else
                        {
                            string[] v1 = linie.Split(',');
                            i_finish[0] = Convert.ToInt32(v1[0].ToString());
                            j_finish[0] = Convert.ToInt32(v1[1].ToString());
                            countEnds = 1;
                        }
                    }

                    else if (linie.Contains('@'))
                    {
                        //10,0 10,9;10,19 8,19;2,10 1,4
                        linie = fin.ReadLine();
                        string[] v = linie.Split(';');//10,0 10,9

                        countSpots = v.Count();
                        for (int i = 0; i < countSpots; i++)
                        {
                            string[] v1 = v[i].Split(' ');//10,0 10,9

                            //teleporting START spot
                            string[] v2 = v1[0].Split(',');//10,0
                            x1_coordinates[i] = Convert.ToInt32(v2[0].ToString());
                            y1_coordinates[i] = Convert.ToInt32(v2[1].ToString());

                            c[x1_coordinates[i], y1_coordinates[i]] = 3;

                            //teleporting END spot
                            v2 = v1[1].Split(',');//10,9
                            x2_coordinates[i] = Convert.ToInt32(v2[0].ToString());
                            y2_coordinates[i] = Convert.ToInt32(v2[1].ToString());

                            c[x2_coordinates[i], y2_coordinates[i]] = 3;
                        }
                    }
                    else
                    {
                        string[] v = linie.Split(',');
                        int i = Convert.ToInt32(v[0].ToString());
                        int j = Convert.ToInt32(v[1].ToString());
                        c[i, j] = 1;
                    }

                }
                fin.Close();
            }

            for (int i = 0; i < countSpots; i++)
            {
                visited[i] = false;
            }

        }

        private void endOfGame()
        {
            if (stillPlaying == true)
            {
                stillPlaying = false;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        c[i, j] = 2;
                    }
                }
            }

        }

        private void clearLabyrinth()
        {

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    b[i, j] = null;
                    a[i, j] = 0;
                    c[i, j] = 0;
                }
            }

            moves = 0;
            countEnds = 0;
            countSpots = 0;
            label1.Text = "";


        }



    }
}
