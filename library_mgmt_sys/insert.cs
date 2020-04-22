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
namespace library_mgmt_sys
{
    public partial class insert : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\text\source\repos\library_mgmt_sys\lib1.mdf;Integrated Security=True");
        public insert()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from stock where sub='" + textBox1.Text+ "'",con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            if (dt1.Rows[0][0].ToString() == "1")
            {
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from sub_book where book_title ='" + textBox2.Text + "' and author ='" + textBox3.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlCommand cmd = new SqlCommand("insertsp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bid", textBox4.Text);
                    cmd.Parameters.AddWithValue("@title", textBox2.Text);
                    cmd.Parameters.AddWithValue("@author", textBox3.Text);
                    cmd.Parameters.AddWithValue("@sub", textBox1.Text);
                    cmd.Parameters.AddWithValue("@dept", comboBox1.SelectedItem);
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("SUCCESSFULLY INSERTED!!!!!!!");
                        con.Close();
                    }
                    catch (SqlException err)
                    {
                        MessageBox.Show("invalid\n" + err);
                    }
                    con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("bsp1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bid", textBox4.Text);
                    cmd.Parameters.AddWithValue("@title", textBox2.Text);
                    cmd.Parameters.AddWithValue("@author", textBox3.Text);
                    cmd.Parameters.AddWithValue("@r_no", textBox5.Text);
                    cmd.Parameters.AddWithValue("@sub", textBox1.Text);
                    cmd.Parameters.AddWithValue("@dept", comboBox1.SelectedItem);
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("SUCCESSFULLY INSERTED!!!!!!!");
                        con.Close();
                    }
                    catch (SqlException err)
                    {
                        MessageBox.Show("invalid\n" + err);
                    }
                    con.Close();
                }
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("insertsp1", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@bid", textBox4.Text);
                cmd1.Parameters.AddWithValue("@title", textBox2.Text);
                cmd1.Parameters.AddWithValue("@author", textBox3.Text);
                cmd1.Parameters.AddWithValue("@rack_no", textBox5.Text);
                cmd1.Parameters.AddWithValue("@sub", textBox1.Text);
                cmd1.Parameters.AddWithValue("@dept", comboBox1.SelectedItem);
                con.Open();
                try
                {
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("SUCCESSFULLY INSERTED!!!!!!!");
                    con.Close();
                }
                catch (SqlException err)
                {
                    MessageBox.Show("invalid\n" + err);
                }
                con.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            home obj = new home();
            this.Hide();
            obj.Show();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
