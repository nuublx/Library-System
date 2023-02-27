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
    public partial class SearchBook : Form
    {
        public SearchBook()
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
                    label8.Text = sReader["Category"].ToString();
                    label12.Text = sReader["PubYear"].ToString();
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
            sqlConnection.Close();

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDataSet.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.libraryDataSet.Books);
        }
    }
}
