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

            for(int i = 0; i < n; i++)
            {
                a[i] = int.Parse(s[i]); // Convert Every element os s[string] to a[integer]
            }
            for (int i = 0; i < n; i++)
            {
            Console.Write(a[i] + " "); // Write Current Element
            Console.Write(a[i] + " "); // Double
            }

        }
    }
}
