using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Game
{
    public partial class Form1 : Form
    {
        int i = 368;
        int w = 400;
        bool mouseleft;
        List<Bitmap> smurf = new List<Bitmap>();
        List<Bitmap> smurfleft = new List<Bitmap>();
        Bitmap actor;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 33;
            timer1.Enabled = true;

            Bitmap x = Properties.Resources.smurf;
            for (int i = 0; i < 64 * 8; i += 64)
            {
                Rectangle r = new Rectangle(i, 0, 64, 64);
                Rectangle r2 = new Rectangle(0, 0, 64, 64);
                Bitmap s = x.Clone(r, x.PixelFormat);
                Bitmap l = s.Clone(r2, s.PixelFormat);
                l.RotateFlip(RotateFlipType.Rotate180FlipY);
                smurf.Add(s);
                smurfleft.Add(l);
            }
            actor = smurf[5];
        }

        private void Render()
        {
            Bitmap screen = new Bitmap(800, 480);
            Graphics back = Graphics.FromImage(screen);
            Graphics front = this.CreateGraphics();
            Bitmap b1 = Properties.Resources.back1;
            Bitmap b2 = Properties.Resources.back2;
            Rectangle r1 = new Rectangle(w, 0, 800, 480);
            Bitmap b3 = b2.Clone(r1, b2.PixelFormat);

            back.DrawImage(b1, 0, 0);
            back.DrawImage(b3, 0, 0);
            back.DrawImage(actor, i, 328);

            DateTime t = DateTime.Now;
            string str = string.Format("{0:hh시mm분ss초ffff}", t);
            back.DrawString(str, new Font("나눔고딕", 20, GraphicsUnit.Pixel), Brushes.Chocolate, 10, 10);
            front.DrawImage(screen, 0, 0);
            back.Dispose();
            front.Dispose();
        }

        private void RenderValueUpdate()
        {
            if (MouseButtons == MouseButtons.Left)
            {
                if (mouseleft == true)
                    w -= 10;
                else
                    w += 10;
            }
            if (w < 0) w = 0;
            else if (w > 800) w = 800;

            if(mouseleft==true)
                actor = smurfleft[(w / 20) % 8];
            else
                actor = smurf[(w / 20) % 8];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RenderValueUpdate();
            Render();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseleft = (e.X < 400);
        }
    }
}
