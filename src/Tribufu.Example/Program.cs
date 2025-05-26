// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: UNLICENSED

using dotenv.net;
using Tribufu.Api;
using Tribufu.Client;

namespace Tribufu.Test
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            DotEnv.Load(new DotEnvOptions(ignoreExceptions: true, envFilePaths: [".env", "../../.env"]));

            var config = new Configuration
            {
                BasePath = "https://api.tribufu.com"
            };

            var apiKey = Environment.GetEnvironmentVariable("TRIBUFU_API_KEY");
            if (!string.IsNullOrEmpty(apiKey))
            {
                config.AddApiKey("Authorization", "DvyTVeT6EBsvqsPE1mRuW7ewwiP1f9playWE9wLTmdXnCuBQqBrluhU0p1KXYaRi");
                config.AddApiKeyPrefix("Authorization", "ApiKey");
            }

            var tribufu = new TribufuApi(config);

            try
            {
                var result = await tribufu.GetUserInfoAsync();
                Console.WriteLine("Result:");
                Console.WriteLine(result);
            }
            catch (ApiException e)
            {
                Console.WriteLine("---- API Error ----");
                Console.WriteLine($"Status: {e.ErrorCode}");
                Console.WriteLine($"Details: {e.Data}");
            }
        }
    }
}
