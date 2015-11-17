namespace Scanner
{
    using System;

    public static class Logger
    {
        public enum Level
        {
            Debug = 0,
            Info = 1,
            Error = 2
        }

        public static Level CurrentLevel { get; set; }

        public static void Info(string format, params object[] args)
        {
            Write(Level.Info, ConsoleColor.Gray, format, args);
        }

        public static void Debug(string format, params object[] args)
        {
            Write(Level.Debug, ConsoleColor.DarkRed, format, args);
        }

        public static void Error(string format, params object[] args)
        {
            Write(Level.Error, ConsoleColor.White, format, args);
        }

        private static void Write(Level minimumLevel, ConsoleColor colour, string format, params object[] args)
        {
            if (CurrentLevel > minimumLevel) { return; }

            Console.ForegroundColor = colour;
            Console.WriteLine(format, args);
            Console.ResetColor();
        }
    }
}
