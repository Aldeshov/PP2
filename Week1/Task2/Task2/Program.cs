using System;

namespace Ex7
{
    class Student
    {
        public string name;//Name of Student
        public string id; //ID of Student
        public int year;  //Year of Student

        public Student(int year, string name, string id)
        {
            this.name = name; //Name of Student
            this.id = id;    //ID of Student
            this.year = year; //Year of Student
        }

     
        public override string ToString()
        {
            return name + " " + id + " " + year;  // Write all Given
        }

    }

    class Program
    {
        static void StudentInfo()
        {
            string name = Convert.ToString(Console.ReadLine()); // Read from User Name of Student
            string id = Convert.ToString(Console.ReadLine()); // Read from User ID of Student
            int year = Convert.ToInt32(Console.ReadLine());  // Read from User Year of Student

            Student s = new Student(year,name,id);
            Console.WriteLine(s.ToString());
        }
        
        static void Main(string[] args)
        {
            StudentInfo(); // Start the Program
        }
    }
}