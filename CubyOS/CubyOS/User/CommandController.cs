using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace CubyOS.User
{
    public class CommandController
    {
        public void StartCommand(string input)
        {
            if (input == "help") // HELP
            {
                Console.WriteLine(" help -- Shows this List.");
                Console.WriteLine(" info (-v) -- Shows OS infos.");
                Console.WriteLine(" shutdown -- shutdown the OS.");
                Console.WriteLine();
                Console.WriteLine(" ## Console Controll ##");
                Console.WriteLine(" echo {input1} -- prints input1");
                Console.WriteLine(" cls -- Clears the Console.");
                Console.WriteLine();
                Console.WriteLine(" ## Directory Controll ##");
                Console.WriteLine(" ls -- Shows all Directories in the Current Directorie.");
                Console.WriteLine(" cd {path} -- Goes to referenzed Directory.");
                Console.WriteLine(" mkdir {path} -- Create Directory.");
                Console.WriteLine(" rmdir (-r) {path} -- Delete Directory.");
                Console.WriteLine();
                Console.WriteLine(" ## File Controll ##");
                Console.WriteLine(" touch -- Create File.");
                Console.WriteLine(" rm -- Delete Directory.");
            }
            else if (input.StartsWith("info")) // INFO
            {
                if (input.Length == 4)
                {
                    Console.WriteLine(" Copyright to GreenData17");
                    Console.WriteLine($" CubyOS [{System.Kernel.Instance.version}]");
                    Console.WriteLine("   CommandLineOnly");
                    Console.WriteLine("   Cosmos Kernel in use");
                }
                else
                {
                    string i = input.Remove(0, 5);
                    if (i == "-v")
                    {
                        Console.WriteLine($" {System.Kernel.Instance.version}");
                    }
                    else
                    {
                        Console.WriteLine(" [ERROR] this is not a valid parameter!");
                    }
                }
            }
            else if (input.StartsWith("echo ")) // ECHO
            {
                if (input.StartsWith("echo -f "))
                {
                    if (input.Remove(0, 8).StartsWith("0"))
                    {
                        if (File.Exists(input.Remove(0, 8)))
                            for (int i = 0; i < File.ReadAllLines(input.Remove(0, 8)).Length; i++)
                            {
                                Console.WriteLine(File.ReadAllLines(input.Remove(0, 8))[i]);
                            }
                        else
                            Console.WriteLine(" [ERROR] This File does not exists.");
                    }
                    else
                    {
                        if (File.Exists(System.Kernel.Instance.CurrentDir + input.Remove(0, 8)))
                            for (int i = 0; i < File.ReadAllLines(System.Kernel.Instance.CurrentDir + input.Remove(0, 8)).Length; i++)
                            {
                                Console.WriteLine(File.ReadAllLines(System.Kernel.Instance.CurrentDir + input.Remove(0, 8))[i]);
                            }
                        else
                            Console.WriteLine(" [ERROR] This File does not exists.");
                    }
                }
                else
                {
                    Console.WriteLine(" " + input.Remove(0, 5));
                }
            }
            else if (input == "cls" || input == "clear") // CLEAR
            {
                Console.Clear();
            }
            else if (input.StartsWith("shutdown")) //shutdown
            {
                if (input.Length == 8)
                {
                    Sys.Power.Shutdown();
                }
                else
                {
                    string i = input.Remove(0, 9);
                    if (i == "-r")
                    {
                        Sys.Power.Reboot();
                    }
                    else
                    {
                        Console.WriteLine(" [ERROR] this is not a valid parameter!");
                    }
                }
            }
            else if (input == "ls") // LS
            {
                try
                {
                    string[] dirs = Directory.GetDirectories(System.Kernel.Instance.CurrentDir);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    foreach (string s in dirs)
                    {
                        Console.WriteLine(" <DIR>  " + s);
                    }
                }
                catch { }

                
                try
                {
                    string[] files = Directory.GetFiles(System.Kernel.Instance.CurrentDir);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    foreach (string s in files)
                    {
                        //if (!s.EndsWith(".null"))
                            Console.WriteLine(" <FILE> " + s);
                    }
                }
                catch { }

                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (input.StartsWith("cd ")) // CD
            {
                string i = input.Remove(0, 3);
                if (!i.StartsWith("0"))
                {
                    if (Directory.Exists(System.Kernel.Instance.CurrentDir + i + @"\"))
                    {
                        System.Kernel.Instance.CurrentDir = System.Kernel.Instance.CurrentDir + i + @"\";
                    }
                    else if (input == "cd ..")
                    {
                        System.Kernel.Instance.CurrentDir = Path.GetDirectoryName(System.Kernel.Instance.CurrentDir);
                    }
                    else { Console.WriteLine(" [ERROR] this is not a valid path!"); }
                }
                else
                {
                    if (Directory.Exists(i))
                    {
                        System.Kernel.Instance.CurrentDir = i;
                    }
                    else { Console.WriteLine(" [ERROR] this is not a valid path!"); }
                }
            }
            else if(input.StartsWith("mkdir "))
            {
                if (input.Remove(0, 6).StartsWith("0"))
                {
                    Directory.CreateDirectory(input.Remove(0, 6));
                }
                else
                {
                    Directory.CreateDirectory(System.Kernel.Instance.CurrentDir + input.Remove(0, 6));
                }
            }
            else if (input.StartsWith("rmdir "))
            {
                if(input.Remove(0, 6).StartsWith("-r "))
                {
                    if (input.Remove(0, 9).StartsWith("0"))
                    {
                        if (Directory.Exists(input.Remove(0, 9)))
                            try { Directory.Delete(input.Remove(0, 9), true); } catch { Console.WriteLine(" [ERROR] Something went wrong."); }
                        else
                            Console.WriteLine(" [ERROR] This Directory does not exists.");
                    }
                    else
                    {
                        if (Directory.Exists(System.Kernel.Instance.CurrentDir + input.Remove(0, 9)))
                            try { Directory.Delete(System.Kernel.Instance.CurrentDir + input.Remove(0, 9), true); } catch { Console.WriteLine(" [ERROR] Something went wrong."); }
                        else
                            Console.WriteLine(" [ERROR] This Directory does not exists.");
                    }
                }
                else if (input.Remove(0, 6).StartsWith("0"))
                {
                    if(Directory.Exists(input.Remove(0, 6)))
                        try{ Directory.Delete(input.Remove(0, 6)); } catch { Console.WriteLine(" [ERROR] This Directory is not empty."); }
                    else
                        Console.WriteLine(" [ERROR] This Directory does not exists.");
                }
                else
                {
                    if (Directory.Exists(System.Kernel.Instance.CurrentDir + input.Remove(0, 6)))
                        try { Directory.Delete(System.Kernel.Instance.CurrentDir + input.Remove(0, 6)); } catch { Console.WriteLine(" [ERROR] This Directory is not empty."); }
                    else 
                        Console.WriteLine(" [ERROR] This Directory does not exists.");
                }
            }
            else
            {
                Console.WriteLine(" [ERROR] this is not a valid Command!");
            }
        }
    }
}
