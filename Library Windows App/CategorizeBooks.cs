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
    public partial class CategorizeBooks : Form
    {
        public CategorizeBooks()
        {
            InitializeComponent();
            //this.booksTableAdapter.Fill(this.libraryDataSet.Books);

        }

        private void CategorizeBooks_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'libraryDataSet.Books' table. You can move, or remove it, as needed.
            //this.booksTableAdapter.Fill(this.libraryDataSet.Books);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Books", "Data Source=FADIA-KHALED; Initial Catalog=Library;Integrated Security=True");
            DataSet ds = new DataSet();
            da.Fill(ds, "Books");
            dataGridView1.DataSource = ds.Tables["Books"].DefaultView;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=FADIA-KHALED;Initial Catalog=Library;Integrated Security=True");
            sqlConnection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Books WHERE Category='" + textBox1.Text + "'", sqlConnection);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Books");
            dataGridView1.DataSource = ds.Tables["Books"].DefaultView;
            sqlConnection.Close();
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Books", "Data Source=FADIA-KHALED; Initial Catalog=Library;Integrated Security=True");
                DataSet dk = new DataSet();
                da.Fill(dk, "Books");
                dataGridView1.DataSource = dk.Tables["Books"].DefaultView;
            }
        }
    }
}
