namespace Courseloop.Models.Json.Converters;

using System;
using Courseloop.Models.Shared;
using Newtonsoft.Json;

public class StringToUnitCodeConverter : JsonConverter<UnitCode>
{
    public override UnitCode ReadJson(JsonReader reader, Type objectType, UnitCode existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        return new UnitCode(reader.ReadAsString());
    }

    public override void WriteJson(JsonWriter writer, UnitCode value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value.ToString());
    }
}
