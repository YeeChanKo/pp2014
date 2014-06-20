using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gee
{
    public partial class Form1 : Form
    {
        public bool gak = false;
        int x1;
        int y1;
        int x2;
        int y2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            label1.Text = "" + e.X;
            label2.Text = "" + e.Y;

            if(gak==true)
            {
                
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            gak = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            gak = false;
            x2 = e.X;
            y2 = e.Y;

            Graphics g = this.CreateGraphics();
            g.DrawRectangle(new Pen(Color.Gold, 5), x1, y1, Math.Abs(x2-x1), Math.Abs(y2-y1));
        }
    }
}
