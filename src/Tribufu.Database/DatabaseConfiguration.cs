// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: MIT

using Microsoft.Extensions.Configuration;
using System;

namespace Tribufu.Database
{
    public class DatabaseConfiguration
    {
        public DatabaseDriver Driver { get; set; }

        public string? Version { get; set; }

        public string? Host { get; set; }

        public string? Port { get; set; }

        public string? User { get; set; }

        public string? Password { get; set; }

        public string? Schema { get; set; }

        /// <summary>
        /// Loads the <see cref="DatabaseConfiguration"/> from the "database" section or from root-level keys prefixed with "database_".
        /// </summary>
        /// <param name="configuration">The configuration source.</param>
        /// <returns>The populated <see cref="DatabaseConfiguration"/> instance.</returns>
        public static DatabaseConfiguration Load(IConfiguration configuration)
        {
            var section = configuration.GetSection("database");
            var useRootFallback = !section.Exists();

            string? GetConfig(string key) => useRootFallback ? configuration[$"database_{key}"] : section[key];

            var driverString = GetConfig("driver") ?? throw new Exception("Missing database driver");
            if (!Enum.TryParse<DatabaseDriver>(driverString, true, out var driver))
            {
                throw new Exception($"Unsupported database driver: {driverString}");
            }

            return new DatabaseConfiguration
            {
                Driver = driver,
                Version = GetConfig("version"),
                Host = GetConfig("host"),
                Port = GetConfig("port"),
                User = GetConfig("user"),
                Password = GetConfig("password"),
                Schema = GetConfig("schema")
            };
        }
    }
}
