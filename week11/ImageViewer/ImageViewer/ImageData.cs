using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    public class ImageData
    {
        public ImageData() { }
        public int width;
        public int height;
        public int[] pixel;
        public void setsize(int w, int h)
        {
            width = w;
            height = h;
            pixel = new int[w * h];
        }
    }
}
