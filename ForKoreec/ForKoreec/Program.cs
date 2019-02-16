using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForKoreec
{
    public class Rectangle
    {
        int x1, y1, x2, y2;
      
        public Rectangle(int x, int y)
        {
            x1 = 0;
            y1 = 0;
            x2 = x;
            y2 = y;
        }

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(1, 3);
            Rectangle rec2 = new Rectangle(1, 1, 3, 6);
        }
    }
}
