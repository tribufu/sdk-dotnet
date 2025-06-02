// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: MIT

using System;
using System.IO;
using System.Runtime.InteropServices;
using Tribufu.Logging;

namespace Tribufu.Runtime
{
    /// <summary>
    /// Provides standardized access to important application directories, such as config, saved data, logs, and platform-specific binaries.
    /// This is especially useful for abstracting file path logic across environments (development, production, etc).
    /// </summary>
    public static class ApplicationContext
    {
        /// <summary>
        /// Gets the root base directory of the application.
        /// </summary>
        /// <remarks>
        /// - In development, this resolves to the root of the repository (five levels above bin/Debug or bin/Release).
        /// - In production, it resolves to two levels above the binary location.
        /// - It uses case-insensitive checks and runtime heuristics to improve accuracy.
        /// </remarks>
        /// <returns>The absolute path to the base directory.</returns>
        public static string GetBaseDirectory()
        {
            try
            {
                string baseDirectory;
                string defaultBaseDirectory = AppContext.BaseDirectory;

                bool isDevelopment = defaultBaseDirectory.ToLowerInvariant().Contains("debug");

                if (isDevelopment)
                {
                    // Go 5 levels up to simulate project root
                    baseDirectory = Path.Combine(defaultBaseDirectory, "..", "..", "..", "..", "..");
                }
                else
                {
                    baseDirectory = Path.Combine(defaultBaseDirectory, "..", "..");
                }

                return Path.GetFullPath(baseDirectory);
            }
            catch (Exception ex)
            {
                Logger.Warn($"(ApplicationContext) Failed to resolve base directory: {ex.Message}");
                return AppContext.BaseDirectory;
            }
        }

        /// <summary>
        /// Gets the path to the platform-specific binary directory.
        /// </summary>
        /// <returns>
        /// The absolute path to <c>bin/&lt;runtime-identifier&gt;</c> if available,
        /// otherwise falls back to <c>bin/dotnet</c>.
        /// </returns>
        public static string GetBinDirectory()
        {
            var binDirectory = Path.Combine(GetBaseDirectory(), "bin");

#if NETSTANDARD
            var runtimeIdentifier = GetRuntimeIdentifierLegacy();

            if (!string.IsNullOrEmpty(runtimeIdentifier))
            {
                binDirectory = Path.Combine(binDirectory, runtimeIdentifier);
            }
            else
            {
                binDirectory = Path.Combine(binDirectory, "dotnet");
            }
#else
            if (!string.IsNullOrEmpty(RuntimeInformation.RuntimeIdentifier))
            {
                binDirectory = Path.Combine(binDirectory, RuntimeInformation.RuntimeIdentifier);
            }
            else
            {
                binDirectory = Path.Combine(binDirectory, "dotnet");
            }
#endif

            return binDirectory;
        }

        private static string GetRuntimeIdentifierLegacy()
        {
            string osPart;
            PlatformID platform = Environment.OSVersion.Platform;

            switch (platform)
            {
                case PlatformID.Win32NT:
                    osPart = "win";
                    break;
                case PlatformID.Unix:
                    if (IsMacOS())
                        osPart = "osx";
                    else
                        osPart = "linux";
                    break;
                case PlatformID.MacOSX:
                    osPart = "osx";
                    break;
                default:
                    osPart = "unknown";
                    break;
            }

            var archPart = Environment.Is64BitProcess ? "x64" : "x86";
            if (osPart == "unknown")
            {
                return null;
            }

            return $"{osPart}-{archPart}";
        }

        private static bool IsMacOS()
        {
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                Version version = Environment.OSVersion.Version;

                if (version.Major >= 19)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the path to the configuration directory.
        /// </summary>
        /// <returns>The absolute path to the <c>config</c> directory.</returns>
        public static string GetConfigDirectory()
        {
            return Path.Combine(GetBaseDirectory(), "config");
        }

        /// <summary>
        /// Gets the path to the assets directory.
        /// </summary>
        /// <returns>The absolute path to the <c>assets</c> directory.</returns>
        public static string GetAssetsDirectory()
        {
            return Path.Combine(GetBaseDirectory(), "assets");
        }

        /// <summary>
        /// Gets the path to the saved data directory.
        /// </summary>
        /// <returns>The absolute path to the <c>saved</c> directory.</returns>
        public static string GetSavedDirectory()
        {
            return Path.Combine(GetBaseDirectory(), "saved");
        }

        /// <summary>
        /// Gets the path to the cache directory inside <c>saved</c>.
        /// </summary>
        /// <returns>The absolute path to the <c>saved/cache</c> directory.</returns>
        public static string GetCacheDirectory()
        {
            return Path.Combine(GetSavedDirectory(), "cache");
        }

        /// <summary>
        /// Gets the path to the logs directory inside <c>saved</c>.
        /// </summary>
        /// <returns>The absolute path to the <c>saved/logs</c> directory.</returns>
        public static string GetLogsDirectory()
        {
            return Path.Combine(GetSavedDirectory(), "logs");
        }
    }
}
