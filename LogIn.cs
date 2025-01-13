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
    public partial class LogIn : Form, Base
    {
        public LogIn()
        {
            InitializeComponent();
        }

        public String username;
        public static int userId;

        public void FindId()
        {
            SqlConnection con = new SqlConnection("Data Source=PRANTO;Initial Catalog=Blood_Mng;Persist Security Info=True;User ID=sa;Password=123456");
            con.Open();
            SqlCommand cmd = new SqlCommand("select id from normal_user where username='" + username + "'", con);


            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int userid = Convert.ToInt32(reader["id"]);
                    userId = userid;

                }
            }
            con.Close();

            //MessageBox.Show("" + userId);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetText();
            
        }
        public void SetText()
        {
            textBox3.Text = "Welcome To Blood Bank management system";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signup sp = new Signup();
            sp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            SqlConnection con = new SqlConnection("Data Source=PRANTO;Initial Catalog=Blood_Mng;Persist Security Info=True;User ID=sa;Password=123456");
            SqlDataAdapter da = new SqlDataAdapter(" SELECT count(*) FROM normal_user WHERE username = '" + username + "' AND password = '" + textBox2.Text + "'", con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                FindId();
                this.Hide();
                Userpanel bd = new Userpanel();
                bd.Show();
                
            }
            else
            {
                MessageBox.Show("Please enter correct username and password");
            }
  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                this.Hide();
                Admin sp = new Admin();
                sp.Show();
            
        }

        
        public void setText(int n)
        {
            throw new NotImplementedException();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
