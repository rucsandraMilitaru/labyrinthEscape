using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labyrinthEscape
{
    public partial class menu : Form
    {
        public static string user = login.user;
        public static int level = 0;
        public static int game = 0;

        public menu()
        {
            InitializeComponent();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            textBox3.Text = user;
            play.Visible = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                // label 3, label 4
                // textBox 1, textBox 2

                level = 0;
            } 
            else if (comboBox1.SelectedIndex == 1)
            {
                level = 1;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                level = 2;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                level = 3;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                level = 4;
            }

        }

        private void play_Click(object sender, EventArgs e)
        {
            game f2 = new game();
            f2.Show();
            this.Hide();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            game = 1; 
            play.Visible = true;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            game = 2;
            play.Visible = true;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            game = 3;
            play.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            game = 4;
            play.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            game = 5;
            play.Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            game = 6;
            play.Visible = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            game = 7;
            play.Visible = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            game = 8;
            play.Visible = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            game = 9;
            play.Visible = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            game = 10;
            play.Visible = true;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            game = 11;
            play.Visible = true;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            game = 12;
            play.Visible = true;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            game = 13;
            play.Visible = true;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            game = 14;
            play.Visible = true;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            game = 15;
            play.Visible = true;
        }
    }
}
