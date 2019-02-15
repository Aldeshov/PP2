using System;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderName1 = @"c:\Path1\"; // Path to First Folder

            string folderName2 = @"c:\Path2\"; // Path to Second Folder

            Directory.CreateDirectory(folderName1); // Create First Directory(Path1)

            File.AppendAllText(folderName1 + "File.file", "Ok"); // Creat And Write here Some Word And Close

            Directory.CreateDirectory(folderName2);  // Create Second Directory(Path2)

            File.Copy(folderName1 + "File.file", folderName2 + "FIle.file", true);  // Copy the File to Second Directory

            File.Delete(folderName1 + "File.file"); // Delete File From First Directory

        }
    }
}
