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
    public partial class AdminSignUp : Form
    {
        public AdminSignUp()
        {
            InitializeComponent();
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
            bool f = true;
            SqlConnection sqlconnection = new SqlConnection("Data Source=FADIA-KHALED;Initial Catalog=Library;Integrated Security=True");
            sqlconnection.Open();
            SqlCommand sqlcommand = new SqlCommand();
            SqlCommand sqlcommand2 = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
            sqlcommand2.Connection = sqlconnection;

            SqlCommand authCommand = new SqlCommand();
            authCommand.Connection = sqlconnection;

            SqlCommand RdrCommand = new SqlCommand();
            RdrCommand.Connection = sqlconnection;

            if (String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrWhiteSpace(textBox4.Text)) {
                MessageBox.Show("You must enter email and password");
                f = false;
            }
            else if (!CheckMail(textBox3.Text))
            {
                MessageBox.Show("There's an account with this email, please try another email.");
                f = false;
            }
            else {

                if (!checkBox1.Checked && !checkBox2.Checked){
                    sqlcommand.CommandText = "INSERT INTO Person(Fname,Lname,Email,Pass,Admin) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','true')";
                    sqlcommand2.CommandText = "Insert into Library_Admin Select Person.PID from Person where Admin = 'true' AND Person.PID not in (Select * from Library_Admin)";
                    sqlcommand.ExecuteNonQuery();
                    sqlcommand2.ExecuteNonQuery();
                }

                if (checkBox1.Checked && checkBox2.Checked) {
                    sqlcommand.CommandText = "INSERT INTO Person(Fname,Lname,Email,Pass,Reader, Admin, Author) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','true','true','true')";
                    sqlcommand2.CommandText = "Insert into Library_Admin Select Person.PID from Person where Admin = 'true' AND Person.PID not in (Select * from Library_Admin)";
                    authCommand.CommandText = "Insert into Author(Author_ID) Select Person.PID from Person where Author = 'true' AND Person.PID not in (Select * from Author)";
                    RdrCommand.CommandText = "Insert into Reader (Reader_ID) Select Person.PID from Person where Reader = 'true' AND Person.PID not in (Select Reader_ID from Reader)";
                    sqlcommand.ExecuteNonQuery();
                    sqlcommand2.ExecuteNonQuery();
                    authCommand.ExecuteNonQuery();
                    RdrCommand.ExecuteNonQuery();
                }
                else if (checkBox1.Checked && !checkBox2.Checked) {
                    sqlcommand.CommandText = "INSERT INTO Person(Fname,Lname,Email,Pass,Admin, Author) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','true','true')";
                    sqlcommand2.CommandText = "Insert into Library_Admin Select Person.PID from Person where Admin = 'true' AND Person.PID not in (Select * from Library_Admin)";

                    authCommand.CommandText = "Insert into Author(Author_ID) Select Person.PID from Person where Author = 'true' AND Person.PID not in (Select * from Author)";
                    sqlcommand.ExecuteNonQuery();
                    sqlcommand2.ExecuteNonQuery();
                    authCommand.ExecuteNonQuery();
                }
                else if (checkBox2.Checked && !checkBox1.Checked) {
                    sqlcommand.CommandText = "INSERT INTO Person(Fname,Lname,Email,Pass,Reader,Admin) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','true','true')";
                    sqlcommand2.CommandText = "Insert into Library_Admin Select Person.PID from Person where Admin = 'true' AND Person.PID not in (Select * from Library_Admin)";
                    RdrCommand.CommandText = "Insert into Reader (Reader_ID) Select Person.PID from Person where Reader = 'true' AND Person.PID not in (Select Reader_ID from Reader)";
                    sqlcommand.ExecuteNonQuery();
                    sqlcommand2.ExecuteNonQuery();
                    RdrCommand.ExecuteNonQuery();
                }
                if (f) {
                    MessageBox.Show("Signed Up Successfully!");
                }
                sqlconnection.Close();
            }
        }

        private void AdminSignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
