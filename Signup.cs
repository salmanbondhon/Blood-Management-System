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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=PRANTO;Initial Catalog=Blood_Mng;Persist Security Info=True;User ID=sa;Password=123456");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO normal_user(name,username,password,age,phone,blood,gender,address) VALUES(@name, @username, @password, @age, @phone, @blood, @gender, @address)", con);

                String name = textBox1.Text;

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@username", textBox2.Text);
                cmd.Parameters.AddWithValue("@password", textBox3.Text);
                cmd.Parameters.AddWithValue("@age", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@phone", textBox5.Text);
                cmd.Parameters.AddWithValue("@blood", comboBox1.Text);
                cmd.Parameters.AddWithValue("@gender", comboBox2.Text);
                cmd.Parameters.AddWithValue("@address", comboBox3.Text);
                if (name == "" || name.StartsWith("_"))
                {
                    MessageBox.Show("Insert a valid name!");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    con.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    MessageBox.Show("Your account has been created. ");


                    //this.Hide();
                    //UserLogIn userPanel = new UserLogIn();
                    //userPanel.Show();
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Exception found! Please Enter valid data!");
            }
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn lg = new LogIn();
            lg.Show();

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
