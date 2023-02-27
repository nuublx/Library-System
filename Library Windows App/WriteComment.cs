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
    public partial class WriteComment : Form
    {
        public WriteComment()
        {
            InitializeComponent();
        }

        private void WriteComment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDataSet.Books' table. You can move, or remove it, as needed.
            //this.booksTableAdapter.Fill(this.libraryDataSet.Books);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlc = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True");
            sqlc.Open();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = sqlc;
            sqlcom.CommandText = "SELECT COUNT(*) FROM Books where BID='" + textBox1.Text + "'";
            int check = (int)sqlcom.ExecuteScalar();

            if (check > 0)
            {
                int x = Login.x;
                sqlcom.CommandText = "SELECT COUNT(*) FROM Comments where BookID='" + textBox1.Text + "' AND readerID='" + x + "'";
                int check2 = (int)sqlcom.ExecuteScalar();
                if (check2 == 0)
                {
                    sqlcom.CommandText = "INSERT INTO Comments VALUES('" + textBox1.Text + "','" + x + "','" + textBox2.Text + "')";
                    sqlcom.ExecuteNonQuery();
                    sqlc.Close();
                    MessageBox.Show("Comment is posted successfully!");
                }
                else
                {
                    MessageBox.Show("You can only post one comment for each book!");
                }
            }
            else
            {
                MessageBox.Show("Book doesn't exist check Book ID.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.booksTableAdapter.Fill(this.libraryDataSet.Books);
        }
    }
}
