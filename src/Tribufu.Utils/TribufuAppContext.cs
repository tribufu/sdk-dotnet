// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: MIT

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Tribufu.Utils
{
    public static class TribufuAppContext
    {
        public static string GetBaseDirectory()
        {
            string defaultBaseDirectory = AppContext.BaseDirectory;
            string baseDirectory;

            if (defaultBaseDirectory.Contains("Debug") || defaultBaseDirectory.Contains("Release"))
            {
                baseDirectory = Path.Combine(defaultBaseDirectory, "..", "..", "..", "..", "..");
            }
            else
            {
                baseDirectory = Path.Combine(defaultBaseDirectory, "..", "..");
            }

            baseDirectory = Path.GetFullPath(baseDirectory);

            return baseDirectory;
        }

        public static string GetBinDirectory()
        {
            var binDirectory = Path.Combine(GetBaseDirectory(), "bin");

            if (!string.IsNullOrEmpty(RuntimeInformation.RuntimeIdentifier))
            {
                binDirectory = Path.Combine(binDirectory, RuntimeInformation.RuntimeIdentifier);
            }
            else
            {
                binDirectory = Path.Combine(binDirectory, "dotnet");
            }

            return binDirectory;
        }

        public static string GetConfigDirectory()
        {
            return Path.Combine(GetBaseDirectory(), "config");
        }

        public static string GetAssetsDirectory()
        {
            return Path.Combine(GetBaseDirectory(), "assets");
        }

        public static string GetSavedDirectory()
        {
            return Path.Combine(GetBaseDirectory(), "saved");
        }

        public static string GetCacheDirectory()
        {
            return Path.Combine(GetSavedDirectory(), "cache");
        }

        public static string GetLogsDirectory()
        {
            return Path.Combine(GetSavedDirectory(), "logs");
        }
    }
}
