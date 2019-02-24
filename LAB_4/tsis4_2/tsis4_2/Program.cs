using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace tsis4_2
{
    public class Mark
    {
        public double points;

        public string GetLetter()
        {
            if (this.points >= 0 && this.points <= 49) return "F";
            else if (this.points >= 50 && this.points <= 54) return "D";
            else if (this.points >= 55 && this.points <= 59) return "D+";
            else if (this.points >= 60 && this.points <= 64) return "C-";
            else if (this.points >= 65 && this.points <= 69) return "C";
            else if (this.points >= 70 && this.points <= 74) return "C+";
            else if (this.points >= 75 && this.points <= 79) return "B-";
            else if (this.points >= 80 && this.points <= 84) return "B";
            else if (this.points >= 85 && this.points <= 89) return "B+";
            else if (this.points >= 90 && this.points <= 94) return "A-";
            else if (this.points >= 95 && this.points <= 100) return "A";
            else return "Incorrect input value!";
        }

        public override string ToString()
        {
            return string.Format("{0} equal {1}", this.points, this.GetLetter());
        }

        public Mark(double x)
        {
            points = x;
        }

        public Mark()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Mark> mr = new List<Mark>();
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            FileStream fs = new FileStream("Marks.xml", FileMode.OpenOrCreate, FileAccess.Write);
            Mark m = new Mark();
            m.points = 94;
            Console.WriteLine(m.GetLetter());
            Console.WriteLine(m);
            Mark m1 = new Mark(56);
            mr.Add(m1);
            Mark m2 = new Mark(14.5);
            mr.Add(m2);
            xs.Serialize(fs, mr);
            fs.Close();

            FileStream fs1 = new FileStream("Marks.xml", FileMode.Open, FileAccess.Read);
            List<Mark> newMR = xs.Deserialize(fs1) as List<Mark>;
            Console.WriteLine(newMR[1]);
        }
    }
}
