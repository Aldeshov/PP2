using System;
using System.IO;

namespace TaskFarManger
{
    public class FarManager
    {

        public static int CurrentIndex = 1; // Current Cursor Position in Directories and Files
        public static int CurrentOptInd = 0; // Current Cursor Position in Option Menu
        public static string text = null; // Text to Read From File
        public static int MenuStyle = 0; // Current Index Style 0 or 1 (integer)
        public string ForException = null; // Message of Exceptions
        public static FileSystemInfo ForSelectItem = null; // Current selected File or Directory
        public static int first = 2; // For Scrolling the Directories Starts from
        public static int last = 28; // For Scrolling the Directories Ends With
        public int size = 0; // Constant size of Current Directory(except files and directories starting with ".")
        bool inOption = false; // Is Open the Option boolean
        bool inTextRedactor = false; // Is Open the Text Redactor boolean
        public int n = 1; // etc. Is In Option Menu Have a Section *Open
        public static int X = 0; // etc.



                          ////////////////////////////////////-HowToShowProgram-////////////////////////////////////

        public void ToShow() // The Function How to show Interface (this is not important to logic of Program)
        {
            for (int i = 0; i < 29; i++)
            {
                Console.SetCursorPosition(0, i);
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("----------------------------------------------------->> Program <<-----------------------------------------------------");
                    
                }
                else
                {
                    Console.WriteLine("|");
                    Console.SetCursorPosition(118, i);
                    Console.WriteLine("|");
                    Console.SetCursorPosition(59, i);
                    Console.WriteLine("|");
                    
                }
            }
            Console.Write("                                          Far Manager From Azat         v 1.0");
            
        }



                          ////////////////////////////////////-HowToShowDirectories-////////////////////////////////
        
        public void ShowDirectoriesFiles(string path) // With Given Path this Function Will Show The Directory Files
        {

            string name = null; //Name of Files or Directories (This is taken To cut the name if its Lenght more than 59 digits )
            DirectoryInfo directory = new DirectoryInfo(path); //New Directory( of this Path) 
            FileSystemInfo[] fileSystemInfos = directory.GetFileSystemInfos();//New Files (of this Directory)
            size = fileSystemInfos.Length; // Set size = Length of all Files in this Directory
            int count = 1; //For Console SetCursorPosition

            Console.SetCursorPosition(1, count);//Set the Position of Cursor Like this (x coordinate,y coordinate)

            //And We set Color of all Text {1}
            if (CurrentIndex == count)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                if(MenuStyle == 1)
                    Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (MenuStyle == 1)
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
            Console.Write("..");
            count++;

            //And here all files will show on the console
            foreach (FileSystemInfo fs in fileSystemInfos)
            {

                if (fs.Name.StartsWith("."))
                {
                    size--;
                    continue;
                }
                

                

                if (first <= count && last >= count)
                {
                    Console.SetCursorPosition(1, count - X);
                    
                    if (CurrentIndex == count - X)
                    {
                        //And We set Color of all Text {2}
                        Console.ForegroundColor = ConsoleColor.Black; //Current Index Color
                        if (MenuStyle == 1)
                            Console.BackgroundColor = ConsoleColor.White;
                        if (inOption == true)
                        {
                            ForSelectItem = fs;
                            if (fs.Name.EndsWith("txt") || fs.Name.EndsWith(".md"))
                                ShowOptions(true, fs);
                            else
                                ShowOptions(false, fs);
                        }

                    }
                    else if (fs.GetType() == typeof(DirectoryInfo))
                    {   
                        //And We set Color of all Text {3}
                        Console.ForegroundColor = ConsoleColor.White;
                        if (MenuStyle == 1)
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }
                    else
                    {   
                        //And We set Color of all Text {4}
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (MenuStyle == 1)
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }

                    if (fs.Name.Length > 57)
                    {
                        int n = fs.Name.Length;
                        name = fs.Name;
                        name = name.Remove(54);   // here we Remove unnecessary digitst
                        name = name + "...";    

                    }
                    else
                        name = fs.Name;

                    Console.SetCursorPosition(1, count - X);
                    Console.Write(name);

                    name = null;

                    // Here in Option Menu section "Open" availavles
                    if ((fs.Name.EndsWith(".txt") || fs.Name.EndsWith(".md")) && CurrentIndex == count - X)
                        ShowOptions(true, fs);
                    else if (CurrentIndex == count - X)
                        ShowOptions(false, fs);
                }
                count++;
            }
        }


