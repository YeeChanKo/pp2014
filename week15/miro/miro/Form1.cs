using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace miro
{    
    public partial class Form1 : Form
    {
        const int TSIZE = 48;
        const int W = 740;
        const int H = 500;
        const int M = 10; //margin
        int dx, dy; //map zero point
        Bitmap vram;
        Graphics vg;
        Game game = new Game();
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 33;
            vram = new Bitmap(Width, Height);
            vg = Graphics.FromImage(vram);
            timer1.Enabled = true;
            game.Load();
            dx = (W + M - game.W * TSIZE) / 2;
            dy = (H + M - game.H * TSIZE) / 2;
            this.KeyPreview = true;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateGame();
            Render();
        }

        void UpdateGame()
        {
            game.GameUpdate();
        }

        void Render()
        {
            Graphics g = this.CreateGraphics();
            Rectangle b1 = new Rectangle(M,M,W, H);
            //draw boxes
            vg.FillRectangle(Brushes.DarkGreen, b1);            

            //map draw
            for (int i = 0; i < game.H; i++)
                for (int j = 0; j < game.W; j++)                
                    DrawMap(vg, i, j);

            //char draw
            DrawCha(vg);
            
            //drawAll
            g.DrawImage(vram, 0, 0);
        }

        void DrawCha(Graphics g)
        {
           
           
            vg.DrawImage(game.cha, dx + game.px * TSIZE, dy + game.py * TSIZE, TSIZE, TSIZE);
        }
        void DrawMap(Graphics g, int row, int col)
        {
            Game.Tile t = game.map[row, col];
            Bitmap b = game.tile[t];
            Bitmap green = game.tile[Game.Tile.SPACE];
            int x = col * TSIZE;
            int y = row * TSIZE;
            g.DrawImage(green, dx + x, dy + y, TSIZE, TSIZE);
            g.DrawImage(b, dx +x,dy +  y,TSIZE,TSIZE);
        }

        private void buttonServer_Click(object sender, EventArgs e)
        {
            //Server Start Here
        }        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    game.state = Game.Move.UP;
                    break;
                case Keys.A:
                    game.state = Game.Move.LEFT;
                    break;
                case Keys.S:
                    game.state = Game.Move.DOWN;
                    break;
                case Keys.D:
                    game.state = Game.Move.RIGHT;
                    break;
                case Keys.R:
                    game.Reset();
                    break;
            }
            textBox1.Text = game.state +"눌렸음";
        }
    }
}
