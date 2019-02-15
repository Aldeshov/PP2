using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        public static int IsPrime(int a) // to Find A Prime Number
        {
            for(int i = 2; i < a; i++) 
            {
                if (a % i != 0)//if it has no divider so we'll take it
                    continue;
                else
                    return 0;
            }
            return a;
        }
        
        static void Main(string[] args)
        {
            
            string path = @"C:\Users\Azat\source\repos\PP2\Week2\Task2\Task2\input.txt";
            string[] arr = System.IO.File.ReadAllText(path).Split(); // Read Text From Path
            int[] Num = new int[arr.Length];// array for all Numbers
            List<int> a = new List<int>();// list for Odd Numbers
            for(int i = 0; i < arr.Length; i++)
            {
                Num[i] = int.Parse(arr[i]);
                if (IsPrime(Num[i]) != 0)
                    a.Add(Num[i]);// if its Prime We Take It
            }
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Azat\source\repos\PP2\Week2\Task2\Task2\output.txt")) // to write all odd numbers
            {
                foreach (int abc in a)
                {
                    file.Write(abc + " ");
                }
                file.Close();// and Close it
            }
            Console.WriteLine("Ok");// If It Will Finish Without Exceptions
        }
    }
}
