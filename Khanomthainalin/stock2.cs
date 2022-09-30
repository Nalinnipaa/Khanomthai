using MySql.Data.MySqlClient;
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
    public partial class stock2 : Form
    {
        MySqlConnection conn_ = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=khanomthinalin;");
        public static string menu2 = "";
        public static string quanitity2 = "";
        public static string price2 = "";


        private void data()  
        {
           
            DataSet ds = new DataSet();
            conn_.Open();

            MySqlCommand cmd_;
            cmd_ = conn_.CreateCommand();
            cmd_.CommandText = "SELECT * FROM menu";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd_);
            adapter.Fill(ds);
            conn_.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }
        public stock2()
        {
            InitializeComponent();
            data();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
         //id menu quan price   
            dataGridView1.CurrentRow.Selected = true;
            int select = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[select].Cells["id"].FormattedValue.ToString());
            string menu = dataGridView1.Rows[select].Cells["menu"].FormattedValue.ToString();
            int quantity = Convert.ToInt32(dataGridView1.Rows[select].Cells["quantity"].FormattedValue.ToString());
            int price = Convert.ToInt32(dataGridView1.Rows[select].Cells["price"].FormattedValue.ToString());

            textBox1.Text = menu.ToString();
            textBox2.Text = quantity.ToString();
            textBox3.Text = price.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("ต้องการเพิ่มหรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                MySqlConnection conn_ = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=khanomthinalin;");
                String sql = "INSERT INTO  menu(menu,quantity,price) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn_);

                conn_.Open();

                int rows = cmd.ExecuteNonQuery();

                conn_.Close();
                MessageBox.Show("เพิ่มข้อมูลเรียบร้อยแล้ว");
                data();
            }
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            stock stock = new stock();
            stock.Show();
            this.Hide();
        }
        
        private void editData(int id, string เมนู, string จำนวน, string ราคา) 
        {
            string sql = $"UPDATE  menu SET menu='{เมนู}',quantity='{จำนวน}', price = '{ราคา}' WHERE id='{id}'";
            MySqlCommand cmd = new MySqlCommand(sql, conn_);
            conn_.Open();
            int row = cmd.ExecuteNonQuery();
            conn_.Close();
            if (row > 0)
            {
                menu2 = เมนู;
                quanitity2 = จำนวน;
                price2 = ราคา;
                MessageBox.Show("แก้ไขข้อมูลเรือบร้อย");
                //ShowEquiment();
                data();

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("ต้องการแก้ไขหรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                dataGridView1.CurrentRow.Selected = true;
                int selectedRow = dataGridView1.CurrentCell.RowIndex;
                int ID = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["ID"].FormattedValue.ToString());
                string เมนู = textBox1.Text;
                string จำนวน = textBox2.Text;
                string ราคา = textBox3.Text;
                editData(ID, เมนู, จำนวน, ราคา);
                MessageBox.Show("แก้ไขข้อมูลเรียบร้อยแล้ว");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("ต้องการลบหรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                string sql = $"DELETE FROM menu WHERE menu = '{textBox1.Text}'and price = '{textBox3.Text}' ";
                MySqlCommand cmd = new MySqlCommand(sql, conn_);
                conn_.Open();
                int row = cmd.ExecuteNonQuery();
                conn_.Close();
                if (row > 0)
                {

                    MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว");
                    //ShowEquiment();
                    data();

                }
            }
            
        }

       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
