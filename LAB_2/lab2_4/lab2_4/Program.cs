using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Азамат\source\repos\LAB_2\lab2_4\newFile.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter wr = new StreamWriter(fs);

            string line = "Lorem ipsum sit dolor amet)))00)";

            wr.WriteLine(line);
            wr.Close();
            fs.Close();

            
            File.Copy(@"C:\Users\Азамат\source\repos\LAB_2\lab2_4\newFile.txt", @"C:\Users\Азамат\source\repos\LAB_2\lab2_4\newDirectory\copy.txt");

            File.Delete(@"C:\Users\Азамат\source\repos\LAB_2\lab2_4\newFile.txt");
        }
    }
}
