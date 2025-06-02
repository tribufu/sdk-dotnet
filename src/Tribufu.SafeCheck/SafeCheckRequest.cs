// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: MIT

using Newtonsoft.Json;

namespace Tribufu.SafeCheck
{
    public class SafeCheckRequest
    {
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        public SafeCheckRequest(string imageUrl)
        {
            ImageUrl = imageUrl;
        }
    }
}
