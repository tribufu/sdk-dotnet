// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: MIT

using Newtonsoft.Json;
using RestSharp;

namespace Tribufu.SafeCheck
{
    public sealed class TribufuSafeCheck
    {
        private readonly RestClient _client;

        private readonly string? _apiKey;

        public const string DefaultBaseUrl = "https://safecheck.tribufu.com";

        public TribufuSafeCheck(string? apiKey = null, string baseUrl = DefaultBaseUrl)
        {
            var options = new RestClientOptions(baseUrl)
            {
                UserAgent = TribufuApi.GetUserAgent(),
            };

            _client = new RestClient(options);
            _apiKey = apiKey;
        }

        public async Task<bool> CheckImageAsync(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                throw new ArgumentException("Image URL cannot be null or empty.", nameof(imageUrl));
            }

            var request = new RestRequest("/image", Method.Post);
            request.AddHeader("Content-Type", "application/json");

            if (!string.IsNullOrEmpty(_apiKey))
            {
                request.AddHeader("Authorization", $"ApiKey {_apiKey}");
            }

            var requestBody = new SafeCheckRequest(imageUrl);
            request.AddStringBody(JsonConvert.SerializeObject(requestBody), DataFormat.Json);

            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Request failed: {response.StatusCode} - {response.Content}");
            }

            var result = JsonConvert.DeserializeObject<SafecheckResponse>(response.Content!);
            return result?.Safe ?? false;
        }
    }
}
