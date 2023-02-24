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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Issue_Book where Book_Return_Date is null";
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            bunifuDataGridView1.DataSource = ds1.Tables[0];
            bunifuLabel3.Text = $"Total Records: {bunifuDataGridView1.RowCount}";
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

            cmd.CommandText = "select *,datediff(dd,Book_Issue_Date,Book_Return_Date) as Days,case when datediff(dd,Book_Issue_Date,Book_Return_Date) > 15 then 'Fine Rs 30' else '' end as Fine from Issue_Book where Book_Return_Date is not null";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            bunifuDataGridView2.DataSource = ds2.Tables[0];
            bunifuLabel4.Text = $"Total Records: {bunifuDataGridView2.RowCount}";
            bunifuDataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView2.Columns["Student_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView2.Columns["Enrollment_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView2.Columns["Department"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView2.Columns["Semester"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView2.Columns["Contact_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView2.Columns["Email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView2.Columns["Book_Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView2.Columns["Book_ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView2.Columns["Book_Issue_Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView2.Columns["Book_Return_Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView2.Columns["Days"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView2.Columns["Fine"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bunifuDataGridView2.Columns["Fine"].DefaultCellStyle.BackColor = Color.Red;

            

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
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

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Books Issued";

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
            saveFileDialoge.FileName = "Books Issued";
            saveFileDialoge.DefaultExt = "xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Books Return";

            for (int i = 1; i < bunifuDataGridView2.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = bunifuDataGridView2.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < bunifuDataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < bunifuDataGridView2.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = bunifuDataGridView2.Rows[i].Cells[j].Value.ToString();

                }
            }

            var saveFileDialoge = new SaveFileDialog();
            saveFileDialoge.FileName = "Books Return";
            saveFileDialoge.DefaultExt = "xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            }

            app.Quit();
            
           
            
            
        }
    }
}
