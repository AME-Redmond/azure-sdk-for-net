// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Media.Analytics.Edge.Models
{
    public partial class MediaGraphImageFormat : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@type");
            writer.WriteStringValue(Type);
            writer.WriteEndObject();
        }

        internal static MediaGraphImageFormat DeserializeMediaGraphImageFormat(JsonElement element)
        {
            if (element.TryGetProperty("@type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Media.MediaGraphImageFormatBmp": return MediaGraphImageFormatBmp.DeserializeMediaGraphImageFormatBmp(element);
                    case "#Microsoft.Media.MediaGraphImageFormatJpeg": return MediaGraphImageFormatJpeg.DeserializeMediaGraphImageFormatJpeg(element);
                    case "#Microsoft.Media.MediaGraphImageFormatPng": return MediaGraphImageFormatPng.DeserializeMediaGraphImageFormatPng(element);
                    case "#Microsoft.Media.MediaGraphImageFormatRaw": return MediaGraphImageFormatRaw.DeserializeMediaGraphImageFormatRaw(element);
                }
            }
            string type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
            }
            return new MediaGraphImageFormat(type);
        }
    }
}
