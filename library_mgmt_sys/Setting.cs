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
    public partial class Setting : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\text\source\repos\library_mgmt_sys\lib1.mdf;Integrated Security=True");
        public Setting()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("editsp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("SUCCESSFULLY UPDATED!!!!!");
            }
            catch(SqlException err)
            {
                MessageBox.Show("INVALID\n"+err);
            }
            con.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            home obj = new home();
            this.Hide();
            obj.Show();
        }

        private void Setting_Load(object sender, EventArgs e)
        {

        }
    }
}
