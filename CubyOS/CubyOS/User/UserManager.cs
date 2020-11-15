using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace CubyOS.User
{
    public class UserManager
    {
        string username = "";
        string password = "";

        public void Login()
        {
            ConsoleKeyInfo i;

            if (!File.Exists(@"0:\system")) // SETUP
            {
                Console.CursorVisible = false;

            Setup:
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
                System.Kernel.DrawLogo();
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Greendata17 Cuby-OS {System.Kernel.Instance.version} Setup");
                Console.WriteLine($"=========================================");
                Console.WriteLine($"");
                Console.WriteLine($"          Welcome to Setup.");
                Console.WriteLine($"");
                Console.WriteLine($"          The Setup prepares Cuby-OS to run on your computer.");
                Console.WriteLine($"");
                Console.WriteLine($"            @ To set up Cuby-OS now, press ENTER.");
                Console.WriteLine($"");
                Console.WriteLine($"            @ To Exit Setup without installing Cuby-OS, press ESCAPE.");
                Console.WriteLine($"");
                Console.WriteLine($"          Note: If there is still files on this computer, please make a backup.");
                Console.WriteLine($"                After Setup, you might not be able to access your files.");
                Console.WriteLine($"");
                Console.WriteLine($"          To continue Setup, press ENTER.");
                Console.WriteLine();
                i = Console.ReadKey(true);

                if (i.Key != ConsoleKey.Enter)
                {
                    if (i.Key == ConsoleKey.Escape) { Sys.Power.Shutdown(); }
                    Console.Write("\b");
                    goto Setup;
                }

                username = SetVariableText("USERNAME");

                password = SetVariableText("PASSWORD");


                Console.Clear();
                System.Kernel.DrawLogo();
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Greendata17 Cuby-OS {System.Kernel.Instance.version} Setup");
                Console.WriteLine($"=========================================");
                Console.WriteLine($"");
                Console.WriteLine($" Deleting old data...");

                try
                {
                    string[] dirs = Directory.GetDirectories(@"0:\");
                    foreach (string s in dirs)
                    {
                        Directory.Delete($@"0:\{s}", true);
                    }
                }
                catch { }

                try
                {
                    string[] files = Directory.GetFiles(@"0:\");
                    foreach (string s in files)
                    {
                        File.Delete($@"0:\{s}");
                    }
                }
                catch { }

                Console.WriteLine($"");
                Console.WriteLine($" Creating system data...");

                Directory.CreateDirectory(@"0:\system");
                Directory.CreateDirectory(@"0:\system\users");

                try
                {
                    File.WriteAllText(@"0:\system.null", "sudo");
                    File.WriteAllText(@"0:\system\users.null", "sudo");
                    //File.WriteAllText(@"0:\system\boot.txt", "CubyOS booted successfully. Type \"help\" for a list of commands.");
                    //string h1 = $@"0:\system\users\{username}.sys"; string h2 = $"{password} sudo";
                    //File.WriteAllText(h1, h2);
                }
                catch { }

                Console.WriteLine($"");
                Console.WriteLine($" Creating user data...");

                try
                {
                    //Directory.CreateDirectory(@"0:\users");
                    //string h1 = $@"0:\users\{username}";
                    //Directory.CreateDirectory(h1);
                    //string h2 = $@"0:\users\{username}.null";
                    //File.CreateText(h2);
                }
                catch { }




                Console.WriteLine($"");
                Console.WriteLine($" Creating completed! Press any key to restart the system...");

                Console.ReadKey();

                //Sys.Power.Reboot();

            }
            else // LOGIN
            {

            }

            Console.ReadLine();
        }


        public string SetVariableText(string name)
        {
        PART_S:
            ConsoleKeyInfo i;

            string returner = "";

            string a = "_____________________________________________________";
            a = name + ": " + returner + a.Remove(0, name.Length + 2 + returner.Length);

            Console.Clear();
            System.Kernel.DrawLogo();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Greendata17 Cuby-OS {System.Kernel.Instance.version} : Setup");
            Console.WriteLine($"=========================================");
            Console.WriteLine($"");
            Console.WriteLine($"         +-------------------------------------------------------+");
            Console.WriteLine($"         | {a} |");
            Console.WriteLine($"         +-------------------------------------------------------+");

            int consoleTop = Console.CursorTop - 2;

        PART1:
            i = Console.ReadKey(true);

            if(i.Key != ConsoleKey.Enter && i.Key != ConsoleKey.Backspace)
            {
                if (returner.Length < 44)
                    returner += i.KeyChar;
                else if(returner.Length == 44) { Sys.PCSpeaker.Beep(); goto PART1; }

                Console.SetCursorPosition(11, consoleTop);
                a = "_____________________________________________________";
                a = name + ": " + returner + a.Remove(0, name.Length + 2 + returner.Length);
                Console.Write(a);
                goto PART1;
            }else if (i.Key == ConsoleKey.Backspace)
            {
                if(returner.Length == 0)
                {
                    Sys.PCSpeaker.Beep();
                    goto PART1;
                }
                returner = returner.Remove(returner.Length - 1);
                Console.SetCursorPosition(11, consoleTop);
                a = "_____________________________________________________";
                a = name + ": " + returner + a.Remove(0, name.Length + 2 + returner.Length);
                Console.Write(a);
                goto PART1;
            }

            // Bestätigung hier!

            string b;

            a = "                                                     ";
            b = "                                                     ";
            a = returner + a.Remove(0, returner.Length);
            b = "Your " + name + " is:" + b.Remove(0, 9 + name.Length);

            


            Console.Clear();
            System.Kernel.DrawLogo();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Greendata17 Cuby-OS {System.Kernel.Instance.version} : Setup");
            Console.WriteLine($"=========================================");
            Console.WriteLine($"");
            Console.WriteLine($"         +-------------------------------------------------------+");
            Console.WriteLine($"         | {b} |");
            Console.WriteLine($"         | {a} |");
            Console.WriteLine($"         |                    is this correct?                   |");
            Console.WriteLine($"         +-------------------------------------------------------+");
            Console.WriteLine($"         |          Yes (y)          |           No (n)          |");
            Console.WriteLine($"         +-------------------------------------------------------+");

            i = Console.ReadKey(true);

            if (i.Key != ConsoleKey.Y)
            {
                goto PART_S;
            }


            return returner;
        }


        #region old
        //public void Login()
        //{
        //    if (!Directory.Exists(@"0:\System"))
        //    {
        //        Setup();
        //    }
        //    else
        //    {
        //        Console.Clear();
        //        string[] s = Directory.GetDirectories(@"0:/");
        //        foreach(string st in s)
        //        {
        //            Console.WriteLine(st);
        //        }
        //        Console.WriteLine("# LOGIN #");
        //        Console.WriteLine();
        //        Console.Write("Username: ");
        //        string u = Console.ReadLine();
        //        if(u == "F12_55") { Directory.Delete(@"0:\System", true); Login(); return; }
        //        Console.Clear();
        //        Console.WriteLine("# LOGIN #");
        //        Console.WriteLine();
        //        Console.Write("Password: ");
        //        string p = Console.ReadLine();

        //        if (File.Exists(@"0:\System\users.sys"))
        //        {
        //            string[] us = File.ReadAllLines(@"0:\System\users.sys");
        //            if (us[0] != $"{u} {p}")
        //            {
        //                Sys.Power.Reboot();
        //            }
        //            else
        //            {
        //                Console.WriteLine(File.ReadAllText(@"0:\System\welcome.txt"));
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("[ERROR] File not found!");
        //            Console.ReadLine();
        //        }
        //    }    
        //}

        //public void Setup()
        //{
        //    Console.Clear();
        //    Console.WriteLine("# SETUP #");
        //    Console.WriteLine();
        //    Console.Write("Username: ");
        //    string u = Console.ReadLine();
        //    if (u == "F12_55") { Sys.Power.Reboot(); }
        //    Console.Clear();
        //    Console.WriteLine("# SETUP #");
        //    Console.WriteLine();
        //    Console.Write("Password: ");
        //    string p = Console.ReadLine();
        //    Console.Clear();
        //    Console.WriteLine("# SETUP #");
        //    Console.WriteLine();
        //    Console.Write("repeat Password: ");
        //    string rp = Console.ReadLine();

        //    if(p != rp)
        //    {
        //        Sys.Power.Reboot();
        //    }

        //    Directory.CreateDirectory(@"0:\System");
        //    string[] ss = new string[1];
        //    ss[0] = $"{u} {p}";
        //    File.WriteAllLines(@"0:\System\users.sys", ss);
        //    File.WriteAllText(@"0:\System\welcome.txt", "Welcome to CubyOS!");
        //    Directory.CreateDirectory($@"0:\{u}\dokument");
        //    Console.Write("Press any Key to Reboot...");
        //    Sys.Power.Reboot();
        //}
        #endregion
    }


}
