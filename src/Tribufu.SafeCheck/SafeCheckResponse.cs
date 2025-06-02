// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: MIT

using Newtonsoft.Json;

namespace Tribufu.SafeCheck
{
    public class SafecheckResponse
    {
        [JsonProperty("safe")]
        public bool Safe { get; set; }

        [JsonProperty("reason")]
        public string? Reason { get; set; }

        [JsonProperty("detections")]
        public SafeCheckDetections? Detections { get; set; }
    }
}
