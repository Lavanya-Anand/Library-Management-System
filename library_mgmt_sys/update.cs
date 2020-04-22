using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_mgmt_sys
{
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            home obj = new home();
            this.Hide();
            obj.Show();
        }

        private void update_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            insert obj = new insert();
            this.Hide();
            obj.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete obj = new Delete();
            this.Hide();
            obj.Show();
        }
    }
}
