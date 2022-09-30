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
    public partial class stock : Form
    {
        public stock()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stock stock = new stock();
            stock.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stock2 stock2 = new stock2();
            stock2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            home home = new home();
            home.Show();
            this.Hide();
        }
    }
}
