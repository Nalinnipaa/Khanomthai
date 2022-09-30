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
    public partial class menu_ : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=khanomthinalin;");
        public static int Price = 0;
        public static int number = 0;
        public static int orderID = 0;

        public menu_() 
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

            home home = new home();
            home.Show();
            this.Close();
            //basket basket = new basket();
            //basket.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            home home = new home();
            home.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menu_Load(object sender, EventArgs e)
        {

            string sql = $"SELECT * FROM `ตะกร้า`"; 
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<int> list = new List<int>();
            while (reader.Read())
            {
                list.Add(reader.GetInt32("orderid"));
            }

            conn.Close();

            int listlength = list.Count();
            if (listlength > 0)
            {
                orderID = list[listlength - 1] + 1;
            } else
            {
                orderID = 0;
            }
            /*
            foreach (string i in list)
            {
                comboBox1.Items.Add(i);
            }*/
            database();
            calSumPrice();
            label7();
            showstock();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private DataTable mainTable = new DataTable();
        private void showstock()
        {
            
            DataTable dt = new DataTable();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM menu";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            mainTable = dt;
            conn.Close();

            dataGridView1.DataSource = dt;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Menu"].FormattedValue.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();

            int Price = int.Parse(textBox3.Text); 
            int number = Convert.ToInt32(numericUpDown1.Value);
            int outcome;
            outcome = Price * number;
            totalprice.Text = outcome.ToString();
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=khanomthinalin;charset=utf8;";

            MySqlConnection conn = new MySqlConnection(connectionString);
            int selectedRow = dataGridView1.CurrentCell.RowIndex; 

            int id = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["ID"].FormattedValue.ToString());
            string sql = "SELECT quantity FROM menu WHERE id = '" + id + "'";
            conID = id.ToString();   
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            int quantity = dr.GetInt32("quantity");  
            if (quantity > 0)
            {
                numericUpDown1.Maximum = quantity;  
                numericUpDown1.Minimum = 1;
                numericUpDown1.Value = 1;
                button3.Enabled = true;
            } else
            {
                numericUpDown1.Maximum = 1;  
                numericUpDown1.Minimum = 1;
                numericUpDown1.Value = 1;
                button3.Enabled = false;
            }

            conn.Close();

            if (quantity >= numericUpDown1.Value) 
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int Price = int.Parse(textBox3.Text);  
            int number = Convert.ToInt32(numericUpDown1.Value);
            int outcome;
            outcome = Price * number;
            totalprice.Text = outcome.ToString();
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=khanomthinalin;charset=utf8;";

            MySqlConnection conn = new MySqlConnection(connectionString);
            int selectedRow = dataGridView1.CurrentCell.RowIndex;

            int id = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["ID"].FormattedValue.ToString());
            string sql = "SELECT quantity FROM menu WHERE id = '" + id + "'";
            conID = id.ToString();   
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            int quantity = dr.GetInt32("quantity");

            conn.Close();

            if (numericUpDown1.Value == 0) button3.Enabled = false; 
            if (quantity >= numericUpDown1.Value)  
            
                {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label7()
        {
            DataTable dt_ = new DataTable();
            conn.Open();

            MySqlCommand cmd_;

            cmd_ = conn.CreateCommand();
            cmd_.CommandText = "SELECT * FROM ตะกร้า WHERE username ='" + login3.username + "' AND orderid = '"+orderID+"'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd_); 
            adapter.Fill(dt_);
            mainTable = dt_;
            conn.Close();

            dataGridView2.DataSource = dt_;
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
   
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void updatestock(string menu, int amount)
        {
            string sql = "SELECT quantity FROM menu WHERE Menu = '" + menu + "'"; 
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int quantity = dr.GetInt32("quantity");
            conn.Close();

            sql = "UPDATE menu SET quantity = '" + (quantity + amount) + "' WHERE Menu = '" + menu + "'";
            cmd = new MySqlCommand(sql, conn);  
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //login3.username = "sss";   
            sumPrice = sumPrice + Convert.ToInt32(totalprice.Text);
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=khanomthinalin;charset=utf8;";

            string sql = "INSERT INTO ตะกร้า (Menu,price,quantity,Username,สถานะ,orderid,เวลา) VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + numericUpDown1.Value + "','" + login3.username + "','0','"+orderID+"','"+ System.DateTime.Now.ToString("dd/MM/yyyy ") + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();


            updatestock(textBox2.Text, (-Convert.ToInt32(numericUpDown1.Value))); 

            textBox6.Text = (Convert.ToInt32(textBox6.Text) + numericUpDown1.Value).ToString();
            textBox5.Text = (Convert.ToInt32(textBox5.Text) + Convert.ToInt32(totalprice.Text)).ToString();

            showstock();
            label7();


        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM menu WHERE Menu LIKE '%"+textBox1.Text+"%'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            mainTable = dt;
            conn.Close();

            dataGridView1.DataSource = dt; 
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }


        private string conID;
        private void button4_Click(object sender, EventArgs e) 
        {
            int selectedRow = dataGridView2.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView2.Rows[selectedRow].Cells["ID"].FormattedValue.ToString());
            int price = Convert.ToInt32(dataGridView2.Rows[selectedRow].Cells["price"].FormattedValue.ToString());
            int quan = Convert.ToInt32(dataGridView2.Rows[selectedRow].Cells["quantity"].FormattedValue.ToString());
            string sql = "SELECT quantity FROM ตะกร้า WHERE id = '" + id + "'";
            conID = id.ToString();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
           
                int quantity = dr.GetInt32("quantity");
       
            conn.Close();

             sql = "DELETE FROM ตะกร้า WHERE id = '" + id + "'"; 
             cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                MessageBox.Show("ลบสินค้าออกจากตะกร้าแล้ว"); 
                updatestock(textBox2.Text, quantity);

                textBox6.Text = (Convert.ToInt32(textBox6.Text) - quantity).ToString();
                textBox5.Text = (Convert.ToInt32(textBox5.Text) - (price*quan)).ToString();

                label7();
                showstock();
            }

        }

        private DataTable mainTableCart = new DataTable();
        private void database()  
        {
            conn.Open();
            DataTable dt = new DataTable();
            string sql = $"SELECT * FROM `ตะกร้า` WHERE Username = '{login3.username}' AND orderid = '{orderID}'";
            var cmd = new MySqlCommand(sql, conn);
            new MySqlDataAdapter(cmd).Fill(dt);
            mainTableCart = dt;
            conn.Close();
            
        }
        private int sumPrice = 0;
        private void calSumPrice()
        {
            /*
            for (int i = 0; i < mainTableCart.Rows.Count; i++)
            {
                sumPrice = sumPrice + Convert.ToInt32(mainTableCart.Rows[i][2]);
                //MessageBox.Show(mainTableCart.Rows[i][2].ToString());
            }
            //MessageBox.Show(mainTableCart.Rows[1][2].ToString());
            textBox6.Text = sumPrice.ToString();*/
        }
        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }

        }

        private void button5_Click_1(object sender, EventArgs e) 
        {
            try
            {
                int xx = (Convert.ToInt32(textBox4.Text) - Convert.ToInt32(textBox5.Text));
                if (xx >= 0)
                {
                    textBox7.Text = $"{xx}";
                }
                else
                {
                    textBox7.Text = $"เหลืออีก {xx}";
                }
            }
            catch
            {

            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Khanomthailnalin", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new Point(268, 40));
            e.Graphics.DrawString("วันที่   " + System.DateTime.Now.ToString("dd/MM/yyyy "), new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(570, 128));
            e.Graphics.DrawString("เวลา   " + System.DateTime.Now.ToString("HH : mm : ss น."), new Font("TH SarabunPSK", 16, FontStyle.Bold), Brushes.Black, new PointF(571, 145));
            e.Graphics.DrawString("     ที่อยู่ร้าน :Khanomthailnalin ", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new Point(45, 80));
            e.Graphics.DrawString("     บ้านเลขที่ 555 หมู่ 4 ตำบล หนองสิม  ", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new Point(45, 110));
            e.Graphics.DrawString("     อำเภอบรบือ จังหวัดมหาสารคาม 44130", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new Point(45, 140));

            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(0, 150));
            e.Graphics.DrawString("ชื่อสินค้า", new Font("TH SarabunPSK", 17, FontStyle.Bold), Brushes.Black, new PointF(155, 170));
            e.Graphics.DrawString("จำนวน", new Font("TH SarabunPSK", 17, FontStyle.Bold), Brushes.Black, new PointF(664, 170));
            e.Graphics.DrawString("ราคา", new Font("TH SarabunPSK", 17, FontStyle.Bold), Brushes.Black, new PointF(740, 170));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(0, 175));
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=khanomthinalin;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            string sql = "SELECT * FROM ตะกร้า WHERE orderid='" + orderID + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            List<string> item = new List<string>();
            MySqlDataReader reader = cmd.ExecuteReader();
            int y = 250;
            while (reader.Read()) 
                {
                item.Add(reader.GetString(2));
                e.Graphics.DrawString(reader.GetString(2), new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(155, y));
                e.Graphics.DrawString(reader.GetString(4), new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(664, y));
                e.Graphics.DrawString(reader.GetString(3), new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(740, y));
                y += 25;
            }
            conn.Close();

            /*
            int y2 = 250;
            foreach (string i in item)
            {
                sql = "SELECT * FROM menu WHERE Menu='" + i + "'";
                cmd = new MySqlCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MessageBox.Show(i + " " + reader.GetString(0));
                    e.Graphics.DrawString(reader.GetString(0), new Font("TH SarabunPSK", 15, FontStyle.Bold), Brushes.Black, new PointF(30, y2));
                    y2 += 25;
                }
                conn.Close();
            }
            */


            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(0, y + 20));
            e.Graphics.DrawString("รวมทั้งสิ้น  "+textBox5.Text+"    บาท", new Font("TH SarabunPSK", 17, FontStyle.Regular), Brushes.Black, new Point(312, y+45));
            e.Graphics.DrawString("จ่ายเงิน      " + textBox4.Text + "   บาท", new Font("TH SarabunPSK", 17, FontStyle.Regular), Brushes.Black, new Point(312, ((y - 10) + 45) + 45));
            e.Graphics.DrawString("เงินทอน    " + textBox7.Text + "    บาท", new Font("TH SarabunPSK", 17, FontStyle.Regular), Brushes.Black, new Point(312, (((y - 20) + 45) + 45) + 45));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(0, ((((y - 10) + 45) + 45) + 45) + 10));
            e.Graphics.DrawString(" ขอบคุณที่ใช้บริการค่ะ  ", new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new Point(275, ((((y + 10) + 45) + 45) + 45) + 10));
        }
    }
}
