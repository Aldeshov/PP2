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
            int n = Convert.ToInt32(Console.ReadLine());// Read numbers From User
            string[] s = Convert.ToString(Console.ReadLine()).Split(); // All Numbers will be in array s[](string)
            int[] a = new int[n]; // and New array for Numbers a[](integer)
            int[] b = new int[n * 2]; // New array for Double numbers
            for(int i = 0; i < n; i++)
            {
                a[i] = int.Parse(s[i]); // Convert Every element os s[string] to a[integer]
            }
            for (int i = 0; i < n; i++)
            {
                b[i * 2] = a[i];
                b[i * 2 + 1] = a[i];
            }
            for (int i = 0; i < b.Length; i++)
                Console.Write(b[i] + " "); // Write Double array

        }
    }
}
