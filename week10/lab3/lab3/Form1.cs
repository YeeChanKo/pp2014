using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyUp += new KeyEventHandler(enterinput);
        }

        private void enterinput(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Open";
            if(openFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                string str = openFileDialog1.FileName;
                toolStripStatusLabel1.Text = str;
                StreamReader r = new StreamReader(str, Encoding.GetEncoding("euc-kr"));
                ReadFile(r);
                r.Close();
            }
        }

        private void writeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Save As";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string str = saveFileDialog1.FileName;
                toolStripStatusLabel1.Text = str;
                WriteFile(str);
            }
        }
        
        private void ReadFile(StreamReader r)
        {
            while (r.Peek() != -1)
            {
                string result = r.ReadLine();
                if (textBox1.Text == "")
                    textBox1.Text = result;
                else
                    textBox1.Text = textBox1.Text + "\r\n" + result;
            }
        }

        private void WriteFile(string addr)
        {
            StreamWriter r = new StreamWriter(addr, false, Encoding.GetEncoding("euc-kr"));
            string input;

            for(int i = 0; i < textBox1.Lines.Count(); i++)
            {
                input = textBox1.Lines.ElementAt(i);
                r.WriteLine(input);
            }
            r.Close();
        }
    }
}
