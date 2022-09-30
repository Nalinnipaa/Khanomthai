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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login3 login3=new login3();
            login3.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            sogin sogin = new sogin();
            sogin.Show();
            this.Hide();
        }
    }
}
