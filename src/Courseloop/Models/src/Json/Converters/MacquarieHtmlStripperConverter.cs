namespace Courseloop.Models.Json.Converters;

using System;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using Courseloop.Models.Sanitisers;

public class MacquarieHtmlStripperConverter : JsonConverter<string>
{
    public override string ReadJson(JsonReader reader, Type objectType, [AllowNull] string existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        // var result = DeserialiseJsonObject<string>((string)reader.Value);
        return HTMLTagStripper.StripHtmlTags((string)reader.Value);
    }

    public override void WriteJson(JsonWriter writer, [AllowNull] string value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}
