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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        public void Show_Grid_View_Data()
        {
            String Enrollment_No = bunifuTextBox2.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Issue_Book where Enrollment_No='" + Enrollment_No + "' and BooK_Return_Date is null";
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            if (ds1.Tables[0].Rows.Count != 0)
            {
                bunifuDataGridView1.DataSource = ds1.Tables[0];
                bunifuLabel2.Text = $"Total Records: {bunifuDataGridView1.RowCount}";
                bunifuDataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Student_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Enrollment_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Department"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Semester"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Contact_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Issue_Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Return_Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            else
            {
                bunifuTextBox2.Clear();
               
            }
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            
            bunifuTextBox2.Focus();
            bunifuTextBox2.Select();
            panel1.Visible = false;
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            String Enrollment_No = bunifuTextBox2.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Issue_Book where Enrollment_No='" + Enrollment_No + "' and BooK_Return_Date is null";
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            if(ds1.Tables[0].Rows.Count != 0)
            {
                bunifuDataGridView1.DataSource = ds1.Tables[0];
                bunifuLabel2.Text = $"Total Records: {bunifuDataGridView1.RowCount}";
                bunifuDataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Student_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Enrollment_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Department"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Semester"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Contact_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Issue_Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Return_Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
            }
            else
            {
                MessageBox.Show("Invalid Enrollment No Or No Book Issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
            if(bunifuTextBox2.Text =="")
            {
                panel1.Visible=false;
                bunifuDataGridView1.DataSource = null;

            }
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DialogResult res;
            res = MessageBox.Show("Do you want to Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Close();
                Form2 f = new Form2();
                f.Show();
            }
            else
            {
                this.Show();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            bunifuTextBox2.Clear();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            String Book_Issue_Date = bunifuDatePicker1.Value.ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update Issue_Book set Book_Return_Date ='" + bunifuDatePicker1.Value.ToString() + "' where Enrollment_No ='" + bunifuTextBox2.Text + "' and Book_ID=" + Row_ID + "";
            cmd.ExecuteNonQuery();
            con.Close();

            
            MessageBox.Show("Book Return", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Media.SystemSounds.Beep.Play();

            Show_Grid_View_Data();
            update_Book();

        }

        String Book_Name;
        String Book_Issue_Date;
        String Row_ID;
        private void bunifuDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Visible = true;
            int indexRow = e.RowIndex;
            if (indexRow >= 0)
            {
                if (bunifuDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    Row_ID = bunifuDataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    Book_Name = bunifuDataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    Book_Issue_Date = bunifuDataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                }

                bunifuTextBox1.Text = Book_Name;
                bunifuTextBox3.Text = Book_Issue_Date;
                bunifuTextBox4.Text = Row_ID;
            }
            
        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            panel1.Visible = false;
            bunifuTextBox2.Clear();
        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }
        void update_Book()
        {
            int Book_Quantity;
            int New_Book_Quantity;

            SqlConnection con = new SqlConnection("Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True");
            con.Open();
            string query = "select * from NewBook where Book_ID='" + bunifuTextBox4.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Book_Quantity = Convert.ToInt32(dr["Book_Quantity"].ToString());
                New_Book_Quantity = Book_Quantity + 1;
                string query1 = "update NewBook set Book_Quantity=" + New_Book_Quantity + " where Book_ID='" + bunifuTextBox4.Text + "'";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();
            }

            con.Close();
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
