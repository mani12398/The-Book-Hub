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

namespace The_Book_Hub
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            bunifuTextBox2.Focus();
            bunifuTextBox2.Select();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Do you want to Exit", "Exit",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                System.Media.SystemSounds.Beep.Play();
                this.Close();
                Form2 f = new Form2();
                f.Show();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String Student_Name = bunifuTextBox1.Text;
            String Enrollment_No = bunifuTextBox2.Text;
            String Department = bunifuTextBox3.Text;
            String Student_Semester = bunifuTextBox4.Text;
            String Student_Contact = bunifuTextBox5.Text;
            String Student_Email = bunifuTextBox6.Text;

            var Email = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$+";


            if (bunifuTextBox1.Text == "" || bunifuTextBox2.Text == "" || bunifuTextBox3.Text == "" || bunifuTextBox4.Text == "" || bunifuTextBox5.Text == "" || bunifuTextBox6.Text == "")
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Enter Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBox1.Focus();
                return;

            }

            else
            {
                if (check_Enrollment_No())
                {
                    System.Media.SystemSounds.Beep.Play();
                    MessageBox.Show("Student Enrollment No Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bunifuTextBox1.Focus();

                    
                }

                else
                {
                    if (check_Contact_No())
                    {
                        System.Media.SystemSounds.Beep.Play();
                        MessageBox.Show("Student Contact No Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bunifuTextBox1.Focus();
                    }
                    else
                    {
                        if(check_Email())
                        {
                            System.Media.SystemSounds.Beep.Play();
                            MessageBox.Show("Student Email Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            bunifuTextBox1.Focus();
                        }

                        else
                        {
                            if (!Regex.IsMatch(bunifuTextBox6.Text, Email))
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
                                con.Open();
                                cmd.CommandText = "insert into NewStudent (Enrollment_No,Student_Name,Department,Semester,Contact_No,Email) values ('" + Enrollment_No + "','" + Student_Name + "','" + Department + "','" + Student_Semester + "','" + Student_Contact + "','" + Student_Email + "')";
                                cmd.ExecuteNonQuery();
                                con.Close();
                                System.Media.SystemSounds.Beep.Play();
                                MessageBox.Show("Student Saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bunifuTextBox1.Clear();
                                bunifuTextBox2.Clear();
                                bunifuTextBox3.Clear();
                                bunifuTextBox4.Clear();
                                bunifuTextBox5.Clear();
                                bunifuTextBox6.Clear();
                            }
                            
                        }
                       
                        
                    }
                    
                }

                
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

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox7_TextChanged(object sender, EventArgs e)
        {

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
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            
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
            if (bunifuTextBox1.Text.Trim() == String.Empty)
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }


        }

        private void bunifuTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void bunifuTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        bool check_Enrollment_No()
        {
            Boolean Enrollment_No = false;
            string mycon = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            string myquery = "Select * from NewStudent where Enrollment_No='" + bunifuTextBox2.Text + "'";
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
                Enrollment_No = true;
            }

            con.Close();
            return Enrollment_No;

        }

        bool check_Contact_No()
        {
            Boolean Contact_No = false;
            string mycon = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            string myquery = "Select * from NewStudent where Contact_No='" + bunifuTextBox5.Text + "'";
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
                Contact_No = true;
            }

            con.Close();
            return Contact_No;

        }

        bool check_Email()
        {
            Boolean Email = false;
            string mycon = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            string myquery = "Select * from NewStudent where Email='" + bunifuTextBox6.Text + "'";
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
                Email = true;
            }

            con.Close();
            return Email;

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }

    
}
