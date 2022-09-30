using System; //เรียกใช้เครื่องมอ
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
    public partial class sogin : Form

    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=khanomthinalin;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
            
        }
        public sogin()
        {
            InitializeComponent();
        }
        private bool checknum(string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            foreach (char i in str)
            {
                if (char.IsNumber(i) && char.IsLetter(i) == false)
                {
                    return true;
                }
            }
            return false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checknum(phonenumber.Text) && phonenumber.Text.Length == 10)
            {
                if (checknum(password.Text) && password.Text.Length == 6)
                {
                    if (textBox1.Text == password.Text) 
                    {

                        MySqlConnection conn = databaseConnection();
                        String sql = "INSERT INTO login (Username,name,lasrname,password,phonenumber,address) VALUES('" + textBox2.Text + "','" + neme.Text + "','" + lassname.Text + "','" + password.Text + "','" + phonenumber.Text + "','" + address.Text + "')";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        conn.Open();

                        int rows = cmd.ExecuteNonQuery();

                        conn.Close();

                        MessageBox.Show("บันทึกข้อมูลสำเร็จ");
                        login login = new login();
                        login.Show();
                        this.Hide();
                    } else
                    {
                        //ยืนยันรหัส 
                        MessageBox.Show("รหัสผ่านไม่ตรงกัน");
                    }
                } else
                {
                    //รหัส
                    MessageBox.Show("กรุณากรอกรหัสให้ถูกต้อง");
                }
                
            } else
            {
                //เบอร์
                MessageBox.Show("กรุณากรอกเบอร์โทรศัพท์ให้ถูกต้อง");
            }
            
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void sogin_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void neme_TextChanged(object sender, EventArgs e)
        {

        }

        private void phonenumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void phonenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
