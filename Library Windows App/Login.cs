using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public static int x = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            int y = Home.y; 
            if (y == 11)
            {
                SqlConnection sqlconnection = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                sqlconnection.Open();
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;
                sqlcommand.CommandText = "SELECT COUNT(*) from Person where Email = '" + textBox1.Text + "' AND Pass = '" + textBox2.Text + "'";
                int check = (int)sqlcommand.ExecuteScalar();
                if (check == 0)
                {
                    MessageBox.Show("Invalid Email or Password try again or sign up if new user");
                }
                else
                {
                    sqlcommand.CommandText = "SELECT PID from Person where Email like '" + textBox1.Text + "' AND Pass like '" + textBox2.Text + "'";
                    x = (int)sqlcommand.ExecuteScalar();
                    sqlconnection.Close();
                    UpdateProfile upForm = new UpdateProfile();
                    this.Hide();
                    upForm.Show();
                    
                }
            }
            if (y==10)
            {
                SqlConnection sqlconnection = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                sqlconnection.Open();
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;
                sqlcommand.CommandText = "SELECT COUNT(*) from Person where Email = '" + textBox1.Text + "' AND Pass = '" + textBox2.Text + "' AND Reader like'%rue' ";
                int check = (int)sqlcommand.ExecuteScalar();
                if (check == 0)
                {
                    MessageBox.Show("Invalid Email or Password try again or sign up if new user");
                }
                else
                {
                    sqlcommand.CommandText = "SELECT PID from Person where Email like '" + textBox1.Text + "' AND Pass like '" + textBox2.Text + "' AND Reader like'%rue' ";
                    x = (int)sqlcommand.ExecuteScalar();
                    sqlconnection.Close();
                    WriteComment Commentform = new WriteComment();
                    Commentform.Show();
                    this.Hide();
                }
            }
            if (y==7)
            {
                SqlConnection sqlconnection = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                sqlconnection.Open();
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;
                sqlcommand.CommandText = "SELECT COUNT(*) from Person where Email = '" + textBox1.Text + "' AND Pass = '" + textBox2.Text + "' AND Reader like'%rue' ";
                int check = (int)sqlcommand.ExecuteScalar();
                if (check == 0)
                {
                    MessageBox.Show("Invalid Email or Password try again or sign up if new user");
                }
                else
                {
                    sqlcommand.CommandText = "SELECT PID from Person where Email like '" + textBox1.Text + "' AND Pass like '" + textBox2.Text + "' AND Reader like'%rue' ";
                    x = (int)sqlcommand.ExecuteScalar();
                    sqlconnection.Close();
                    BuyBook buyform = new BuyBook();
                    buyform.Show();
                    this.Hide();
                }
            }
            if (y==2)
            {
                SqlConnection sqlconnection = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                sqlconnection.Open();
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;
                sqlcommand.CommandText = "SELECT COUNT(*) from Person where Email = '" + textBox1.Text + "' AND Pass = '" + textBox2.Text + "' AND Admin like'%rue' ";
                int check = (int)sqlcommand.ExecuteScalar();
                if (check == 0)
                {
                    MessageBox.Show("Wrong email and password, or you're not authorized to open this !");
                }
                else
                {
                    sqlcommand.CommandText = "SELECT PID from Person where Email like '" + textBox1.Text + "' AND Pass like '" + textBox2.Text + "' AND Admin like'%rue' ";
                    x = (int)sqlcommand.ExecuteScalar();
                    sqlconnection.Close();

                    InsertBook Inform = new InsertBook();
                    Inform.Show(); 
                    this.Hide();
                }
            }

            if (y == 12)
            {
                SqlConnection sqlconnection = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                sqlconnection.Open();
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;
                sqlcommand.CommandText = "SELECT COUNT(*) from Person where Email = '" + textBox1.Text + "' AND Pass = '" + textBox2.Text + "' AND Admin like'%rue' ";
                int check = (int)sqlcommand.ExecuteScalar();
                if (check == 0)
                {
                    MessageBox.Show("Wrong email and password, or you're not authorized to open this  !");
                }
                else
                {
                    sqlcommand.CommandText = "SELECT PID from Person where Email like '" + textBox1.Text + "' AND Pass like '" + textBox2.Text + "' AND Admin like'%rue' ";
                    x = (int)sqlcommand.ExecuteScalar();
                    sqlconnection.Close();
                    generateReports repForm = new generateReports();
                    repForm.Show();
                    this.Hide();
                }           
            }
            if (y == 13)
            {
                SqlConnection sqlconnection = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
                sqlconnection.Open();
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;
                sqlcommand.CommandText = "SELECT COUNT(*) from Person where Email = '" + textBox1.Text + "' AND Pass = '" + textBox2.Text + "' AND Admin like'%rue' ";
                int check = (int)sqlcommand.ExecuteScalar();
                if (check == 0)
                {
                    MessageBox.Show("Wrong email and password, or you're not authorized to open this  !");
                }
                else
                {
                    sqlcommand.CommandText = "SELECT PID from Person where Email like '" + textBox1.Text + "' AND Pass like '" + textBox2.Text + "' AND Admin like'%rue' ";
                    x = (int)sqlcommand.ExecuteScalar();
                    sqlconnection.Close();

                    queries Qform = new queries();
                    Qform.Show();
                    this.Hide();
                }
            }
        }
    }
}
