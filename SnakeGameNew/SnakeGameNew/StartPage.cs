using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGameNew
{
    class StartPage
    {
        public void Render(int viewnumber, Form MainForm)
        {
            if (viewnumber == 0)
            {
                Bitmap screen = new Bitmap(600, 600);
                Graphics back = Graphics.FromImage(screen);
                Graphics front = MainForm.CreateGraphics();
                Bitmap b1 = new Bitmap(Properties.Resources._1, 600, 600);
                back.DrawImage(b1, 0, 0);
                front.DrawImage(screen, 0, 0);
                back.Dispose();
                front.Dispose();
            }
            else if (viewnumber == 1)
            {
                Bitmap screen = new Bitmap(600, 600);
                Graphics back = Graphics.FromImage(screen);
                Graphics front = MainForm.CreateGraphics();
                Bitmap b1 = new Bitmap(Properties.Resources._2, 600, 600);
                back.DrawImage(b1, 0, 0);
                front.DrawImage(screen, 0, 0);
                back.Dispose();
                front.Dispose();
            }
            else if (viewnumber == 2)
            {
                Bitmap screen = new Bitmap(600, 600);
                Graphics back = Graphics.FromImage(screen);
                Graphics front = MainForm.CreateGraphics();
                Bitmap b1 = new Bitmap(Properties.Resources._3, 600, 600);
                back.DrawImage(b1, 0, 0);
                front.DrawImage(screen, 0, 0);
                back.Dispose();
                front.Dispose();
            }
            else // viewnumber == 3
            {
                Bitmap screen = new Bitmap(600, 600);
                Graphics back = Graphics.FromImage(screen);
                Graphics front = MainForm.CreateGraphics();
                Bitmap b1 = new Bitmap(Properties.Resources._4, 600, 600);
                back.DrawImage(b1, 0, 0);
                front.DrawImage(screen, 0, 0);
                back.Dispose();
                front.Dispose();
            }
        }
    }
}
