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
    public partial class issue : Form
    {
        
        public issue()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\text\source\repos\library_mgmt_sys\lib1.mdf;Integrated Security=True");
        private string s;
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
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from borrower where MID ='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "2")
            {
                MessageBox.Show("no. of books exceeding!!!!!!");
            }
            else
            {  
              
                SqlCommand cmd = new SqlCommand("borrowersp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usn", textBox1.Text);
                cmd.Parameters.AddWithValue("@bid", textBox2.Text);
                cmd.Parameters.AddWithValue("@doi", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("@dor", DateTime.Today.AddDays(15).Date);
                SqlCommand cmd1 = new SqlCommand("update1sp", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                String s1 = "not avaliable";
                cmd1.Parameters.AddWithValue("@bid", textBox2.Text);
                cmd1.Parameters.AddWithValue("@status", s1);
                string str;
                con.Open();
                string query = "select title_name from book_details where bid= '" + textBox2.Text + "'";
                SqlCommand cmd2 = new SqlCommand(query, con);
                SqlDataReader dr = cmd2.ExecuteReader();
                if (dr.Read())
                {
                    str = (dr["title_name"].ToString());
                    S = str;
                }
                con.Close();
                SqlCommand cmd3 = new SqlCommand("update2sp", con);
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@title_name", s);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("SUCCESSFULLY ISSUED \n Date of Return: "+ DateTime.Today.AddDays(15).Date.ToString());
                    
                 }
                catch 
                {
                    MessageBox.Show("ALREADY ISSUED!!!!!");
                    
                }
                con.Close();
            }
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

        private void Issue_Load(object sender, EventArgs e)
        {

        }
    }
}
