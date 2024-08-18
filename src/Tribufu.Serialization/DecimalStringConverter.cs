// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: MIT

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tribufu.Serialization
{
    public class DecimalStringConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Convert.ToUInt64(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
