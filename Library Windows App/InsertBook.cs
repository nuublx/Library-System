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
    public partial class InsertBook : Form
    {
        public InsertBook()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'libraryDataSet.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.libraryDataSet.Books);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Bid = "0", Aid ="0";
            int x = Login.x;

            SqlConnection sqlConnection = new SqlConnection("Data Source=FADIA-KHALED;Initial Catalog=Library;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();


            string AuthorQuery = "Select PID From Person where Fname =  '" + textBox6.Text + "' and Lname = '"+ textBox7.Text + "' and Author = 'true' ";
            SqlCommand command2 = new SqlCommand(AuthorQuery, sqlConnection);

            SqlDataReader sGet;
            command2.Parameters.Clear();
            command2.Parameters.AddWithValue("@Author", textBox6.Text);
            sGet = command2.ExecuteReader();
            while (sGet.Read())
            {
                Aid = sGet["PID"].ToString();
            }
            sGet.Close();

            sqlCommand.CommandText = "INSERT INTO BOOKS VALUES ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + Aid + "')";
            sqlCommand.ExecuteNonQuery();



            string BookQuery = "Select BID From Books where Books.Title =  '" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(BookQuery, sqlConnection);

            SqlDataReader reader;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@title", textBox2.Text);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Bid= reader["BID"].ToString();
            }
            reader.Close();

            SqlCommand sqlcommand = new SqlCommand("insert into Uploads values ('" + Bid + "','" + x + "')");
            sqlcommand.Connection = sqlConnection;
            sqlcommand.ExecuteNonQuery();

            MessageBox.Show("The book has been inserted successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=FADIA-KHALED;Initial Catalog=Library;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            if (string.IsNullOrWhiteSpace(textBox1.Text)) {
                MessageBox.Show("Please enter the book id first !"); 
            }
            else {
                SqlCommand sqlcom = new SqlCommand();
                sqlcom.Connection = sqlConnection;
                sqlcom.CommandText = "SELECT COUNT(*) FROM Books WHERE BID = '" + textBox1.Text + "'";
                int check = (int)sqlcom.ExecuteScalar();

                int x = Login.x;

                if (check > 0)
                {
                    sqlCommand.CommandText = "DELETE FROM BOOKS WHERE BID ='" + textBox1.Text + "' ";
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("The book has been deleted Successfully");
                }
                else
                {
                    MessageBox.Show("There is no book with this ID please recheck");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=FADIA-KHALED;Initial Catalog=Library;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter the book id first !");
            }
            else
            {
                SqlCommand sqlcom = new SqlCommand();
                sqlcom.Connection = sqlConnection;
                sqlcom.CommandText = "SELECT COUNT(*) FROM Books WHERE BID =  '" + textBox1.Text + "'";
                int check = (int)sqlcom.ExecuteScalar();

                int x = Login.x;

                if (check > 0)
                {
                    sqlCommand.CommandText = "UPDATE BOOKS SET Title ='" + textBox2.Text + "' WHERE BID = '" + textBox1.Text + "'";
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Title has Changed Successfully");
                }
                else
                {
                    MessageBox.Show("There is no book with this ID please recheck");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.booksTableAdapter.Fill(this.libraryDataSet.Books);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=FADIA-KHALED;Initial Catalog=Library;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter the book id first !");
            }
            else
            {
                SqlCommand sqlcom = new SqlCommand();
                sqlcom.Connection = sqlConnection;
                sqlcom.CommandText = "SELECT COUNT(*) FROM Books WHERE BID =  '" + textBox1.Text + "'";
                int check = (int)sqlcom.ExecuteScalar();

                int x = Login.x;

                if (check > 0)
                {
                    sqlCommand.CommandText = "UPDATE BOOKS SET Category ='" + textBox3.Text + "' WHERE BID = '" + textBox1.Text + "'";
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Category has Changed Successfully");
                }
                else
                {
                    MessageBox.Show("There is no book with this ID please recheck");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=FADIA-KHALED;Initial Catalog=Library;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter the book id first !");
            }
            else
            {
                SqlCommand sqlcom = new SqlCommand();
                sqlcom.Connection = sqlConnection;
                sqlcom.CommandText = "SELECT COUNT(*) FROM Books WHERE BID = '" + textBox1.Text + "'";
                int check = (int)sqlcom.ExecuteScalar();

                int x = Login.x;

                if (check > 0)
                {
                    sqlCommand.CommandText = "UPDATE BOOKS SET Price ='" + textBox4.Text + "' WHERE BID = '" + textBox1.Text + "'";
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Price has Changed Successfully");
                }
                else
                {
                     MessageBox.Show("There is no book with this ID please recheck"); 
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=FADIA-KHALED;Initial Catalog=Library;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter the book id first !");
            }
            else
            {
                SqlCommand sqlcom = new SqlCommand();
                sqlcom.Connection = sqlConnection;
                sqlcom.CommandText = "SELECT COUNT(*) FROM Books WHERE BID =  '" + textBox1.Text + "'";
                int check = (int)sqlcom.ExecuteScalar();
                int x = Login.x;

                if (check > 0)
                {
                    sqlCommand.CommandText = "UPDATE BOOKS SET PubYear ='" + textBox5.Text + "' WHERE BID = '" + textBox1.Text + "'";
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Published Year has Changed Successfully");
                }
                else
                {
                    MessageBox.Show("There is no book with this ID please recheck");
                }
            }
        }
    }
}
