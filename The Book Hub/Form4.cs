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
using Microsoft.Office.Interop.Excel;

namespace The_Book_Hub
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public void Show_Grid_View_Data()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            bunifuDataGridView1.DataSource = ds.Tables[0];
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            bunifuTextBox1.Focus();
            bunifuTextBox1.Select();

            panel2.Visible = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds=new DataSet();
            da.Fill(ds);
            
            bunifuDataGridView1.DataSource = ds.Tables[0];
            bunifuLabel2.Text = $"Total Records: {bunifuDataGridView1.RowCount}";
            bunifuDataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Book_ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Book_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Book_Author_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Book_Publication"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Book_Purchase_Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Book_Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Book_Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }
        int Book_ID;
        String Row_ID;
        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int indexRow = e.RowIndex;
            if (indexRow >= 0)
            {
                if (bunifuDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    Book_ID = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                   
                }

            }
            
           
            panel2.Visible = true;


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from NewBook where Book_ID=" + Book_ID + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (indexRow >= 0)
            {
                Row_ID = ds.Tables[0].Rows[0][0].ToString();
                bunifuTextBox2.Text = ds.Tables[0].Rows[0][1].ToString();
                bunifuTextBox10.Text = ds.Tables[0].Rows[0][2].ToString();
                bunifuTextBox3.Text = ds.Tables[0].Rows[0][3].ToString();
                bunifuTextBox8.Text = ds.Tables[0].Rows[0][4].ToString();
                bunifuTextBox5.Text = ds.Tables[0].Rows[0][5].ToString();
                bunifuTextBox7.Text = ds.Tables[0].Rows[0][6].ToString();
            }
               

            

        }

        private void bunifuTextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
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

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text != "") 
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from NewBook where Book_Name like '" + bunifuTextBox1.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                bunifuDataGridView1.DataSource = ds.Tables[0];
                bunifuLabel2.Text = $"Total Records: {bunifuDataGridView1.RowCount}";
                bunifuDataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Author_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Publication"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Purchase_Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from NewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                bunifuDataGridView1.DataSource = ds.Tables[0];
                bunifuLabel2.Text = $"Total Records: {bunifuDataGridView1.RowCount}";
                bunifuDataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Author_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Publication"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Purchase_Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Book_Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            
        }

        private void bunifuTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void bunifuDataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            bunifuTextBox1.Clear();
            panel2.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Date will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                System.Media.SystemSounds.Beep.Play();
                String Book_Name = bunifuTextBox2.Text;
                String Book_Author_Name = bunifuTextBox10.Text;
                String Book_Publication = bunifuTextBox3.Text;
                String Book_Purchase_Date = bunifuTextBox8.Text;
                Int64 Book_Price = Int64.Parse(bunifuTextBox5.Text);
                Int64 Book_Quantity = Int64.Parse(bunifuTextBox7.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update NewBook set Book_Name='" + Book_Name + "',Book_Author_Name='" + Book_Author_Name + "',Book_Publication='" + Book_Publication + "',Book_Purchase_Date='" + Book_Purchase_Date + "',Book_Price=" + Book_Price + ",Book_Quantity=" + Book_Quantity + " where Book_ID=" + Row_ID + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Show_Grid_View_Data();
                panel2.Visible = false;
                bunifuLabel2.Text = $"Total Records: {bunifuDataGridView1.RowCount}";

            }




        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Date will be Deleted. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                System.Media.SystemSounds.Beep.Play();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from NewBook where Book_ID=" + Row_ID + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Show_Grid_View_Data();
                panel2.Visible = false;
                bunifuLabel2.Text = $"Total Records: {bunifuDataGridView1.RowCount}";

            }

        }

        private void bunifuTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (char.IsLetter(e.KeyChar) || (Keys)e.KeyChar == Keys.Space || (Keys)e.KeyChar == Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            

            if (bunifuTextBox1.Text.Trim() == String.Empty)
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void bunifuTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
             && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            
        }

        private void bunifuTextBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (char.IsLetter(e.KeyChar) || (Keys)e.KeyChar == Keys.Space || (Keys)e.KeyChar == Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            
        }

        private void bunifuTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (char.IsLetter(e.KeyChar) || (Keys)e.KeyChar == Keys.Space || (Keys)e.KeyChar == Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            
        }

        private void bunifuTextBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void bunifuTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bunifuTextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bunifuTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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

        private void bunifuTextBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
          

            if (char.IsLetter(e.KeyChar) || (Keys)e.KeyChar == Keys.Space || (Keys)e.KeyChar == Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void bunifuLabel2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Books Details";

            for (int i = 1; i < bunifuDataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = bunifuDataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < bunifuDataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < bunifuDataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = bunifuDataGridView1.Rows[i].Cells[j].Value.ToString();

                }
            }

            var saveFileDialoge = new SaveFileDialog();
            saveFileDialoge.FileName = "Books Details";
            saveFileDialoge.DefaultExt = "xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
