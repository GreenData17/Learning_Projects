using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngineSuper.Engine.DataTypes
{
    public struct DebugColor
    {
        public static ConsoleColor Error() { return ConsoleColor.Red; }
        public static ConsoleColor Warning() { return ConsoleColor.Yellow; }
        public static ConsoleColor Info() { return ConsoleColor.Blue; }
        public static ConsoleColor Engine() { return ConsoleColor.White; }
    }
}
