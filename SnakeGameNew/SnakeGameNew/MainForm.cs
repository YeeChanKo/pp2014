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
    public partial class MainForm : Form
    {
        GamePage Game = new GamePage();
        StartPage Start = new StartPage();
        public bool gamestatus = true;
        public bool stopgame = false;
        public int directionnow = 1;
        public int score;
        public int level;

        public int mousex;
        public int mousey;
        public int viewnumber;

        public MainForm()
        {
            InitializeComponent();

            StartPageRender.Enabled = true;
            StartPageRender.Interval = 100;

            GamePageRender.Enabled = false;
            GamePageRender.Interval = 50;

            GameLogic.Enabled = false;
            GameLogic.Interval = 200;

            Sound.opening.Play();
        }

        private void StartPageRender_Tick(object sender, EventArgs e)
        {
            Start.Render(viewnumber, this);
        }

        private void GamePageRender_Tick(object sender, EventArgs e)
        {
            Game.Render(this, directionnow, ref score, ref level, ref gamestatus);

            GameLogic.Interval = 200; // 뱀 이동 속도
            if (gamestatus == false) // 게임오버
            {
                GameLogic.Enabled = false;
                GamePageRender.Enabled = false;
                gamestatus = true;

                Bitmap screen = new Bitmap(600, 600);
                Graphics back = Graphics.FromImage(screen);
                Graphics front = CreateGraphics();
                Bitmap transblack = new Bitmap(Properties.Resources.transblack, 600, 600);
                back.DrawImage(transblack, 0, 0);
                back.DrawString("YOU LOSE!", new Font("나눔고딕", 50, GraphicsUnit.Pixel), Brushes.White, 170, 280);
                front.DrawImage(screen, 0, 0);
                back.Dispose();
                front.Dispose();

                System.Threading.Thread.Sleep(3000);
                Game = new GamePage();
                StartPageRender.Enabled = true;
                directionnow = 1;
            }
        }

        private void GameLogic_Tick(object sender, EventArgs e)
        {
            Game.SnakeMoveCalculator();
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (viewnumber == 1)
            {
                Sound.menuselect.Play();
                StartPageRender.Enabled = false;
                GamePageRender.Enabled = true;
                GameLogic.Enabled = true;
            }
            else if (viewnumber == 2)
            {
                // saved game
            }
            else if (viewnumber == 3)
            {
                // show ranking
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            mousex = e.X;
            mousey = e.Y;

            if (e.X > 240 && e.X < 360 && e.Y > 440 && e.Y < 465)
            {
                viewnumber = 1;
            }
            else if (e.X > 235 && e.X < 370 && e.Y > 495 && e.Y < 520)
            {
                viewnumber = 2;
            }
            else if (e.X > 250 && e.X < 350 && e.Y > 545 && e.Y < 570)
            {
                viewnumber = 3;
            }
            else
            {
                viewnumber = 0;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                directionnow = 1;
            }
            else if (e.KeyCode == Keys.Left)
            {
                directionnow = 2;
            }
            else if (e.KeyCode == Keys.Down)
            {
                directionnow = 3;
            }
            else if (e.KeyCode == Keys.Up)
            {
                directionnow = 4;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (stopgame == false)
                {
                    GameLogic.Enabled = false;
                    GamePageRender.Enabled = false;
                    stopgame = true;

                    Graphics stoppage = CreateGraphics();
                    Bitmap transblack = new Bitmap(Properties.Resources.transblack, 600, 600);
                    stoppage.DrawImage(transblack, 0, 0);
                    stoppage.Dispose();
                }
                else if (stopgame == true)
                {
                    GameLogic.Enabled = true;
                    GamePageRender.Enabled = true;
                    stopgame = false;
                }
            }
        }
    }
}
