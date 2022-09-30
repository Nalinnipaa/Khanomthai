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
    public partial class record : Form
    {
        public record()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            Form9_cooo();
        }

        string sql, monts, monts_2;

        private void Form9_cooo() 
        {
            string date = dateTimePicker1.Value.ToString("dd/MM/yyyy"); 
            if (checkBox1.Checked)
            {
                if (comboBox4.Text == "ทั้งหมด") 
                {
                    sql = "SELECT * FROM ตะกร้า WHERE เวลา like '" + "%" + date + "%" + "'";
                }
                else
                {
                    sql = "SELECT * FROM ตะกร้า WHERE orderid = '" + comboBox4.Text + "' and เวลา like '" + "%" + date + "%" + "' ";

                }
            } else
            {
                if (comboBox4.Text == "ทั้งหมด") 
                {
                    sql = "SELECT * FROM ตะกร้า";
                }
                else
                {
                    sql = "SELECT * FROM ตะกร้า WHERE orderid = '" + comboBox4.Text + "'";

                }
            }
            
        
            MySqlConnection conn_ = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=khanomthinalin;charset=utf8;");
            DataSet ds = new DataSet();
            conn_.Open();

            MySqlCommand cmd_;
            cmd_ = conn_.CreateCommand();
            cmd_.CommandText = sql;

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd_);
            adapter.Fill(ds);
            conn_.Close();
            dataGridView2.DataSource = ds.Tables[0];



            MySqlConnection conn = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=khanomthinalin;charset=utf8;");
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            int x = 0, y = 0;

            while (reader.Read())  
            {
                x += reader.GetInt32(3);
                y += reader.GetInt32(4);

            }
            label20.Text = $"{x}";
            label14.Text = $"{y}";




        }
        private void Form9_GM()
        {


        }
        private void Form9_Shown(object sender, EventArgs e)
        {

            string p="-1";  
            sql = "SELECT * FROM ตะกร้า ";
            comboBox4.Items.Clear();
            comboBox4.Items.Add("ทั้งหมด");
            MySqlConnection conn = new MySqlConnection("datasource = 127.0.01;port=3306;username=root;password=;database=khanomthinalin;charset=utf8;");
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if(reader.GetString(1) != p) 
                {
                    comboBox4.Items.Add(reader.GetString(1));
                    p = reader.GetString(1);
                }
                

            }
            /*comboBox2.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            ssssss = comboBox4.Text;
            Form9_cooo();*/

        }
        string ssssss;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            home home = new home();
            home.Show();
            this.Hide();
            //new Form5().Show();
            //this.Hide();
        }



        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ssssss = comboBox4.Text;
            Form9_cooo();
        }

      

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Form9_cooo();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //new Form10().Show();
            //this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) 
        {
            monts = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            Form9_cooo();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) 
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Enabled = true;
                Form9_cooo();
            } else
            {
                dateTimePicker1.Enabled = false;
                Form9_cooo();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login3 login3 = new login3();
            login3.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

    }
}
