using System;

namespace Ex7
{
    class Student
    {
        public string name;
        public string id;
        public int year;

        public Student(int year, string name, string id)
        {
            this.name = name;
            this.id = id;
            this.year = year;
        }

     
        public override string ToString()
        {
            return name + " " + id + " " + year;
        }

    }

    class Program
    {
        static void StudentInfo()
        {
            string name = Convert.ToString(Console.ReadLine());
            string id = Convert.ToString(Console.ReadLine());
            int year = Convert.ToInt32(Console.ReadLine());

            Student s = new Student(year,name,id);
            Console.WriteLine(s.ToString());
        }
        
        static void Main(string[] args)
        {
            StudentInfo();
        }
    }
}