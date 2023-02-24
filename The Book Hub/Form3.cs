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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            bunifuTextBox6.Focus();
            bunifuTextBox6.Select();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String Book_ID = bunifuTextBox6.Text;
            String Book_Name = bunifuTextBox1.Text;
            String Book_Author_Name = bunifuTextBox2.Text;
            String Book_Publication = bunifuTextBox3.Text;
            String Book_Purchase_Date = guna2DateTimePicker1.Text;
            String Book_Price = bunifuTextBox5.Text;
            String Book_Quantity = bunifuTextBox4.Text;

            if (bunifuTextBox6.Text == "" || bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox3.Text == "" || bunifuTextBox4.Text == "" || bunifuTextBox5.Text == "") 
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Enter Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBox1.Focus();
                return;

            }
            else
            {
                if(check_Book_ID())
                {
                    System.Media.SystemSounds.Beep.Play();
                    MessageBox.Show("Book ID Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bunifuTextBox1.Focus();
                }
                else
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into NewBook (Book_ID,Book_Name,Book_Author_Name,Book_Publication,Book_Purchase_Date,Book_Price,Book_Quantity) values ('" + Book_ID + "','" + Book_Name + "','" + Book_Author_Name + "','" + Book_Publication + "','" + Book_Purchase_Date + "'," + Book_Price + "," + Book_Quantity + ")";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Books Saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Media.SystemSounds.Beep.Play();

                }
            }
            

            

            bunifuTextBox1.Clear();
            bunifuTextBox2.Clear();
            bunifuTextBox3.Clear();
            bunifuTextBox5.Clear();
            bunifuTextBox4.Clear();
            bunifuTextBox6.Clear();


        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DialogResult res;
            res = MessageBox.Show("Do you want to Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Close();
                Form2 f =new Form2();
                f.Show();
            }
            else
            {
                this.Show();
            }
            

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_KeyDown(object sender, KeyEventArgs e)
        {

            
        }

        private void bunifuTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bunifuTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        bool check_Book_ID()
        {
            Boolean Book_ID = false;
            string mycon = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            string myquery = "Select * from NewBook where Book_ID='" + bunifuTextBox6.Text + "'";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Book_ID = true;
            }
            
            con.Close();
            return Book_ID;

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

            if (bunifuTextBox3.Text.Trim() == String.Empty)
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            bunifuTextBox1.Clear();
            bunifuTextBox2.Clear();
            bunifuTextBox3.Clear();
            bunifuTextBox4.Clear();
            bunifuTextBox5.Clear();
            bunifuTextBox6.Clear();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

           

        }

        private void guna2DateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
