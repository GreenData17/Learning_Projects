using System;

namespace Calculator.Engine
{
    public class Debug
    {
        public static void LogCreate(string m) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(" " + $"[{DateTime.UtcNow.ToString("HH:mm:ss")}]  " + m); }
        public static void LogDestroy(string m) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(" " + $"[{DateTime.UtcNow.ToString("HH:mm:ss")}]  " + m); }
        public static void LogInfo(string m) { Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"[{DateTime.UtcNow.ToString("HH:mm:ss")}]  " + m); }
    }
}
