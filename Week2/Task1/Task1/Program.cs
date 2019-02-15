using System;
using System.Collections.Generic;


namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Azat\source\repos\PP2\Week2\Task1\Task1\input.txt");// read text from File
            for(int i = 0; i < text.Length; i++)
            {
                if (text[i] != text[text.Length - i - 1]) // if its Elements not equal(Not Palindrome) Quit from Program with answer "No"
                {
                    Console.WriteLine("No");
                    return;
                }
                else
                    continue; //else continue to the last
            }
            Console.WriteLine("Yes"); 
        }
    }
}
