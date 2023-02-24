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
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;

namespace The_Book_Hub
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            bunifuTextBox2.Focus();
            bunifuTextBox2.Select();

            panel2.Visible = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from NewStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            bunifuDataGridView1.DataSource = ds.Tables[0];
            bunifuLabel3.Text = $"Total Records: {bunifuDataGridView1.RowCount}";
            bunifuDataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Student_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Enrollment_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Department"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Semester"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Contact_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView1.Columns["Email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void Show_Grid_View_Data()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from NewStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            bunifuDataGridView1.DataSource = ds.Tables[0];
        }
        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

            if (bunifuTextBox2.Text!="")
            {
                bunifuLabel1.Visible = false;
                Image image = Image.FromFile("C:/Users/MANI-PC/Desktop/search1.gif");
                pictureBox1.Image = image;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from NewStudent where Enrollment_No like '" + bunifuTextBox2.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                bunifuDataGridView1.DataSource = ds.Tables[0];
                bunifuLabel3.Text = $"Total Records: {bunifuDataGridView1.RowCount}";
                bunifuDataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Student_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Enrollment_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Department"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Semester"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Contact_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                bunifuLabel1.Visible = true;
                Image image = Image.FromFile("C:/Users/MANI-PC/Desktop/search1.gif");
                pictureBox1.Image = image;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from NewStudent";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                bunifuDataGridView1.DataSource = ds.Tables[0];
                bunifuLabel3.Text = $"Total Records: {bunifuDataGridView1.RowCount}";
                bunifuDataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Student_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Enrollment_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Department"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Semester"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Contact_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuDataGridView1.Columns["Email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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
        int Student_ID;
        String Row_ID;
        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if (indexRow >= 0)
            {
                if (bunifuDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    Student_ID = int.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    
                }
            }

            
            panel2.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from NewStudent where Enrollment_No=" + Student_ID + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            
            if (indexRow >= 0)
            {
                Row_ID = ds.Tables[0].Rows[0][0].ToString();

                bunifuTextBox4.Text = ds.Tables[0].Rows[0][1].ToString();
                bunifuTextBox3.Text = ds.Tables[0].Rows[0][2].ToString();
                bunifuTextBox7.Text = ds.Tables[0].Rows[0][3].ToString();
                bunifuTextBox5.Text = ds.Tables[0].Rows[0][4].ToString();
                bunifuTextBox6.Text = ds.Tables[0].Rows[0][5].ToString();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            bunifuTextBox2.Clear();
            panel2.Visible = false;
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Date will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                System.Media.SystemSounds.Beep.Play();
                String Student_Name = bunifuTextBox4.Text;
                String Department = bunifuTextBox3.Text;
                String Semester = bunifuTextBox7.Text;
                String Contact_No = bunifuTextBox5.Text;
                String Email = bunifuTextBox6.Text;

                var Email1 = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$+";

                if (!Regex.IsMatch(bunifuTextBox6.Text, Email1))
                {
                    System.Media.SystemSounds.Beep.Play();
                    MessageBox.Show("Please Provide Valid Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bunifuTextBox6.Focus();
                    bunifuTextBox6.Text = string.Empty;
                }
                else
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "update NewStudent set Student_Name='" + Student_Name + "',Department='" + Department + "',Semester='" + Semester + "',Contact_No='" + Contact_No + "',Email='" + Email + "' where Enrollment_No = '" + Row_ID + "'";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    Show_Grid_View_Data();
                    panel2.Visible = false;
                    bunifuLabel3.Text = $"Total Records: {bunifuDataGridView1.RowCount}";
                }

                


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
                cmd.CommandText = "delete from NewStudent where Enrollment_No=" + Row_ID + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Show_Grid_View_Data();
                panel2.Visible = false;
                bunifuLabel3.Text = $"Total Records: {bunifuDataGridView1.RowCount}";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void bunifuTextBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bunifuTextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void bunifuTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void bunifuTextBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
            worksheet.Name = "Students Details";

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
            saveFileDialoge.FileName = "Students Details";
            saveFileDialoge.DefaultExt = "xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }
    }
}
