// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: MIT

using System;
using Newtonsoft.Json;

namespace Tribufu.Serialization.Newtonsoft
{
    public class LongStringConverter : JsonConverter<ulong>
    {
        public override ulong ReadJson(JsonReader reader, Type objectType, ulong existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return ulong.Parse(reader.ToString());
        }

        public override void WriteJson(JsonWriter writer, ulong value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
