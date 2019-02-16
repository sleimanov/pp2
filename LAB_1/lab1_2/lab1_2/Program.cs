using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("Ashir Sleimanov", 110819);
            s1.Method();
        }
    }
    class Student
    {
        string name;
        int id;
        int year;
        public Student(string nm, int id)
        {
            name = nm;
            this.id = id;
            year = 2019;
        }
        public void Method()
        {
            Console.WriteLine("Student: {0}; Id: {1}", name, id);
            year++;
        }
    }
}