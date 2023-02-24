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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        

        private void Form7_Load(object sender, EventArgs e)
        {

            bunifuTextBox2.Focus();
            bunifuTextBox2.Select();
         

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox7.Text != "") 
            {
                if (bunifuLabel3.Visible == true)
                {
                    System.Media.SystemSounds.Beep.Play();
                    MessageBox.Show("Select Book", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    if (guna2ComboBox1.SelectedIndex != -1 && count <= 2)
                    {


                        String Student_Name = bunifuTextBox7.Text;
                        String Enrollment_No = bunifuTextBox1.Text;
                        String Department = bunifuTextBox3.Text;
                        String Student_Semester = bunifuTextBox4.Text;
                        String Student_Contact = bunifuTextBox5.Text;
                        String Student_Email = bunifuTextBox6.Text;
                        String Book_Name = guna2ComboBox1.Text;
                        String Book_ID = bunifuTextBox8.Text;
                        String Book_Issue_Date = bunifuDatePicker1.Value.ToString();


                        SqlConnection con = new SqlConnection("Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True");
                        string query = "select * from Issue_Book where Book_ID=@Book_ID and Enrollment_No=@Enrollment_No and Book_Return_Date is null";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Book_ID", Book_ID);
                        cmd.Parameters.AddWithValue("@Enrollment_No", Enrollment_No);

                        con.Open();

                        SqlDataReader sdr = cmd.ExecuteReader();

                        if (sdr.HasRows == true)
                        {
                            System.Media.SystemSounds.Beep.Play();
                            MessageBox.Show("Book Already Issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            guna2ComboBox1.Refresh();
                            guna2ComboBox1.Items.Clear();
                            con.Close();
                            bunifuTextBox7.Clear();
                            bunifuTextBox1.Clear();
                            bunifuTextBox3.Clear();
                            bunifuTextBox4.Clear();
                            bunifuTextBox5.Clear();
                            bunifuTextBox6.Clear();
                            bunifuTextBox2.Clear();
                            bunifuTextBox8.Clear();
                            guna2ComboBox1.Text = "";
                            bunifuLabel3.Visible = true;
                        }
                        else
                        {
                            
                            con.Close();
                            
                            con.Open();
                            cmd.CommandText = "insert into Issue_Book (Student_Name,Enrollment_No,Department,Semester,Contact_No,Email,Book_Name,Book_ID,Book_Issue_Date) values ('" + Student_Name + "','" + Enrollment_No + "','" + Department + "','" + Student_Semester + "','" + Student_Contact + "','" + Student_Email + "','" + Book_Name + "','" + Book_ID + "','" + Book_Issue_Date + "')";
                            //cmd.ExecuteNonQuery();
                            
                            int result = cmd.ExecuteNonQuery();
                            if (result == 1)
                            {

                                System.Media.SystemSounds.Beep.Play();
                                MessageBox.Show("Book Successfully Issued", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                con.Close();
                                update_Book();
                                guna2ComboBox1.Refresh();
                                guna2ComboBox1.Items.Clear();
                                bunifuTextBox7.Clear();
                                bunifuTextBox1.Clear();
                                bunifuTextBox3.Clear();
                                bunifuTextBox4.Clear();
                                bunifuTextBox5.Clear();
                                bunifuTextBox6.Clear();
                                bunifuTextBox2.Clear();
                                bunifuTextBox8.Clear();
                                guna2ComboBox1.Text = "";
                                bunifuLabel3.Visible = true;

                            }


                            con.Close();




                        }

                        



                    }

                    else
                    {

                        MessageBox.Show("Maximum Number of Books has been Issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bunifuTextBox7.Clear();
                        bunifuTextBox1.Clear();
                        bunifuTextBox3.Clear();
                        bunifuTextBox4.Clear();
                        bunifuTextBox5.Clear();
                        bunifuTextBox6.Clear();
                        bunifuTextBox2.Clear();
                        bunifuTextBox8.Clear();
                        guna2ComboBox1.Text = "";
                        bunifuLabel3.Visible = true;
                        guna2ComboBox1.Items.Clear();

                    }
                }
                

                



            }
            else
            {
                MessageBox.Show("Enter Enrollment Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            guna2ComboBox1.SelectedItem = bunifuLabel3.Visible = false;
            
            string con = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            string Book_Name = guna2ComboBox1.SelectedItem.ToString();

            using (SqlConnection conn = new SqlConnection(con))
            {

                string text = "select Book_ID from NewBook where Book_Name='" + Book_Name + "'";

                using (SqlCommand cmd1 = new SqlCommand(text, conn))
                {
                    conn.Open();
                    var result = cmd1.ExecuteScalar();
                    bunifuTextBox8.Text = result.ToString();

                }
            }
        }

        int count;
        private void guna2Button3_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand("select Book_Name from NewBook where Book_Quantity>" + 0 + "", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    guna2ComboBox1.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();

            if (bunifuTextBox2.Text == "") 
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Enter Enrollment No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuTextBox2.Focus();
                return;
            }
            else
            {
                if (bunifuTextBox2.Text != "")
                {
                    String Enrollment_No = bunifuTextBox2.Text;
                    SqlConnection con1 = new SqlConnection();
                    con1.ConnectionString = "Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con1;
                    cmd1.CommandText = "select * from NewStudent where Enrollment_No='" + Enrollment_No + "'";
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    cmd1.CommandText = "select count(Enrollment_No) from Issue_Book where Enrollment_No='" + Enrollment_No + "' and BooK_Return_Date is null";
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        bunifuTextBox1.Text = ds.Tables[0].Rows[0][0].ToString();
                        bunifuTextBox7.Text = ds.Tables[0].Rows[0][1].ToString();
                        bunifuTextBox3.Text = ds.Tables[0].Rows[0][2].ToString();
                        bunifuTextBox4.Text = ds.Tables[0].Rows[0][3].ToString();
                        bunifuTextBox5.Text = ds.Tables[0].Rows[0][4].ToString();
                        bunifuTextBox6.Text = ds.Tables[0].Rows[0][5].ToString();
                        
                    }
                    else
                    {
                        


                        MessageBox.Show("Invalid Enrollment Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            }

            
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (bunifuTextBox2.Text == "") 
            {
                bunifuTextBox7.Clear();
                bunifuTextBox1.Clear();
                bunifuTextBox3.Clear();
                bunifuTextBox4.Clear();
                bunifuTextBox5.Clear();
                bunifuTextBox6.Clear();
                bunifuTextBox8.Clear();
                guna2ComboBox1.Text = "";
                bunifuLabel3.Visible = true;
                guna2ComboBox1.Items.Clear();

            }
            

        }

        private void bunifuTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
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

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            bunifuTextBox7.Clear();
            bunifuTextBox1.Clear();
            bunifuTextBox3.Clear();
            bunifuTextBox4.Clear();
            bunifuTextBox5.Clear();
            bunifuTextBox6.Clear();
            bunifuTextBox2.Clear();
            bunifuTextBox8.Clear();
            bunifuLabel3.Visible = true;
            guna2ComboBox1.Text = "";
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

        private void bunifuTextBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2ComboBox1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void update_Book()
        {
            int Book_Quantity;
            int New_Book_Quantity;
            
            SqlConnection con = new SqlConnection("Data Source=MANI-PC;Initial Catalog=Bookhub;Integrated Security=True");
            con.Open();
            string query = "select * from NewBook where Book_Name='" + guna2ComboBox1.SelectedItem.ToString() + "'";
            SqlCommand cmd =new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                Book_Quantity = Convert.ToInt32(dr["Book_Quantity"].ToString());
                New_Book_Quantity = Book_Quantity - 1;
                string query1 = "update NewBook set Book_Quantity=" + New_Book_Quantity + " where Book_Name='" + guna2ComboBox1.SelectedItem.ToString() + "'";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();
            }

            con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
