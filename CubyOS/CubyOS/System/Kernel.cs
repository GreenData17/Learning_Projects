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
    }
}
