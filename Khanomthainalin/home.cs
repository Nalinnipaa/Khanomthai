using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Khanomthainalin
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e) 
        {
            menu_ menu = new menu_();
            menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            stock stock = new stock();
            stock.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e) 
        {
            login3 login3 = new login3();
            login3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            record record = new record();
            record.Show();
            this.Hide();
        }
    }
}
