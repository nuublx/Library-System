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
    public partial class ReaderAuthorSignUp : Form
    {

        public ReaderAuthorSignUp()
        {
            InitializeComponent();
            MessageBox.Show("Welcome to Sign Up Form!");
        }

        public bool CheckMail(string email)

        {
            SqlConnection con = new SqlConnection("Data Source=FADIA-KHALED;Initial Catalog=Library;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("select Email from  Person  where Email='" + email + "'", con);

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Authr = "true";
            String Readr = "true";
            bool f = true;
            SqlConnection sqlconnection = new SqlConnection("Data Source=FADIA-KHALED;Initial Catalog=Library;Integrated Security=True");
            sqlconnection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            SqlCommand sqlcommand2 = new SqlCommand();
            SqlCommand sqlcommand3 = new SqlCommand();

            sqlcommand.Connection = sqlconnection;
            sqlcommand2.Connection = sqlconnection;
            sqlcommand3.Connection = sqlconnection; 
            if (checkBox1.Checked && checkBox2.Checked)
            {
                if (String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrWhiteSpace(textBox4.Text)){
                    MessageBox.Show("You must enter email and password");
                    f = false; 
                }
                else if (!CheckMail(textBox3.Text)) {
                    MessageBox.Show("There's an account with this email, please try another email.");
                    f = false;
                }
                else {
                    sqlcommand.CommandText = "INSERT INTO Person(Fname,Lname,Email,Pass,Author,Reader) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + Authr + "','" + Readr + "')";
                    sqlcommand2.CommandText = "Insert into Author(Author_ID) Select Person.PID from Person where Author = 'true' AND Person.PID not in (Select * from Author)";
                    sqlcommand3.CommandText = "Insert into Reader (Reader_ID) Select Person.PID from Person where Reader = 'true' AND Person.PID not in (Select Reader_ID from Reader)";
                    sqlcommand.ExecuteNonQuery();
                    sqlcommand2.ExecuteNonQuery();
                    sqlcommand3.ExecuteNonQuery();
                }
                
            }
            else if (checkBox1.Checked && !checkBox2.Checked)
            {
                if (String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrWhiteSpace(textBox4.Text)) {
                    sqlcommand.CommandText = "INSERT INTO Person(Fname,Lname,Author) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + Authr + "')";
                    sqlcommand2.CommandText = "Insert into Author(Author_ID) Select Person.PID from Person where Author = 'true' AND Person.PID not in (Select * from Author)";
                    sqlcommand.ExecuteNonQuery();
                    sqlcommand2.ExecuteNonQuery();
                }
                else {
                    if (!CheckMail(textBox3.Text))
                    {
                        MessageBox.Show("There's an account with this email, please try another email.");
                        f = false;
                    }
                    else
                    {
                        sqlcommand.CommandText = "INSERT INTO Person(Fname,Lname,Email,Pass,Author) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + Authr + "')";
                        sqlcommand2.CommandText = "Insert into Author(Author_ID) Select Person.PID from Person where Author = 'true' AND Person.PID not in (Select * from Author)";
                        sqlcommand.ExecuteNonQuery();
                        sqlcommand2.ExecuteNonQuery();
                    }
                }
                    
            }
            else if (checkBox2.Checked && !checkBox1.Checked)
            {
                if (String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrWhiteSpace(textBox4.Text))
                {
                    MessageBox.Show("You must enter email and password");
                    f = false; 
                }
                else if (!CheckMail(textBox3.Text))
                {
                    MessageBox.Show("There's an account with this email, please try another email.");
                    f = false;
                }
                else
                {
                    sqlcommand.CommandText = "INSERT INTO Person(Fname,Lname,Email,Pass,Reader) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "', '" + Readr + "')";
                    sqlcommand3.CommandText = "Insert into Reader (Reader_ID) Select Person.PID from Person where Reader = 'true' AND Person.PID not in (Select Reader_ID from Reader)";
                    sqlcommand.ExecuteNonQuery();
                    sqlcommand3.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("Please Check at least one checkbox to proceed");
                f = false;
            }
            if (f)
            {
                MessageBox.Show("Signed Up Successfully!");
            }
            sqlconnection.Close();
        }
    }
}
