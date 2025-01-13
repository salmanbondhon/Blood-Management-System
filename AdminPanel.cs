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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
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
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PRANTO;Initial Catalog=Blood_Mng;Persist Security Info=True;User ID=sa;Password=123456");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE normal_user WHERE id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";

            BindData();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn lg = new LogIn();
            lg.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
