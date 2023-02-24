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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            bunifuTextBox2.Focus();
            bunifuTextBox2.Select();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Book_ID,Book_Name,Book_Author_Name,Book_Publication from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            bunifuDataGridView1.DataSource = ds.Tables[0];
            bunifuLabel1.Text = $"Total Records: {bunifuDataGridView1.RowCount}";
            bunifuDataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Book_ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Book_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Book_Author_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Book_Publication"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
        }

        private void label2_Click(object sender, EventArgs e)
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

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (bunifuTextBox2.Text != "")
            {
                bunifuLabel4.Visible = false;
                Image image = Image.FromFile("C:/Users/MANI-PC/Desktop/search1.gif");
                pictureBox2.Image = image;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select Book_ID,Book_Name,Book_Author_Name,Book_Publication from NewBook where Book_Name like '" + bunifuTextBox2.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                bunifuDataGridView1.DataSource = ds.Tables[0];
                bunifuLabel1.Text = $"Total Records: {bunifuDataGridView1.RowCount}";
                bunifuDataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Author_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Publication"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                bunifuLabel4.Visible = true;
                Image image = Image.FromFile("C:/Users/MANI-PC/Desktop/search1.gif");
                pictureBox2.Image = image;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select Book_ID,Book_Name,Book_Author_Name,Book_Publication from NewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                bunifuDataGridView1.DataSource = ds.Tables[0];
                bunifuLabel1.Text = $"Total Records: {bunifuDataGridView1.RowCount}";
                bunifuDataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Author_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Publication"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || (Keys)e.KeyChar == Keys.Space || (Keys)e.KeyChar == Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }


            if (bunifuTextBox2.Text.Trim() == String.Empty)
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Bitmap imagebmp = new Bitmap(bunifuDataGridView1.Width, bunifuDataGridView1.Height);
            //bunifuDataGridView1.DrawToBitmap(imagebmp, new Rectangle(0,0, bunifuDataGridView1.Width, bunifuDataGridView1.Height));
            //e.Graphics.DrawImage(imagebmp, 120, 20);
        }
    }
}