                           ////////////////////////////////////-HowToShowTextRedactor-////////////////////////////////
                           
        public void OpenTextRedactor() // Here we can Only Open and Read the text files(".txt",".md")
        {
            Console.Clear();
            Console.CursorVisible = true; 
            ConsoleKeyInfo Keys = new ConsoleKeyInfo();
            while (Keys.Key != ConsoleKey.Escape)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.Write("--------------------------------------------------->> TextRedactor <<---------------------------------------------------");
                Console.SetCursorPosition(0, 1);

                Console.Write(text);

                Keys = Console.ReadKey();
            }
                inTextRedactor = false;
        }


                           ////////////////////////////////////-HowToShowRenamerTheFile-////////////////////////////////

        public void RenameFile(string path)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write("---------------------------------------------------->RenameTheFile<----------------------------------------------------");
            Console.SetCursorPosition(0, 1);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.CursorVisible = true;
            string Rename = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(Rename) == true)
            {
                ForException = "Invalid Name of File";
            }
            else
            {
                try
                {
                    
                    inOption = false;
                    CurrentOptInd = 0;
                    if (File.Exists(ForSelectItem.FullName))
                        File.Move(ForSelectItem.FullName, path + "/" + Rename + ForSelectItem.Extension);

                    if (Directory.Exists(ForSelectItem.FullName))
                        Directory.Move(ForSelectItem.FullName, path + "/" + Rename + ForSelectItem.Extension);



                }

                catch (Exception e)
                {
                    ForException = e.Message;
                }
            }
        }



                           ////////////////////////////////////-HowToShowOptions-////////////////////////////////
                           
        public void ShowOptions(bool a,FileSystemInfo fs)
        {
            //And We set Color of all Text {5}
            if (a == true)
            {
                n = 0;
                ForSelectItem = fs;
                if (CurrentOptInd == 1)
                {
                    
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (MenuStyle == 1)
                        Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (MenuStyle == 1)
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.SetCursorPosition(60, 1);
                Console.Write("Open");
                if (CurrentOptInd == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (MenuStyle == 1)
                        Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (MenuStyle == 1)
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.SetCursorPosition(60, 2);
                Console.Write("Rename");
                if (CurrentOptInd == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (MenuStyle == 1)
                        Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (MenuStyle == 1)
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.SetCursorPosition(60, 3);
                Console.Write("Delete");

                Console.ForegroundColor = ConsoleColor.White;
                if (MenuStyle == 1)
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(60, 10);
                Console.Write("Information:");                //And Here Some Information about File Or Directory
                if (fs.GetType() == typeof(DirectoryInfo))
                {
                    Console.SetCursorPosition(60, 12);
                    Console.Write(" Extension: is Directory");
                    Console.SetCursorPosition(60, 14);
                    Console.Write(" Last Access Time: " + fs.LastAccessTime);
                    Console.SetCursorPosition(60, 16);
                    Console.Write(" Creation Time: " + fs.CreationTime);
                }
                else
                {
                    Console.SetCursorPosition(60, 12);
                    Console.Write(" Extension: " + fs.Extension);
                    Console.SetCursorPosition(60, 14);
                    Console.Write(" Last Access Time: " + fs.LastAccessTime);
                    Console.SetCursorPosition(60, 16);
                    Console.Write(" Creation Time: " + fs.CreationTime);
                }

            }
            else
            {
                n = 1;
                if (CurrentOptInd == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (MenuStyle == 1)
                        Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (MenuStyle == 1)
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.SetCursorPosition(60, 2);
                Console.Write("Rename");
                if (CurrentOptInd == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (MenuStyle == 1)
                        Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (MenuStyle == 1)
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                Console.SetCursorPosition(60, 3);
                Console.Write("Delete");

                Console.ForegroundColor = ConsoleColor.White;
                if (MenuStyle == 1)
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(60, 10);
                Console.Write("Information:");                   //And Here Some Information about File Or Directory
                if (fs.GetType() == typeof(DirectoryInfo))
                {
                    Console.SetCursorPosition(60, 12);
                    Console.Write(" Extension: is Directory");
                    Console.SetCursorPosition(60, 14);
                    Console.Write(" Last Access Time: " + fs.LastAccessTime);
                    Console.SetCursorPosition(60, 16);
                    Console.Write(" Creation Time: " + fs.CreationTime);
                }
                else
                {
                    Console.SetCursorPosition(60, 12);
                    Console.Write(" Extension: " + fs.Extension);
                    Console.SetCursorPosition(60, 14);
                    Console.Write(" Last Access Time: " + fs.LastAccessTime);
                    Console.SetCursorPosition(60, 16);
                    Console.Write(" Creation Time: " + fs.CreationTime);
                }
            }
        }

                         ////////////////////////////////////-MoveUpTheCurrentIndex-////////////////////////////////

        public void Up()
        {
            if (inOption != true)
            {
                CurrentIndex--;
                if (CurrentIndex < 2 && first != 2)
                {
                    X--;
                    first--;
                    last--;
                    CurrentIndex++;
                }
                else
                {
                    
                    if (CurrentIndex < 1)
                    {
                        CurrentIndex++;
                    }
                }
            }
            else
            {
                CurrentOptInd--;
                if (n == 1 && CurrentOptInd == 1)
                {
                    CurrentOptInd = 3;
                }
                if(n == 0 && CurrentOptInd < 1)
                {
                    CurrentOptInd = 3;
                }
            }
        }

                         ////////////////////////////////////-MoveDownTheCurrentIndex-////////////////////////////////

        public void Down()
        {
            if (inOption != true)
            {
                CurrentIndex++;
                if (size > 27)
                {
                    if (CurrentIndex > 28 && last < size + 1)
                    {
                        X++;
                        first++;
                        last++;
                        CurrentIndex--;
                    }
                    else
                    {
                        if (CurrentIndex > 28 && last >= size)
                        {
                            CurrentIndex--;
                        }
                    }
                }
                else
                    if (CurrentIndex > size + 1)
                        CurrentIndex--;
                


            }
            else
            {
                CurrentOptInd++;
                    if (n == 1 && CurrentOptInd > 3)
                    {
                        CurrentOptInd = 2;
                    }
                    if (n == 0 && CurrentOptInd > 3)
                    {
                        CurrentOptInd = 1;
                    }
                
            }
        }



        public void OpenDirectory(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo files = null;
            
            while (true)     //While We Work with this program(Infinitely)
            {
                if(inTextRedactor == true)
                {
                    OpenTextRedactor();
                }

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Clear();                     
                
                Console.CursorVisible = false;                //And Some Option To Work With Only Far Manager
                Console.SetBufferSize(120,30);
                


                    string DirName = null;
                    if (directory.FullName.Length > 56)
                    {
                        int n = directory.FullName.Length;
                        DirName = directory.FullName;
                        DirName = DirName.Remove(3, n - 56);      // Write Current Direction path Full Name
                        DirName = DirName.Insert(3, "..");
                    }
                    else
                        DirName = directory.FullName;

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(60, 26);
                    Console.Write(DirName);

                    ToShow();
                    ShowDirectoriesFiles(path);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(60, 27);
                if (ForException != null && ForException.Length > 57)
                {
                    string one = ForException.Remove(58);
                    string two = ForException.Remove(0, 58);
                    Console.Write(one);                            //Write Exception Message
                    Console.SetCursorPosition(60, 28);
                    Console.Write(two);
                }
                else
                    Console.Write(ForException);

                    ForException = null;   // Clear the ExceptionMessage
                
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if(consoleKey.Key == ConsoleKey.Enter)
                {
                    if (inTextRedactor != true)
                    {
                        if (inOption != true)
                        {
                            if (CurrentIndex == 1)
                            {
                                if (directory.Parent != null)
                                {
                                    CurrentIndex = 1;
                                    directory = directory.Parent;    // if The Current Index is 1 (..) We take ParentDir of htis Directory
                                    path = directory.FullName;
                                }
                            }
                            else
                            {
                                int n = 0;
                                for (int i = 0; i < directory.GetFileSystemInfos().Length; i++)
                                {
                                    if (directory.GetFileSystemInfos()[i].Name.StartsWith("."))
                                    {
                                        n++;
                                        continue;  //We dont need files (If its name starts with "."   (  .abc))

                                    }
                                    if (i - n == CurrentIndex - 2 + X && directory.GetFileSystemInfos()[i].GetType() == typeof(DirectoryInfo))
                                    {
                                        try
                                        {
                                            files = directory.GetFileSystemInfos()[i];
                                            CurrentIndex = 1;

                                            path = files.FullName;                      //Try to Open the Current Directory
                                            directory = new DirectoryInfo(path);

                                            FileSystemInfo[] abc = directory.GetFileSystemInfos();
                                            abc = null;
                                        }
                                        catch (Exception e)
                                        {
                                            
                                            directory = directory.Parent;
                                            path = directory.FullName;         //Catch Exception If we can't Open the Directory

                                            ForException = e.Message;
                                        }

                                        break;
                                    }
                                }
                            }
                            X = 0;
                            first = 2; // Default opt
                            last = 28;
                        }
                        else
                        {
                            if (CurrentOptInd == 1)  //This Option Takes Current Text file To Open
                            {
                                inTextRedactor = true;
                                text = System.IO.File.ReadAllText(ForSelectItem.FullName);
                            }
                            if(CurrentOptInd == 2)   //This Option Renames the Current File or Directory
                            {
                                RenameFile(path);
                            }
                            if(CurrentOptInd == 3)  //This Option Deletes Current Directory or File
                            {
                                if (File.Exists(ForSelectItem.FullName) || Directory.Exists(ForSelectItem.FullName))
                                {
                                    try
                                    {
                                        CurrentOptInd = 0;
                                        inOption = false;
                                        if(File.Exists(ForSelectItem.FullName))
                                            File.Delete(ForSelectItem.FullName);

                                        if (Directory.Exists(ForSelectItem.FullName))
                                            Directory.Delete(ForSelectItem.FullName, true);    
                                    }
                                    catch(Exception e)
                                    {
                                        ForException = e.Message;
                                    }
                                }
                            }
                        }
                    }
                }
                if(consoleKey.Key == ConsoleKey.Q)
                {
                    if (MenuStyle == 0)
                        MenuStyle = 1;         // Set Menu Style 0 or 1 (integer)
                    else
                        MenuStyle = 0;
                }
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    if (inOption == true)
                    {                           // Go Out From Option Menu
                        CurrentOptInd = 0;
                        inOption = false;
                    }
                    
                }

                if (consoleKey.Key == ConsoleKey.UpArrow)
                {
                    Up();                //Function Up(To Move Current Index Up)
                }

                if (consoleKey.Key == ConsoleKey.DownArrow)
                {
                    Down();              //Function Down(To Move Current Index Down) 
                }

                if(consoleKey.Key == ConsoleKey.F && inOption == false)
                {
                    if (CurrentIndex != 1)       // Go Into the Option Menu
                    {

                        CurrentOptInd = 2;
                        inOption = true;
                    }
                }
            }   
        }  
    }
     
                  ////////////////////////////////////-TheGeneralVoid-////////////////////////////////

    public class Program
    {
        public static void Main()
        {
            FarManager UserOne = new FarManager();
            UserOne.OpenDirectory("/users/Azat/Downloads/");
        }
    }
}
   