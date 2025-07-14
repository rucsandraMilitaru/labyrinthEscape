using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labyrinthEscape
{
    public partial class login : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Database.mdf;Integrated Security=True");
        bool ok1 = false, ok2 = false;
        public static string user;
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = (char)0;
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            user = textBox1.Text;
            c.Open();
            string select = "select * from users where username=@t1";
            SqlCommand cmd = new SqlCommand(select, c);
            cmd.Parameters.AddWithValue("t1", textBox1.Text);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read() == true)
            {
                ok1 = true;
            }
            else
            {
                MessageBox.Show("The username you have entered is invalid!");
            }
            c.Close();

            c.Open();
            string select1 = "select * from users where password=@p1";
            SqlCommand cmd1 = new SqlCommand(select1, c);
            cmd1.Parameters.AddWithValue("p1", textBox2.Text);
            SqlDataReader r1 = cmd.ExecuteReader();
            if (r1.Read() == true)
            {
                ok2 = true;
            }
            else
            {
                MessageBox.Show("The password is invalid!");
            }
            c.Close();

            if (ok1 == true && ok2 == true)
            {
                user = textBox1.Text;

                menu f2 = new menu();
                f2.Show();

                ok1 = false;
                ok2 = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {// go to the register form
            this.Hide();
            createAccount f2 = new createAccount();
            f2.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
