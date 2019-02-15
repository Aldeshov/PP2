using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine()); // Read Given Number
            for (int i = 1; i <= n; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    Console.Write("[*]"); // And Write the [*] Like a Half-Triangle
                }
                Console.WriteLine();
            }
        }
    }
}
