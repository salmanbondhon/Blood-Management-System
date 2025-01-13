using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectK
{
    public partial class Userpanel : Form
    {
        public Userpanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text== "Blood Doner")
            {
                this.Hide();
                BloodDonor blD=new BloodDonor();
                blD.Show();
            }
            else if(comboBox1.Text== "Blood Receiver")
            {
                this.Hide();
                BloodReceiver blR = new BloodReceiver();
                blR.Show();
            }

        }

        private void Userpanel_Load(object sender, EventArgs e)
        {

        }
    }
}
