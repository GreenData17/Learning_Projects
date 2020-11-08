using System;

namespace Calculator.Engine
{
    public class Debug //contains the Console Feedback functions
    {
        public static void LogCreate(string m) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(" " + $"[{DateTime.UtcNow.ToString("HH:mm:ss")}]  " + m); }
        public static void LogDestroy(string m) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(" " + $"[{DateTime.UtcNow.ToString("HH:mm:ss")}]  " + m); }
        public static void LogInfo(string m) { Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"[{DateTime.UtcNow.ToString("HH:mm:ss")} | INFO]  " + m); }
        public static void LogError(string m) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"[{DateTime.UtcNow.ToString("HH:mm:ss")} | ERROR]  " + m); }
    }
}
