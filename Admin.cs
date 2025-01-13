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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection("Data Source=PRANTO;Initial Catalog=Blood_Mng;Persist Security Info=True;User ID=sa;Password=123456");
            SqlDataAdapter da = new SqlDataAdapter(" SELECT count(*) FROM admin_user WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'", con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
               
                this.Hide();
                AdminPanel bd = new AdminPanel();
                bd.Show();

            }
            else
            {
                MessageBox.Show("Please enter correct username and password");
            }
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
    }
}
