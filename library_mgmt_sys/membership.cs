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
    public partial class membership : Form
    {
        
        public membership()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\text\source\repos\library_mgmt_sys\lib1.mdf;Integrated Security=True");
        private void membership_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usn = textBox1.Text;
            string query = "select * from borrower where MID ='" + usn + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid sql exception " + ex);
            }
            con.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            home obj = new home();
            this.Hide();
            obj.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        string s;
        public string S
        {
            get
            {
                return s;
            }
            set
            {
                s = value;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string query = "select MID from borrower where Book_id='" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            string str;
            con.Open();
            if (dr.Read())
            {
                str = (dr["MID"].ToString());
                S = str;
            }
            con.Close();
            string query1 = "select * from borrower where MID='" + s + "'";

            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid sql exception " + ex);
            }
            con.Close();
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            home obj = new home();
            this.Hide();
            obj.Show();
        }
    }
}
