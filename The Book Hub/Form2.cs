using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace The_Book_Hub
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            bunifuLabel13.Text = DateTime.Now.ToLongTimeString();
            bunifuLabel14.Text = DateTime.Now.ToLongDateString();
            string connectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            
            string query2 = "select count(Book_ID) from NewBook";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd2 = new SqlCommand(query2, connection))
                {
                    connection.Open();
                    var result = cmd2.ExecuteScalar(); 
                    string n = result.ToString();
                    bunifuLabel8.Text = result.ToString();
                    connection.Close();

                }
            }

            string query3 = "select count(Enrollment_No) from NewStudent";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd2 = new SqlCommand(query3, connection))
                {
                    connection.Open();
                    var result = cmd2.ExecuteScalar(); 
                    string n = result.ToString();
                    bunifuLabel6.Text = result.ToString();
                    connection.Close();

                }
            }

            string query4 = "select count(Book_ID) from Issue_Book where Book_Return_Date is null";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd2 = new SqlCommand(query4, connection))
                {
                    connection.Open();
                    var result = cmd2.ExecuteScalar(); 
                    string n = result.ToString();
                    bunifuLabel7.Text = result.ToString();
                    connection.Close();

                }
            }

            string query5 = "select sum((case when isnumeric([Book_Quantity])=1 then convert(int ,[Book_Quantity]) else 0 end)) from NewBook";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd2 = new SqlCommand(query5, connection))
                {
                    connection.Open();
                    var result = cmd2.ExecuteScalar(); 
                    string n = result.ToString();
                    bunifuLabel9.Text = result.ToString();
                    connection.Close();

                }
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DialogResult res;
            res = MessageBox.Show("Do you want to Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
               
                this.Close();
                Form1 f = new Form1();
                f.Show();
            }
            else
            {
                this.Show();

            }
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Close();
            Form3 f = new Form3();
            f.Show();
        }

        private void viewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Close();
            Form4 f = new Form4();
            f.Show();
        }

        private void addSudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            this.Close();
            Form5 f = new Form5();
            f.Show();
        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Close();
            Form6 f = new Form6();
            f.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Close();
            Form8 f = new Form8();
            f.Show();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            this.Close();
            Form7 f = new Form7();
            f.Show();
        }

        private void completeBookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            this.Close();
            Form9 f = new Form9();
            f.Show();
        }

        private void issuedReturnBooksSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Close();
            Form10 f = new Form10();
            f.Show();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel13_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel14_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            bunifuLabel13.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
