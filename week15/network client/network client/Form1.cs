using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace network_client
{
    public partial class Form1 : Form
    {
        netclient nc = new netclient();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = nc.Connect(textbox_ip.Text, (int)numericUpDown1.Value);
            if (result == "success!")
                labelDebug.Text = result;
            else
                textBox1.Text = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nc.Disconnect();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            string msg = "";
            if(e.KeyCode == Keys.Enter)
            {
                msg = nc.Send(textBox2.Text);
                textBox1.Text += msg;
            }
        }
    }
}
