using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
namespace miro
{
    public class Game
    {        
        public enum Tile { SPACE, WALL, BOX, GOAL, PLAYER, BOXGOAL, PLAYERGOAL };
        public enum Move { UP, DOWN, LEFT, RIGHT, STOP };
        public Tile[,] map, initmap;
        public Move state = Move.STOP;        
        public int W = 0;
        public int H = 0;
        public int px, py, ox, oy, fx, fy;
        public Dictionary<Tile, Bitmap> tile = new Dictionary<Tile, Bitmap>();
        public Bitmap cha;        
        
        Dictionary <Move, Bitmap> char1 = new Dictionary<Move, Bitmap>();
        Dictionary<Move, Bitmap> char2 = new Dictionary<Move, Bitmap>();
        
        private List<Bitmap> allbmp = new List<Bitmap>();
        private DateTime time;
        private Move bstate = Move.STOP;

        const int TSIZE = 48;
        void loadAtlas()
        {
            Bitmap bmp = Properties.Resources.atlas;
            //char load
            for (int i = 0; i < 8* TSIZE; i+= TSIZE)
            {
                Rectangle r = new Rectangle(i, 0, TSIZE, TSIZE);
                Bitmap b = bmp.Clone(r, bmp.PixelFormat);
                allbmp.Add(b);
            }
            //map load
            for (int i = 0; i < 4 * TSIZE; i += TSIZE)
            {
                Rectangle r = new Rectangle(i, TSIZE, TSIZE, TSIZE);
                Bitmap b = bmp.Clone(r, bmp.PixelFormat);
                allbmp.Add(b);
            }

            //add tile
            tile.Add(Tile.SPACE, allbmp[9]);
            tile.Add(Tile.PLAYER, allbmp[2]);
            tile.Add(Tile.PLAYERGOAL, allbmp[2]);
            tile.Add(Tile.WALL, allbmp[8]);
            tile.Add(Tile.BOX, allbmp[10]);
            tile.Add(Tile.BOXGOAL, allbmp[10]);
            tile.Add(Tile.GOAL, allbmp[11]);

            //add char
            char1.Add(Move.UP, allbmp[0]);
            char2.Add(Move.UP, allbmp[1]);
            char1.Add(Move.DOWN, allbmp[2]);
            char2.Add(Move.DOWN, allbmp[3]);
            char1.Add(Move.STOP, allbmp[2]);
            char2.Add(Move.STOP, allbmp[3]);
            char1.Add(Move.LEFT, allbmp[4]);
            char2.Add(Move.LEFT, allbmp[5]);
            char1.Add(Move.RIGHT, allbmp[6]);
            char2.Add(Move.RIGHT, allbmp[7]);

        }

        //read map file and init game class
        public void Load()
        {

            string[] line = File.ReadAllLines(@"Resources\map.txt");
            H = line.Length;
            foreach (string str in line)
            {
                if (str.Length > W)
                    W = str.Length;
            }
            map = new Tile[H, W];
            for (int i = 0; i < H; i++)
                for (int j = 0; j < W; j++)
                    map[i, j] = Tile.SPACE;

            for (int i = 0; i < line.Length; i++)
                for (int j = 0; j < line[i].Length; j++)
                {
                    switch (line[i][j])
                    {
                        case '#':
                            map[i, j] = Tile.WALL;
                            break;
                        case '$':
                            map[i, j] = Tile.BOX;
                            break;
                        case '.':
                            map[i, j] = Tile.GOAL;
                            break;
                        case '@':
                            map[i, j] = Tile.SPACE;
                            px = ox = j;
                            py = oy = i;
                            break;
                    }
                }

            initmap = (Tile[,]) map.Clone();
            loadAtlas();
            cha = char1[Move.STOP];
            time = DateTime.Now;
        }

        public void Reset()
        {
            px = ox;
            py = oy;
            map = (Tile[,])initmap.Clone();
        }

        void DoSomething(DateTime now)
        {
            TimeSpan t = now.Subtract(time);            
            cha = (t.Milliseconds /300 % 2 == 0) ? char1[bstate]: char2[bstate];

           
        }

        public void GameUpdate()
        {            
            int dx = 0, dy = 0;            
            DoSomething(DateTime.Now);                        
            switch (state)
            {
                case Move.UP:
                    dy = -1;
                    break;                    
                case Move.DOWN:
                    dy = 1;
                    break;
                case Move.LEFT:
                    dx = -1;
                    break;
                case Move.RIGHT:
                    dx = +1;
                    break;
                default:
                    return;
            }
            bstate = state;
            //next x, y;
            fx = px + dx;
            int f2x = fx + dx;
            fy = py + dy;
            int f2y = fy + dy;

            //can't move
            if (map[fy, fx] == Tile.WALL)
            {                
                state = Move.STOP;
                return;            
            }

            //if box, check move
            if (map[fy, fx] == Tile.BOX)
            {
                switch (map[f2y, f2x])
                {
                    case Tile.SPACE:
                        map[f2y, f2x] = Tile.BOX;
                        map[fy, fx] = Tile.SPACE;
                        break;
                    case Tile.GOAL:
                        map[f2y, f2x] = Tile.BOXGOAL;
                        map[fy, fx] = Tile.SPACE;
                        break;
                    default: //can't move                        
                        state = Move.STOP;
                        return;
                }
            }

            //if boxgoal, same as box
             if(map[fy, fx] == Tile.BOXGOAL) {
                switch (map[f2y, f2x])
                {
                    case Tile.SPACE:
                        map[f2y, f2x] = Tile.BOX;
                        map[fy, fx] = Tile.GOAL;
                        break;
                    case Tile.GOAL:
                        map[f2y, f2x] = Tile.BOXGOAL;
                        map[fy, fx] = Tile.GOAL;
                        break;
                    default: //can't move                        
                        state = Move.STOP;
                        return;
                }            
             }                
            
            //now move
             px = fx;
             py = fy;
             state = Move.STOP;
        }
    }
}
