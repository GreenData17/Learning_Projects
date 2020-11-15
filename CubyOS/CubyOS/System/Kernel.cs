using Cosmos.System.ScanMaps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Sys = Cosmos.System;
using CubyOS.User;

namespace CubyOS.System
{
    public class Kernel : Sys.Kernel
    {
        public static Kernel Instance;
        public UserManager userManager = new UserManager();
        public CommandController CC = new CommandController();
        public Sys.FileSystem.CosmosVFS fs;

        public string version = "0.1.0 (Alpha)";

        public string CurrentDir = @"0:\";
        public string CurrentUser = "";

        protected override void BeforeRun()
        {
            Instance = this;

            fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            fs.Initialize();

            userManager.Login();
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CubyOS booted successfully.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected override void Run()
        {
            

            Console.Write(CurrentDir + " > ");
            string input = Console.ReadLine();
            Console.WriteLine();
            CC.StartCommand(input);
        }

        // Logo
        public static void DrawLogo()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"|-----------------------------------------------|                               ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(@"|   ____  _    _ ____ _     _           +----+  |                               ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(@"|  / __ \| |  | |  _ \ \   / /         /    /|  |                               ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(@"| | |  |_| |  | | |_|/\ \_/ /         +----+ |  |                               ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(@"| | |   _| |  | |  _ \ \   /          |    | +  |                               ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(@"| | |__| | |__| | |_||  | |           |    |/   |                               ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(@"|  \____/ \_____|____/  |_|           +----+    |                               ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(@"|-----------------------------------------------|                               ");
        }
    }
}
