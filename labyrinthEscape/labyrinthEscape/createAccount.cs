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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace labyrinthEscape
{
    public partial class createAccount : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Database.mdf;Integrated Security=True");
        bool ok = false;
        public createAccount()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, EventArgs e)
        {//register
            string password1 = textBox2.Text;
            string password2 = textBox3.Text;
            if (password1 != password2)
            {
                MessageBox.Show("The entered passwords are NOT identical!");

            }
            else
            {
                ok = true;
            }
            if (ok == true)
            {
                c.Open();
                string insert = "insert into users(username, gmail_address, password) values(@username, @gmail_address, @password)";
                SqlCommand cmd = new SqlCommand(insert, c);
                cmd.Parameters.AddWithValue("username", textBox1.Text);
                cmd.Parameters.AddWithValue("password", textBox2.Text);
                cmd.Parameters.AddWithValue("gmail_address", textBox4.Text);
                SqlDataReader r = cmd.ExecuteReader();
                c.Close();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("The gmail address or password are invalid!");
            }
        }

        private void gobackToLogin_Click(object sender, EventArgs e)
        {//go to the login page
            this.Hide();
            login f2 = new login();
            f2.Show();
        }

        private void createAccount_Load(object sender, EventArgs e)
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox3.PasswordChar = (char)0;
            }
            else
            {
                textBox3.PasswordChar = '*';
            }
        }
    }
}
