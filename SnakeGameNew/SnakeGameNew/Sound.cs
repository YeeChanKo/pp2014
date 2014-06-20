using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace SnakeGameNew
{
    public static class Sound
    {
        public static SoundPlayer menuselect = new SoundPlayer(Properties.Resources.menu_select);
        public static SoundPlayer opening = new SoundPlayer(Properties.Resources.opening);
        public static SoundPlayer playing = new SoundPlayer(Properties.Resources.playing);
        public static SoundPlayer die = new SoundPlayer(Properties.Resources.die);
        public static SoundPlayer eatflower = new SoundPlayer(Properties.Resources.eat_flower);
    }
}
