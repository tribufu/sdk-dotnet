// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: MIT

namespace Tribufu
{
    public class TribufuApiOptions
    {
        public string BaseUrl { get; set; }

        public string ApiKey { get; set; }

        public TribufuApiOptions(string baseUrl, string apiKey)
        {
            BaseUrl = baseUrl;
            ApiKey = apiKey;
        }
    }
}
