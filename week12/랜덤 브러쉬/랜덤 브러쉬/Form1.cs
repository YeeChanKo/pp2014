using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace 랜덤_브러쉬
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            PropertyInfo[] p = typeof(Brushes).GetProperties();

            for(int i = 0;i<1000;i++)
            {
                Random r = new Random();
                int a = r.Next(p.Length);
                Brush b = (Brush)p[a].GetValue(null);

                int x = r.Next(this.Width);
                int y = r.Next(this.Height);
                int k = r.Next(this.Width-x)+30;
                int l = r.Next(this.Height-y)+30;
                System.Threading.Thread.Sleep(5);
                g.FillRectangle(b, x,y,k,l);
            }
        }
    }
}
