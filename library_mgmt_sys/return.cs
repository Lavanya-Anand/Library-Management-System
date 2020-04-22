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
    public partial class @return : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\text\source\repos\library_mgmt_sys\lib1.mdf;Integrated Security=True");
        public @return()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        int p1;
        private void button1_Click(object sender, EventArgs e)
        {
            if(p1==0 || p1<0)
            {
                MessageBox.Show("NO PENALTY AT ALL");
            }
            else if(p1>0)
            {
                MessageBox.Show("PENALTY CLEARED");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            home obj = new home();
            this.Hide();
            obj.Show();
        }

        private void return_Load(object sender, EventArgs e)
        {

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

        private void Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "select Date_Of_Return from borrower where MID = '" + textBox1.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DateTime d = Convert.ToDateTime(dt.Rows[0][0]);
            TimeSpan dif= DateTime.Now.Date-d;
            con.Close();
            string p = dif.Days.ToString();
             p1 = Convert.ToInt16(p);
            if(p1==0 || p1<0)
            {
                MessageBox.Show("NO PENALTY!!!!!!");
            }
            else if(p1>0)
            {
                MessageBox.Show("PENALTY:\n RS:" + p1);
            }
            SqlCommand cmd = new SqlCommand("deletersp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bid", textBox1.Text);
            SqlCommand cmd1 = new SqlCommand("bdupsp", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@bid", textBox1.Text);
            string str;
            con.Open();
            string query1 = "select title_name from book_details where bid= '" + textBox1.Text + "'";
            SqlCommand cmd2 = new SqlCommand(query1, con);
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                str = (dr["title_name"].ToString());
                S = str;
            }
            con.Close();
            SqlCommand cmd3 = new SqlCommand("bookupsp", con);
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.AddWithValue("@title_name", s);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();

            }
            catch (SqlException err)
            {
                MessageBox.Show("invalid sql exception " + err);

            }
            con.Close();
        }
    }
}
