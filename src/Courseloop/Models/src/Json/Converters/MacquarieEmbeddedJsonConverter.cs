namespace Courseloop.Models.Json.Converters;

using System;
using System.Diagnostics.CodeAnalysis;
using static Courseloop.Models.Json.Helpers.JsonSerialisationHelper;
using Newtonsoft.Json;


public class MacquarieEmbeddedJsonConverter<T> : JsonConverter<T>
{
    public override T ReadJson(JsonReader reader, Type objectType, [AllowNull] T existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        //If the reader.value is null than the input is not an embedded json string
        if (reader.Value is null)
            return serializer.Deserialize<T>(reader);
        else
        {
            //Otherwise reader.Value is an embedded json string so do the conversion
            return DeserialiseJsonObject<T>((string)reader.Value);
        }
    }

    public override void WriteJson(JsonWriter writer, [AllowNull] T value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}
