using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());  // Get numbers from User

            int[] a = new int[n]; //New array a[n]

            string[] arr = Console.ReadLine().Split(); // every element of array arr[] will be numbers
            for(int i = 0; i < n; i++)
            {
                a[i] = int.Parse(arr[i]); // And Convert arr[] elements to a[] 

                if (a[i] % 2 != 0)
                    Console.Write(a[i] + " "); // Write all odd Numbers
            }
            

        }
    }
}
