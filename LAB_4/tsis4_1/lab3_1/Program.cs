using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab3_1
{

    public class Complex
    {
        public double re;
        public double im;
        public Complex()
        {

        }

        public void PrintInfo()
        {
            Console.WriteLine("{0} + {1}i", re, im);
        }
          
        public Complex(double x, double y)
        {
            re = x;
            im = y;
        }
        public void Serialize()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            FileStream fs = new FileStream("complex.xml", FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, this);
            fs.Close();
        }

        public Complex Deserialize()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            FileStream fs = new FileStream("complex.xml", FileMode.Open, FileAccess.Read);
            Complex x = xs.Deserialize(fs) as Complex;

            fs.Close();
            return x;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Complex c = new Complex(2, 5);
            c.Serialize();
            Complex c2 = c.Deserialize();

            c.PrintInfo();
            c2.PrintInfo();
        }
    }
}
