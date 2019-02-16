using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_1
{
    class Program
    {
        static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            if (num == 2) return true;
            int k = 0;
            for(int i = 1; i <= num; i++)
            {
                if (num % i == 0) k++;
            }
            if (k > 2) return false;
            else return true;
        }


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Array.ConvertAll<string, int>(Console.ReadLine().Split(), int.Parse);


            List<int> l1 = new List<int>();
            
            for(int i = 0; i < n; i++)
            {
                if (IsPrime(arr[i])) l1.Add(arr[i]);
            }

            Console.WriteLine(l1.Count);
            foreach(var k in l1)
            {
                Console.Write(k + " ");
            }

        }
    }
}
