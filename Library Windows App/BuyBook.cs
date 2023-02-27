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

    public partial class BuyBook : Form
    {
        public BuyBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=FADIA-KHALED;Initial Catalog=Library;Integrated Security=True");
            sqlConnection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Books WHERE Title = '" + textBox1.Text + "'", sqlConnection);
            DataTable dt = new DataTable(); //this is creating a virtual table  
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() != "0")
            {
                string sqlquery = "SELECT * FROM Books WHERE Title = @title";

                SqlCommand command = new SqlCommand(sqlquery, sqlConnection);
                SqlDataReader sReader;

                command.Parameters.Clear();
                command.Parameters.AddWithValue("@title", textBox1.Text);
                sReader = command.ExecuteReader();

                while (sReader.Read())
                {
                    label7.Text = sReader["Price"].ToString();
                }
                sReader.Close();

                string authorQuery = "Select Fname, Lname From Person, Books where Books.Title = @title and Books.AuthorID = PID";
                SqlCommand command2 = new SqlCommand(authorQuery, sqlConnection);
                SqlDataReader sGet;
                command2.Parameters.Clear();
                command2.Parameters.AddWithValue("@title", textBox1.Text);
                sGet = command2.ExecuteReader();

                while (sGet.Read())
                {
                    label9.Text = sGet["Fname"].ToString();
                    label10.Text = sGet["Lname"].ToString();
                }
                sGet.Close();
            }
            else
            {
                MessageBox.Show("There's no book with this name in our book store");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Bid = "0";
            bool f = true, k = true;
            SqlConnection sqlConnection = new SqlConnection("Data Source=FADIA-KHALED;Initial Catalog=Library;Integrated Security=True");
            sqlConnection.Open();

            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlConnection;
            sqlcom.CommandText = "SELECT COUNT(*) FROM Books WHERE Title = '" + textBox1.Text + "'";
            int check = (int)sqlcom.ExecuteScalar();

            int x = Login.x;

            if (check > 0)
            {
                string BookQuery = "Select BID From Books where Books.Title =  '" + textBox1.Text + "'";
                SqlCommand command2 = new SqlCommand(BookQuery, sqlConnection);
               
                SqlDataReader sGet;
                command2.Parameters.Clear();
                command2.Parameters.AddWithValue("@title", textBox1.Text);

                sGet = command2.ExecuteReader();
                while (sGet.Read())
                {
                    Bid = sGet["BID"].ToString();
                }
                sGet.Close();

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlConnection;
                sqlcmd.CommandText = "SELECT COUNT(*) FROM Buys where BookID='" + Bid + "' AND readerID='" + x + "'";
                int check2 = (int)sqlcmd.ExecuteScalar(); 

                if (check2 == 0)
                {
                    SqlCommand sqlcommand = new SqlCommand("insert into Buys (BookID, readerID, MonthBought, YearBought) values ('" + Bid + "','" + x + "','" + textBox4.Text + "','" + textBox5.Text + "')");
                    sqlcommand.Connection = sqlConnection;
                    sqlcommand.ExecuteNonQuery();
                }
                else
                {
                    k = false;
                    MessageBox.Show("You have already bought this book before!");
                }
            }
            else
            {
                k = false; 
                MessageBox.Show("There's no book with this name in our book store");
            }

            if (f && k)
            {
                MessageBox.Show("You Bought This Book Suceffully");
            }
            sqlConnection.Close();
        }


        private void BuyBook_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDataSet.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.libraryDataSet.Books);

        }
    }
}
