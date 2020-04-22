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
    public partial class stock : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\text\source\repos\library_mgmt_sys\lib1.mdf;Integrated Security=True");
        public stock()
        {
            InitializeComponent();
            string query = "select * from stock";

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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            home obj = new home();
            this.Hide();
            obj.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string query = "select * from stock";

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

        private void Stock_Load(object sender, EventArgs e)
        {

        }
    }
}
