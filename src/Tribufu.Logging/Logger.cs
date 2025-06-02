// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: MIT

using System;

namespace Tribufu.Logging
{
    public static class Logger
    {
        private static LogLevel _level = LogLevel.Off;

        public static void Initialize(LogLevel level = LogLevel.Off)
        {
            _level = level;
        }

        public static void Info(string message)
        {
            Log(LogLevel.Info, message, ConsoleColor.Green);
        }

        public static void Warn(string message)
        {
            Log(LogLevel.Warn, message, ConsoleColor.Yellow);
        }

        public static void Error(string message)
        {
            Log(LogLevel.Error, message, ConsoleColor.Red);
        }

        public static void Debug(string message)
        {
            Log(LogLevel.Debug, message, ConsoleColor.White);
        }

        public static void Trace(string message)
        {
            Log(LogLevel.Trace, message, ConsoleColor.Gray);
        }

        private static void Log(LogLevel level, string message, ConsoleColor color)
        {
            if (_level == LogLevel.Off)
            {
                return;
            }

            if (_level == LogLevel.All || level >= _level)
            {
                var defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                var timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                Console.WriteLine($"[{timestamp}] [{level.ToString().ToUpper()}]: {message}");
                Console.ForegroundColor = defaultColor;
            }
        }
    }
}
