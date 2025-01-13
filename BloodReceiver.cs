using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectK
{
    public partial class BloodReceiver : Form
    {
        public BloodReceiver()
        {
            InitializeComponent();
        }

        void BindData()
        {
            SqlConnection con = new SqlConnection("Data Source=PRANTO;Initial Catalog=Blood_Mng;Persist Security Info=True;User ID=sa;Password=123456");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM normal_user", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        
        private void BloodReceiver_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

                SqlConnection con = new SqlConnection("Data Source=PRANTO;Initial Catalog=Blood_Mng;Persist Security Info=True;User ID=sa;Password=123456");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM normal_user WHERE blood = '"+ comboBox1.Text +"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn lg = new LogIn();
            lg.Show();

        }

        void setText(int n)
        {
            MessageBox.Show("Thanks For using our system");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setText(1);
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Userpanel up = new Userpanel();
            up.Show();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Userpanel up = new Userpanel();
            up.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PRANTO;Initial Catalog=Blood_Mng;Persist Security Info=True;User ID=sa;Password=123456");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Normal_user SET request=1 WHERE id='" + textBox1.Text+ "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Request sending to blood donor");

        }

       /* public void SetText()
        {
            throw new NotImplementedException();
        }

        void Base.setText(int n)
        {
            throw new NotImplementedException();
        }*/
    }
}
