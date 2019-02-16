using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_2
{
    class Program
    {
        static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            if (num == 2) return true;
            int k = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0) k++;
            }
            if (k > 2) return false;
            else return true;
        }

        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\Азамат\source\repos\LAB_2\lab2_2\input.txt"))
            {
                string s = sr.ReadToEnd();
                int[] arr = Array.ConvertAll<string, int>(s.Split(), int.Parse);
                List<int> primeArr = new List<int>();
                foreach (int el in arr)
                {
                    if (IsPrime(el))
                    {
                        primeArr.Add(el);
                    }
                }
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Азамат\source\repos\LAB_2\lab2_2\output.txt"))
                {
                    foreach (int el in primeArr)
                    {
                        sw.Write(el + " ");
                    }
                }
            }
        }
    }
    
}
