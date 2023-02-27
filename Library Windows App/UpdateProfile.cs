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
    public partial class UpdateProfile : Form
    {
        public static int x = 0;

        public static string fname, lname, email, pass; 
        public UpdateProfile()
        {
            InitializeComponent();
            x = Login.x;
            SqlConnection sqlConnection = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
            sqlConnection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Person where PID='" + x + "'", sqlConnection);
            DataTable dt = new DataTable(); //this is creating a virtual table  
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() != "0")
            {
                string sqlquery = "SELECT * FROM Person WHERE PID= @id";

                SqlCommand command = new SqlCommand(sqlquery, sqlConnection);
                SqlDataReader sReader;

                command.Parameters.Clear();
                command.Parameters.AddWithValue("@id", x);
                sReader = command.ExecuteReader();

                while (sReader.Read())
                {
                    textBox1.Text = sReader["Fname"].ToString();
                    textBox2.Text = sReader["Lname"].ToString();
                    textBox3.Text = sReader["Email"].ToString();
                    textBox4.Text = sReader["Pass"].ToString();
                }
                sReader.Close();
                fname = textBox1.Text;
                lname = textBox2.Text;
                email = textBox3.Text;
                pass = textBox4.Text; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = Login.x;
            SqlConnection sqlConnection = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("First name field cannot be empty, it will remain as it was!");
                sqlCommand.CommandText = "UPDATE Person SET Fname ='" + fname + "' WHERE PID = '" + x + "'";
                sqlCommand.ExecuteNonQuery();
            }
            else
            {
                sqlCommand.CommandText = "UPDATE Person SET Fname ='" + textBox1.Text + "' WHERE PID = '" + x + "'";
                fname = textBox1.Text; 
                sqlCommand.ExecuteNonQuery();
            }

            if (String.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Last name field cannot be empty,it will remain as it was!");
                sqlCommand.CommandText = "UPDATE Person SET Lname ='" + lname + "' WHERE PID = '" + x + "'";
                sqlCommand.ExecuteNonQuery();
            }
            else
            {
                sqlCommand.CommandText = "UPDATE Person SET Lname ='" + textBox2.Text + "' WHERE PID = '" + x + "'";
                sqlCommand.ExecuteNonQuery();
                lname = textBox2.Text;
            }
            if (String.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Email field cannot be empty, it will remain as it was !");
                sqlCommand.CommandText = "UPDATE Person SET Email ='" + email + "' WHERE PID = '" + x + "'";
                sqlCommand.ExecuteNonQuery();
            }
            else
            {
                sqlCommand.CommandText = "UPDATE Person SET Email ='" + textBox3.Text + "' WHERE PID = '" + x + "'";
                sqlCommand.ExecuteNonQuery();
                email = textBox3.Text;
            }

            if (String.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Password field cannot be empty, it will remain as it was!");
                sqlCommand.CommandText = "UPDATE Person SET Pass ='" + pass + "' WHERE PID = '" + x + "'";
                sqlCommand.ExecuteNonQuery();
            }
            else
            {
                sqlCommand.CommandText = "UPDATE Person SET Pass ='" + textBox4.Text + "' WHERE PID = '" + x + "'";
                sqlCommand.ExecuteNonQuery();
                pass = textBox4.Text;
            }
            sqlConnection.Close();

            MessageBox.Show("Your profile has been updated successfully");



        }
    }
}
