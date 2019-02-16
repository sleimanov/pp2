using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FarManager
{
    class Manager
    {
        public int index;
        public string path;
        public int s;
        DirectoryInfo dir;
        FileSystemInfo cur;
        bool close;

        public Manager()
        {
            index = 0;
        }

        public Manager(string path)
        {
            this.path = path;
            index = 0;
            dir = new DirectoryInfo(path);
            s = dir.GetFileSystemInfos().Length;
            close = true;
        }

        public void Color(FileSystemInfo infos, int index2)
        {
            if (index == index2)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                cur = infos;
            }
            else if (infos.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Desktop()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            dir = new DirectoryInfo(path);
            FileSystemInfo[] infos = dir.GetFileSystemInfos();
            for (int i = 0, k = 0; i < infos.Length; i++)
            {
                if (close == false && infos[0].Name == ".")
                {
                    continue;
                }
                Color(infos[i], k);
                Console.WriteLine(infos[i].Name);
                k++;
            }
            string str = "Previous folder: Backspace | Delete: Del | Rename: F2 | Enter or open: Enter";
            foreach (char c in str)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine();
            Console.WriteLine(str);
        }

        public void CalcSz()
        {
            dir = new DirectoryInfo(path);
            FileSystemInfo[] infos = dir.GetFileSystemInfos();
            s = infos.Length;
            if (close == false)
                for (int i = 0; i < infos.Length; i++)
                    if (infos[i].Name[0] == '.')
                        s--;

        }

        public void Up()
        {
            index--;
            if (index < 0)
            {
                index = --s;
            }
        }

        public void Down()
        {
            index++;
            if (index == s)
            {
                index = 0;
            }
        }

        public void Enter()
        {
            if (cur.GetType() == typeof(DirectoryInfo))
            {
                index = 0;
                path = cur.FullName;
            }
            else
            {
                StreamReader sr = new StreamReader(cur.FullName);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine(sr.ReadToEnd());
                Console.ReadKey();
            }
        }

        public void Delete()
        {
            if (cur.GetType() == typeof(DirectoryInfo))
            {
                index = 0;
                Directory.Delete(cur.FullName);
            }
            else
            {
                index = 0;
                File.Delete(cur.FullName);
            }
        }

        public void F2()
        {
            Console.Clear();
            Console.WriteLine("Enter new name:");
            string newname = Console.ReadLine();
            Console.Clear();
            string newpath = Path.Combine(dir.FullName, newname);
            if (cur.GetType() == typeof(DirectoryInfo))
            {
                Directory.Move(cur.FullName, newpath);
            }
            else
            {
                File.Move(cur.FullName, newpath);
            }
        }

        public void Backspace()
        {
            if (dir.Parent.FullName != @"C:\")
            {
                index = 0;
                path = dir.Parent.FullName;
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("NO WAY!");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Start()
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            while (consoleKey.Key != ConsoleKey.Escape)
            {
                CalcSz();
                Desktop();
                consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.UpArrow)
                    Up();
                if (consoleKey.Key == ConsoleKey.DownArrow)
                    Down();
                if (consoleKey.Key == ConsoleKey.Enter)
                    Enter();
                if (consoleKey.Key == ConsoleKey.Backspace)
                    Backspace();
                if (consoleKey.Key == ConsoleKey.Delete)
                    Delete();
                if (consoleKey.Key == ConsoleKey.F2)
                    F2();
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\test";
            Manager farManager = new Manager(path);
            farManager.Start();
        }
    }
}