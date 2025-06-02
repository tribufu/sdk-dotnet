// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: MIT

using Newtonsoft.Json;

namespace Tribufu.SafeCheck
{
    public class SafeCheckDetections
    {
        [JsonProperty("sexy")]
        public double Sexy { get; set; }

        [JsonProperty("porn")]
        public double Porn { get; set; }

        [JsonProperty("neutral")]
        public double Neutral { get; set; }

        [JsonProperty("hentai")]
        public double Hentai { get; set; }

        [JsonProperty("drawing")]
        public double Drawing { get; set; }
    }
}
