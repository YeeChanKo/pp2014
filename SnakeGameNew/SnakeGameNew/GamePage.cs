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
    public class GamePage
    {
        Random r = new Random();
        public int directionnow;
        public GameUnit g = new GameUnit();

        Bitmap background = new Bitmap(Properties.Resources.background, 600, 600);
        Bitmap grasstile = new Bitmap(Properties.Resources.grass_tile, 30, 30);
        Bitmap snakehead1 = new Bitmap(Properties.Resources.snakehead1, 30, 30);
        Bitmap snakehead2 = new Bitmap(Properties.Resources.snakehead2, 30, 30);
        Bitmap snakehead3 = new Bitmap(Properties.Resources.snakehead3, 30, 30);
        Bitmap snakehead4 = new Bitmap(Properties.Resources.snakehead4, 30, 30);
        Bitmap snakebody1 = new Bitmap(Properties.Resources.snakebody1, 30, 30);
        Bitmap snakebody2 = new Bitmap(Properties.Resources.snakebody2, 30, 30);
        Bitmap snakebody3 = new Bitmap(Properties.Resources.snakebody3, 30, 30);
        Bitmap snakebody4 = new Bitmap(Properties.Resources.snakebody4, 30, 30);
        Bitmap snaketail1 = new Bitmap(Properties.Resources.snaketail1, 30, 30);
        Bitmap snaketail2 = new Bitmap(Properties.Resources.snaketail2, 30, 30);
        Bitmap snaketail3 = new Bitmap(Properties.Resources.snaketail3, 30, 30);
        Bitmap snaketail4 = new Bitmap(Properties.Resources.snaketail4, 30, 30);
        Bitmap flower = new Bitmap(Properties.Resources.flower, 30, 30);
        Bitmap brick = new Bitmap(Properties.Resources.RedBrick, 30, 30);

        public void Render(Form MainForm, int direction, ref int score, ref int level, ref bool gamestatus) // direction, score, level, gamestatus 받음
        {
            bool ToRightEroor = (g.head.x + 1 == g.head.next.x) && (g.head.y == g.head.next.y) && direction == 1;
            bool ToLeftError = (g.head.x - 1 == g.head.next.x) && (g.head.y == g.head.next.y) && direction == 2;
            bool ToDownError = (g.head.x == g.head.next.x) && (g.head.y + 1 == g.head.next.y) && direction == 3;
            bool ToUpError = (g.head.x == g.head.next.x) && (g.head.y - 1 == g.head.next.y) && direction == 4;
            if (!(ToRightEroor || ToLeftError || ToDownError || ToUpError))
            {
                directionnow = direction;
            }

            score = g.score;
            level = g.level;
            gamestatus = g.gamestatus;

            Bitmap screen = new Bitmap(600, 600);
            Graphics back = Graphics.FromImage(screen);
            Graphics front = MainForm.CreateGraphics();
            back.DrawImage(background, 0, 0);
            RenderCalculator(MainForm, back);
            back.DrawString("Score: " + score, new Font("나눔고딕", 20, GraphicsUnit.Pixel), Brushes.White, 30, 575);
            back.DrawString("Level " + level, new Font("나눔고딕", 20, GraphicsUnit.Pixel), Brushes.White, 505, 575);
            front.DrawImage(screen, 0, 0);
        }

        public void RenderCalculator(Form MainForm, Graphics back) // 모든 좌표(0-빈공간,1-뱀,2-꽃,3-장애물) 렌더
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (i == 0 || i == 19 || j == 0 || j == 19) // 바깥 벽돌(3) 만들어주기
                    {
                        g.map[i, j] = 3;
                    }

                    if (g.map[i, j] == 0) // 0일 경우
                    {
                        back.DrawImage(grasstile, i * 30, j * 30);
                    }
                    else if (g.map[i, j] == 1) // 1일 경우
                    {
                        if (g.head.x == i && g.head.y == j) // head일 경우
                        {
                            if (g.head.d == 1)
                            {
                                back.DrawImage(snakehead1, i * 30, j * 30);
                            }
                            else if (g.head.d == 2)
                            {
                                back.DrawImage(snakehead2, i * 30, j * 30);
                            }
                            else if (g.head.d == 3)
                            {
                                back.DrawImage(snakehead3, i * 30, j * 30);
                            }
                            else if (g.head.d == 4)
                            {
                                back.DrawImage(snakehead4, i * 30, j * 30);
                            }
                        }
                        else if (g.tail.x == i && g.tail.y == j) // tail일 경우
                        {
                            if (g.tail.d == 1)
                            {
                                back.DrawImage(snaketail1, i * 30, j * 30);
                            }
                            else if (g.tail.d == 2)
                            {
                                back.DrawImage(snaketail2, i * 30, j * 30);
                            }
                            else if (g.tail.d == 3)
                            {
                                back.DrawImage(snaketail3, i * 30, j * 30);
                            }
                            else if (g.tail.d == 4)
                            {
                                back.DrawImage(snaketail4, i * 30, j * 30);
                            }
                        }
                        else // body일 경우
                        {
                            SnakeUnit temp = g.head;
                            while (!(temp.x == i && temp.y == j))
                            {
                                temp = temp.next;
                            }

                            if (temp.d == 1)
                            {
                                back.DrawImage(snakebody1, i * 30, j * 30);
                            }
                            else if (temp.d == 2)
                            {
                                back.DrawImage(snakebody2, i * 30, j * 30);
                            }
                            else if (temp.d == 3)
                            {
                                back.DrawImage(snakebody3, i * 30, j * 30);
                            }
                            else if (temp.d == 4)
                            {
                                back.DrawImage(snakebody4, i * 30, j * 30);
                            }
                        }
                    }
                    else if (g.map[i, j] == 2) // 2일 경우
                    {
                        back.DrawImage(flower, i * 30, j * 30);
                    }
                    else if (g.map[i, j] == 3) // 3일 경우
                    {
                        back.DrawImage(brick, i * 30, j * 30);
                    }
                }
            }
        }

        // ---------------------구분선-----------------------//
        // --------위는 렌더 부분, 아래는 계산 부분----------//

        public void SnakeMoveCalculator() // 움직임에 따른 좌표 이동
        {
            SnakeUnit temp = g.tail;

            int tailpastx = temp.x;
            int tailpasty = temp.y;
            int tailpastd = temp.d;

            g.map[temp.x, temp.y] = 0;
            temp.x = temp.prev.x;
            temp.y = temp.prev.y;
            temp.d = temp.prev.d;

            for (temp = temp.prev; temp != g.head; temp = temp.prev)
            {
                temp.x = temp.prev.x;
                temp.y = temp.prev.y;
                temp.d = temp.prev.d;
            }
            // 여기서 temp는 g.head가 됨

            if (directionnow == 1)
            {
                temp.x++;

                if (!(g.map[temp.x, temp.y] == 0 || g.map[temp.x, temp.y] == 2))
                {
                    GameFailed();
                }

                temp.d = 1;
                IfEatFlower(temp.x, temp.y, tailpastx, tailpasty, tailpastd);
                g.map[temp.x, temp.y] = 1;
            }
            else if (directionnow == 2)
            {
                temp.x--;

                if (!(g.map[temp.x, temp.y] == 0 || g.map[temp.x, temp.y] == 2))
                {
                    GameFailed();
                }

                temp.d = 2;
                IfEatFlower(temp.x, temp.y, tailpastx, tailpasty, tailpastd);
                g.map[temp.x, temp.y] = 1;
            }
            else if (directionnow == 3)
            {
                temp.y++;

                if (!(g.map[temp.x, temp.y] == 0 || g.map[temp.x, temp.y] == 2))
                {
                    GameFailed();
                }

                temp.d = 3;
                IfEatFlower(temp.x, temp.y, tailpastx, tailpasty, tailpastd);
                g.map[temp.x, temp.y] = 1;
            }
            else if (directionnow == 4)
            {
                temp.y--;

                if (!(g.map[temp.x, temp.y] == 0 || g.map[temp.x, temp.y] == 2))
                {
                    GameFailed();
                }

                temp.d = 4;
                IfEatFlower(temp.x, temp.y, tailpastx, tailpasty, tailpastd);
                g.map[temp.x, temp.y] = 1;
            }
        }

        public void GameFailed() // 부딪히면
        {
            Sound.die.Play();
            g.gamestatus = false;
        }

        public void IfEatFlower(int tempx, int tempy, int tailpastx, int tailpasty, int tailpastd) // 꽃먹으면
        {
            if (g.map[tempx, tempy] == 2)
            {
                Sound.eatflower.Play();
                g.AddSnakeUnit(tailpastx, tailpasty, tailpastd);
                g.score += 10 * g.level;
                CreateFlower();
            }

            int check = g.score / 50;
            g.level = check + 1;
        }

        public void CreateFlower() // 꽃생성
        {
            int x = 0;
            int y = 0;
            do
            {
                x = r.Next(0, 20);
                y = r.Next(0, 19);
            } while (g.map[x, y] != 0);
            g.map[x, y] = 2;
        }
    }
}
