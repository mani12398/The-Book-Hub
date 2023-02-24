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
using System.Threading;

namespace The_Book_Hub
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2TextBox1.Focus();
            guna2TextBox1.Select();

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(bunifuRadioButton2.Checked == true)
            {
                this.Hide();
                Form11 f = new Form11();
                f.Show();
                
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True");
                con.Open();
                string query = "select * from LoginTable where Username='" + guna2TextBox1.Text.Trim() + "' and Pass ='" + guna2TextBox3.Text.Trim() + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable ds = new DataTable();
                da.Fill(ds);

                if (guna2TextBox1.Text == "" || guna2TextBox3.Text == "")
                {
                    System.Media.SystemSounds.Beep.Play();
                    MessageBox.Show("Please Enter Username & Password", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    guna2TextBox1.Focus();
                    return;
                }
                else
                {
                    if (ds.Rows.Count == 1)
                    {
                        this.Hide();
                        Form2 f = new Form2();
                        f.Show();
                    }
                    else
                    {
                        System.Media.SystemSounds.Beep.Play();
                        MessageBox.Show("Invalid Login Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        guna2TextBox1.Focus();

                    }
                }
                guna2TextBox1.Focus();
                guna2TextBox1.Text = string.Empty;
                guna2TextBox3.Text = string.Empty;
                guna2CheckBox1.Checked = false;
                con.Close();
            }
            

            

        }

        private void guna2TextBox2_MouseEnter(object sender, EventArgs e)
        {
            

        }

        private void guna2TextBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DialogResult res;
            res = MessageBox.Show("Do you want to Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();

            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" && guna2TextBox3.Text == "")
            {
                System.Media.SystemSounds.Beep.Play();
            }
            guna2TextBox1.Focus();
            guna2TextBox1.Clear();
            guna2TextBox3.Clear();
            guna2CheckBox1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked == true)
            {
                guna2TextBox3.UseSystemPasswordChar = false;
            }
            else if(guna2CheckBox1.Checked == false)
            {
                guna2TextBox3.UseSystemPasswordChar = true;

            }
        }

        private void guna2TextBox3_Enter(object sender, EventArgs e)
        {
           
            guna2TextBox3.UseSystemPasswordChar = true;

        }

        private void bunifuRadioButton1_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {
            if (bunifuRadioButton2.Checked == true)
            {
                guna2TextBox1.Enabled = false;
                guna2TextBox3.Enabled = false;
                guna2Button2.Enabled = false;
                guna2CheckBox1.Enabled = false;
            }
            else if (bunifuRadioButton1.Checked == true)
            {
                guna2TextBox1.Enabled = true;
                guna2TextBox3.Enabled = true;
                guna2Button2.Enabled = true;
                guna2CheckBox1.Enabled = true;

            }
        }

        private void bunifuRadioButton2_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        {


        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

