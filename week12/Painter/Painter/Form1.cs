using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
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
            Pen p1 = new Pen(Color.Black,5);
            Brush b1 = Brushes.Black;
            Brush b2 = Brushes.Tan;
            Brush b4 = Brushes.White;
            Brush b3 = Brushes.SaddleBrown;
            g.FillRectangle(b4, 10, 10, 400, 350);
            g.FillEllipse(b3, 30, 50, 350, 300);
            g.FillEllipse(b3, 40, 40, 80, 90);
            g.FillEllipse(b3, 290, 40, 80, 90);
            g.FillEllipse(b2, 170, 220, 70, 90);
            g.FillEllipse(b1, 170, 205, 20, 20);
            g.FillEllipse(b1, 220, 205, 20, 20);
            g.FillEllipse(b1, 195, 230, 20, 20);
            g.DrawLine(p1, 205, 250, 205, 270);
            g.DrawLine(p1, 205, 268, 190, 290);
            g.DrawLine(p1, 205, 268, 220, 280);
        }
    }
}
