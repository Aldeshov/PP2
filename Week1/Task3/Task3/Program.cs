using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] s = Convert.ToString(Console.ReadLine()).Split();
            int[] a = new int[n];

            for(int i = 0; i < n; i++)
            {
                a[i] = int.Parse(s[i]);
            }
            for (int i = 0; i < n; i++)
            {
            Console.Write(a[i] + " ");
            Console.Write(a[i] + " ");
            }

        }
    }
}
