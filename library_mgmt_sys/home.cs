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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e )
        {
            stock obj = new stock();
            this.Hide();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reg obj = new reg();
            this.Hide();
            obj.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            membership mem = new membership();
            this.Hide();
            mem.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            search a = new search();
            this.Hide();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            issue obj = new issue();
            this.Hide();
            obj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           @return obj = new @return();
            this.Hide();
            obj.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            renewal obj = new renewal();
            this.Hide();
            obj.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            update obj = new update();
            this.Hide();
            obj.Show();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Setting obj = new Setting();
            this.Hide();
            obj.Show();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
