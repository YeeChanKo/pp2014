using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameNew
{
    public class GameUnit
    {
        public int[,] map = new int[20, 20];
        public bool gamestatus = true;
        public SnakeUnit head = null;
        public SnakeUnit tail = null;
        Random r = new Random();

        public int score;
        public int level;

        public GameUnit()
        {
            head = new SnakeUnit(10, 10, 1);
            AddSnakeUnit(9, 10, 1);
            AddSnakeUnit(8, 10, 1);

            score = 0;
            level = 1;

            int x = 0, y = 0;
            do { x = r.Next(0, 20); y = r.Next(0, 19); } while (map[x, y] != 0);
            map[x, y] = 2;
        }

        public void AddSnakeUnit(int x, int y, int d)
        {
            SnakeUnit temp = head;

            while (temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = new SnakeUnit(x, y, d);
            tail = temp.next;
            temp.next.prev = temp;
        }
    }
}
