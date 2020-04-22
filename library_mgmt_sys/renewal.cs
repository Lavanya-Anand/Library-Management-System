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
    public partial class renewal : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\text\source\repos\library_mgmt_sys\lib1.mdf;Integrated Security=True");
        public renewal()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            home obj = new home();
            this.Hide();
            obj.Show();
        }

        private void renewal_Load(object sender, EventArgs e)
        {

        }
        int p1;
        private void Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "select Date_Of_Return from borrower where Book_id= '" + textBox2.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DateTime d = Convert.ToDateTime(dt.Rows[0][0]);
            TimeSpan dif = DateTime.Now.Date - d;
            con.Close();
            string p = dif.Days.ToString();
            p1 = Convert.ToInt16(p);
            if (p1 == 0)
            {
                MessageBox.Show("NO PENALTY!!!!!!");
            }
            else if (p1 > 0)
            {
                MessageBox.Show("PENALTY:\n RS:" + p1);
            }
            SqlCommand cmd = new SqlCommand("updbsp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bid", textBox2.Text);
            cmd.Parameters.AddWithValue("@dor", DateTime.Today.AddDays(15).Date);
            cmd.Parameters.AddWithValue("@penalty", p1);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("DATE OF RETURN" + DateTime.Today.AddDays(15).Date);
            }
            catch(SqlException err)
            {
                MessageBox.Show("invalid \n"+err);
            }
            con.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (p1 == 0||p1<0)
            {
                MessageBox.Show("NO PENALTY");
            }
            else if (p1 > 0)
            {
                SqlCommand cmd = new SqlCommand("pclearsp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bid", textBox2.Text);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PENALTY CLEARED!!!!!!");
                }
                catch (SqlException err)
                {
                    MessageBox.Show("invalid\n" + err);
                }
                con.Close();
            }
        }
    }
}
