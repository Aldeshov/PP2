using System;
using System.IO;

namespace Examples
{
    class Program
    {


        public static void PrintSpaces(int level)
        {
            for (int i = 0; i < level; i++)
                Console.Write("     ");      // to Write space in Every Direction
        }


        public static void Direction(DirectoryInfo dir, int level)
        {
            foreach (FileInfo f in dir.GetFiles())
            {
                PrintSpaces(level);
                Console.WriteLine(f.Name);   // Write Files in Directories
            }
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                PrintSpaces(level);
                Console.WriteLine(d.Name); // Write Directories in the Directories
                try
                {
                    Direction(d, level + 1); // try to Open the Directory
                }
                catch (Exception e)
                {
                    Console.WriteLine("********" + e.Message); // If We cant Open the Directory Catch the Exception
                    continue;
                }
            }
        }


        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo("/Users/Azat"); //Current Path
            Direction(dir, 0);
        }
    }
}
