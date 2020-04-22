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
    public partial class Delete : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\text\source\repos\library_mgmt_sys\lib1.mdf;Integrated Security=True");
        public Delete()
        {
            InitializeComponent();
        }
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
        private string s1;
        public string S1
        {
            get
            {
                return s1;
            }
            set
            {
                s1= value;
            }
        }
        private int n;
        public int N
        {
            get
            {
                return n;
            }
            set
            {
                n = value;
            }
        }
        private int n1;
        public int N1
        {
            get
            {
                return n1;
            }
            set
            {
                n1 = value;
            }
        }
        private string s0;
        public string S0
        {
            get
            {
                return s0;
            }
            set
            {
                s0 = value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string str0;
            con.Open();
            string query0 = "select status from book_details where bid= '" + textBox1.Text + "'";
            SqlCommand cmd0 = new SqlCommand(query0, con);
            SqlDataReader dr0 = cmd0.ExecuteReader();
            if (dr0.Read())
            {
                str0 = (dr0["status"].ToString());
                S0= str0;
            }
            con.Close();
            if (string.Compare(s0,"available")==0)
            {
                string str;
                con.Open();
                string query = "select title_name from book_details where bid= '" + textBox1.Text + "'";
                SqlCommand cmd2 = new SqlCommand(query, con);
                SqlDataReader dr = cmd2.ExecuteReader();
                if (dr.Read())
                {
                    str = (dr["title_name"].ToString());
                    S = str;
                }
                con.Close();
                string str1;
                con.Open();
                string query1 = "select subject_name from sub_book where book_title= '" + s + "'";
                SqlCommand c1 = new SqlCommand(query1, con);
                SqlDataReader dr1 = c1.ExecuteReader();
                if (dr1.Read())
                {
                    str1 = (dr1["subject_name"].ToString());
                    S1 = str1;
                }
                con.Close();
                SqlCommand cmd = new SqlCommand("delsp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bid", textBox1.Text);
                cmd.Parameters.AddWithValue("@title", s);
                cmd.Parameters.AddWithValue("@sub", s1);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("DELETED SUCCESSFULLY!!!");
                }
                catch (SqlException err)
                {
                    MessageBox.Show("Invalid\n" + err);
                }
                con.Close();
                string str2;
                string q = "select no_of_copies from sub_book where book_title='" + s + "'";
                SqlCommand c = new SqlCommand(q, con);
                con.Open();
                SqlDataReader d = c.ExecuteReader();

                if (d.Read())
                {
                    str2 = (d["no_of_copies"].ToString());
                    N = Convert.ToInt32(str2);
                }
                con.Close();
                if (n == 0)
                {
                    SqlCommand cmd1 = new SqlCommand("deletesp", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@title", s);
                    con.Open();
                    try
                    {
                        cmd1.ExecuteNonQuery();
                    }
                    catch (SqlException err1)
                    {
                        MessageBox.Show("INVALID\n" + err1);
                    }
                    con.Close();
                }
                string str3;
                string q1 = "select no_of_copies from stock where sub='" + s1 + "'";
                SqlCommand c2 = new SqlCommand(q1, con);
                con.Open();
                SqlDataReader d1 = c2.ExecuteReader();
                if (d1.Read())
                {
                    str3 = (d1["no_of_copies"].ToString());
                    N1 = Convert.ToInt32(str3);
                }
                con.Close();
                if (n1 == 0)
                {
                    SqlCommand cmd1 = new SqlCommand("deletesp1", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@sub", s1);
                    con.Open();
                    try
                    {
                        cmd1.ExecuteNonQuery();
                    }
                    catch (SqlException err1)
                    {
                        MessageBox.Show("INVALID\n" + err1);
                    }
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("BOOK IS NOT AVAILABLE!!!!!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            home obj = new home();
            this.Hide();
            obj.Show();
        }

        private void Delete_Load(object sender, EventArgs e)
        {

        }
    }
}
