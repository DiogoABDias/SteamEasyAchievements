﻿using Serilog;
using Serilog.Core;

namespace SteamEasyAchievements.Core
{
    internal static class Log
    {
        //Fields
        private static readonly Logger _logger;

        //Constructor
        static Log()
        {
            _logger = new LoggerConfiguration()
                        .WriteTo.File("log.txt")
                        .CreateLogger();
        }

        //Methods
        internal static void Fatal(Exception exception)
        {
            _logger.Fatal(exception, "exception");
        }
    }
}