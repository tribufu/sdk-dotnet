// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: UNLICENSED

using dotenv.net;
using Tribufu.Generated.Client;

namespace Tribufu.Test
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            DotEnv.Load(new DotEnvOptions(ignoreExceptions: true, envFilePaths: [".env", "../../.env"]));

            var apiKey = Environment.GetEnvironmentVariable("TRIBUFU_API_KEY");
            var tribufu = new TribufuApi(apiKey ?? "");

            Console.WriteLine(TribufuApi.GetVersion());

            try
            {
                var result = await tribufu.GetUserInfoAsync();
                Console.WriteLine(result);
            }
            catch (ApiException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
