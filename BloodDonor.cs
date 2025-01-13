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
    public partial class BloodDonor : Form
    {
        public BloodDonor()
        {
            InitializeComponent();
        }

        public int uId = LogIn.userId;
        void BindData()
        {

            SqlConnection con = new SqlConnection("Data Source=PRANTO;Initial Catalog=Blood_Mng;Persist Security Info=True;User ID=sa;Password=123456");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM normal_user WHERE id = '" + uId + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void BloodDonor_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=PRANTO;Initial Catalog=Blood_Mng;Persist Security Info=True;User ID=sa;Password=123456");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM normal_user WHERE id='" + uId + "'", con);


            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    String name = Convert.ToString(reader["name"]);
                    String username = Convert.ToString(reader["username"]);
                    String password = Convert.ToString(reader["password"]);
                    String age = Convert.ToString(reader["age"]);
                    String phone = Convert.ToString(reader["phone"]);
                    String blood = Convert.ToString(reader["blood"]);
                    String gender = Convert.ToString(reader["gender"]);
                    String address = Convert.ToString(reader["address"]);
                    textBox1.Text = name;
                    textBox2.Text = username;
                    textBox3.Text = password;
                    textBox4.Text = age;
                    textBox5.Text = phone;
                    textBox6.Text = blood;
                    textBox7.Text = gender;
                    textBox8.Text = address;


                }
            }
            con.Close();


            Request();
            BindData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection con = new SqlConnection("Data Source=PRANTO;Initial Catalog=Blood_Mng;Persist Security Info=True;User ID=sa;Password=123456");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE normal_user SET name=@name,username=@username,password=@password,age=@age ,phone=@phone,blood=@blood,gender=@gender, address=@address WHERE id='" + uId + "'", con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@username", textBox2.Text);
                cmd.Parameters.AddWithValue("@password", textBox3.Text);
                cmd.Parameters.AddWithValue("@age", Convert.ToInt32(textBox4.Text));
                cmd.Parameters.AddWithValue("@phone", textBox5.Text);
                cmd.Parameters.AddWithValue("@blood", textBox6.Text);
                cmd.Parameters.AddWithValue("@gender", textBox7.Text);
                cmd.Parameters.AddWithValue("@address", textBox8.Text);

                cmd.ExecuteNonQuery();
                con.Close();


                BindData();
                MessageBox.Show("Your info has been changed!");
            }
            catch (Exception)
            {
                MessageBox.Show("Exception found! Please Enter valid data!");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn up = new LogIn();
            up.Show();

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
        void Request()
        {
            SqlConnection con = new SqlConnection("Data Source=PRANTO;Initial Catalog=Blood_Mng;Persist Security Info=True;User ID=sa;Password=123456");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM normal_user WHERE id='" + uId + "'", con);


            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    String request = Convert.ToString(reader["request"]);

                    if (request == "1")
                    {
                        textBox9.Text = "You have a request for blood";
                    }
                    else
                    {
                        textBox9.Text = "You have no request for blood";
                    }
                   
                    


                }
            }
            con.Close();
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PRANTO;Initial Catalog=Blood_Mng;Persist Security Info=True;User ID=sa;Password=123456");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Normal_user SET request=0 WHERE id='" + uId + "'", con);



            cmd.ExecuteNonQuery();
            con.Close();
            textBox9.Text = "You have no request for blood";
            MessageBox.Show("Confirm Request");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PRANTO;Initial Catalog=Blood_Mng;Persist Security Info=True;User ID=sa;Password=123456");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Normal_user SET request=0 WHERE id='" + uId + "'", con);



            cmd.ExecuteNonQuery();
            con.Close();
            textBox9.Text = "You have no request for blood";
            MessageBox.Show("Cancel Request");
        }
    }
}
