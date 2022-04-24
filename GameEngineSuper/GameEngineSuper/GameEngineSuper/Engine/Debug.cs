using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngineSuper.Engine.DataTypes;

namespace GameEngineSuper.Engine
{
    public class Debug // Manages Everything Debug Related.
    {
        public static void Log(string msg) { Console.ForegroundColor = DebugColor.Info(); Console.WriteLine(msg); }
        public static void LogError(string msg) { Console.ForegroundColor = DebugColor.Error(); Console.WriteLine(msg); }
        // ...
    }
}
