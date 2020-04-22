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
    public partial class reg : Form
    {
        public reg()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\text\source\repos\library_mgmt_sys\lib1.mdf;Integrated Security=True");

        private void reg_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            home obj = new home();
            this.Hide();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("studentsp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@usn", textBox2.Text);
            cmd.Parameters.AddWithValue("@address", textBox3.Text);
            cmd.Parameters.AddWithValue("@phone", textBox4.Text);
            cmd.Parameters.AddWithValue("@email", textBox5.Text);
                
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("SUCCESSFULLY REGISTERED");

            }
            catch (SqlException err)
            {
                MessageBox.Show("invalid sql exception " + err);

            }
            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
