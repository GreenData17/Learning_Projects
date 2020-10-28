using System;

namespace GameEngine.Engine
{
    public class Debug
    {
        public static void Log(string m) { Console.ForegroundColor = ConsoleColor.White; Console.WriteLine($"[{DateTime.UtcNow.ToString("HH:mm:ss")}] LOG - {m}"); }
        public static void LogSystem(string m) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"[{DateTime.UtcNow.ToString("HH:mm:ss")}] SYS - {m}"); }
        public static void LogInfo(string m) { Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine($"[{DateTime.UtcNow.ToString("HH:mm:ss")}] INFO - {m}"); }
        public static void LogCreate(string m) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"[{DateTime.UtcNow.ToString("HH:mm:ss")}] ADD - {m}"); }
        public static void LogDestroy(string m) { Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine($"[{DateTime.UtcNow.ToString("HH:mm:ss")}] RM - {m}"); }
        public static void LogError(string m) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"[{DateTime.UtcNow.ToString("HH:mm:ss")}] ERR - {m}"); }
        public static void LogSpace() { Console.WriteLine(); }
    }
}
