using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseProject
{
    public partial class generateReports : Form
    {
        public generateReports()
        {
            InitializeComponent();
        }

        private void generateReports_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'LibraryDataSet.Books' table. You can move, or remove it, as needed.
            this.BooksTableAdapter.Fill(this.LibraryDataSet.Books);
            CrystalReport1 c = new CrystalReport1();
            crystalReportViewer1.ReportSource = c;

        }
    }
}
