using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameNew
{
    public class SnakeUnit
    {
        public int x;
        public int y;
        public int d;

        public SnakeUnit prev = null;
        public SnakeUnit next = null;

        public SnakeUnit(int xx, int yy, int dd)
        {
            x = xx;
            y = yy;
            d = dd;
        }
    }
}
