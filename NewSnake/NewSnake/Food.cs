using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food : GameObject
    {
        public Food(char sign) : base(sign)
        {
            GenerateLocation();
        }
        public void GenerateLocation(List<Point> w, List<Point> s)
        {
            body.Clear();
            Random random = new Random(DateTime.Now.Second);

            Point p = new Point(random.Next(0, 39), random.Next(0, 39));

            while (!IsGoodPoint(w, s, p))
            {
                p = new Point(random.Next(0, 39), random.Next(0, 39));
            }
            body.Add(p);
        }

        public void GenerateLocation()
        {
            Point p = new Point(10, 35);
            body.Add(p);
        }

        bool IsGoodPoint(List<Point> wl, List<Point> sn, Point p)
        {
            bool res = true;

            foreach (Point ps in wl)
            {
                if (ps.X == p.X && ps.Y == p.Y)
                {
                    res = false;
                    break;
                }
            }
            foreach (Point ps in sn)
            {
                if (ps.X == p.X && ps.Y == p.Y)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }
    }
}