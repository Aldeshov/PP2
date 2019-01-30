using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            string[] arr = Console.ReadLine().Split();
            for(int i = 0; i < n; i++)
            {
                a[i] = int.Parse(arr[i]);

                if (a[i] % 2 != 0)
                    Console.Write(a[i] + " ");
            }
            

        }
    }
}
