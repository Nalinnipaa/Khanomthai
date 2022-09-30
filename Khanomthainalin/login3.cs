using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Khanomthainalin
{
    public partial class login3 : Form
    {

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=khanomthinalin;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;

        }

        public login3()
        {
            InitializeComponent();
        }

        private bool logincheck(string username, string password)
        {
            MySqlConnection conn = databaseConnection();
            string sql = "SELECT password FROM login WHERE username = '"+username+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();

            string passwordcheck = " ";

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                passwordcheck = reader.GetString("password");
            }

            if (passwordcheck == password)
            {
                return true;
            }
            return false;
        }
        public static string username;
        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            string password = textBox2.Text;
            if (logincheck(username,password))
            {

                home home = new home();
                home.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
