// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: MIT

using System.Net.Http;

namespace Tribufu
{
    public class TribufuApi : TribufuApiGenerated
    {
        public TribufuApi(TribufuApiOptions options) : base(options.BaseUrl, new HttpClient())
        {
        }
    }
}
