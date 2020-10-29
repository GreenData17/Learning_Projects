using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Sys = Cosmos.System;

namespace CubyOS
{
    public class Kernel : Sys.Kernel
    {
        public static Kernel Instance;
        public UserManager userManager = new UserManager();
        public Sys.FileSystem.CosmosVFS fs;

        public string CurrentDir = @"0:\";
        public string CurrentUser = "";

        protected override void BeforeRun()
        {
            Instance = this;
            Console.WriteLine("CubyOS booted successfully.");
            Console.WriteLine();

            fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            fs.Initialize();
            
            Console.Clear();
        }

        protected override void Run()
        {
            userManager.Login();
            Console.Write("####");
            Console.Read();
            Sys.Power.Shutdown();
        }
    }
}
