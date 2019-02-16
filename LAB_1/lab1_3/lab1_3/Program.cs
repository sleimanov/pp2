using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine()); //Get length of the array 
            int[] arr = Array.ConvertAll<string, int>(Console.ReadLine().Split(), int.Parse); // Get array
            int[] SecArr = new int[n * 2]; // Create new array 
            
            for (int i = 0, k = 0; i < arr.Length; i++)
            { // Go through the initial array and inserting elements to the second array
                SecArr[k] = arr[i];
                SecArr[k+1] = arr[i];
                k+=2;
            }

            foreach (int num in SecArr)
            { // Print all 
                Console.Write(num + " ");
            }
        }
    }
}