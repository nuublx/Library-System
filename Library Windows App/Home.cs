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
    public partial class Home : Form
    {
        public static int y = 0;

        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            y = 2; 
            Login form2 = new Login();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReaderAuthorSignUp form4 = new ReaderAuthorSignUp();
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminSignUp form5 = new AdminSignUp();
            form5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SearchBook form6 = new SearchBook();
            form6.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            y = 7; 
            Login form7 = new Login();
            form7.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CategorizeBooks form8 = new CategorizeBooks();
            form8.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AvailableBooks form9 = new AvailableBooks();
            form9.Show(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            y = 10; 
            Login form10 = new Login();
            form10.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            y = 11;
            Login form11 = new Login();
            form11.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            y = 12;
            Login form12 = new Login();
            form12.Show(); 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            y = 13;
            Login form13 = new Login();
            form13.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
