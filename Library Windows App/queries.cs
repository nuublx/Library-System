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
    public partial class queries : Form
    {
        public queries()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=FADIA-KHALED;Initial Catalog=Library;Integrated Security=True");
            string query = textBox1.Text; 
            sqlConnection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            sqlConnection.Close();
            if(ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0]; 
            }
        }

        private void queries_Load(object sender, EventArgs e)
        {

        }
    }
}
