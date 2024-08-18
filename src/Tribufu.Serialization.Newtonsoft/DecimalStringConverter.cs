// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: MIT

using System;
using Newtonsoft.Json;

namespace Tribufu.Serialization.Newtonsoft
{
    public class DecimalStringConverter : JsonConverter<decimal>
    {
        public override decimal ReadJson(JsonReader reader, Type objectType, decimal existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return decimal.Parse(reader.ToString());
        }

        public override void WriteJson(JsonWriter writer, decimal value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
