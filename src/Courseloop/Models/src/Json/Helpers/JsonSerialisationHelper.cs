namespace Courseloop.Models.Json.Helpers;

using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class JsonSerialisationHelper
{
    public static T DeserialiseJsonObject<T>(string json) => JsonConvert.DeserializeObject<T>(json);

    public static string SerialiseObject(object obj, Formatting formatting = Formatting.Indented)
    {
        return JsonConvert.SerializeObject(obj, formatting, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, Converters = { new StringEnumConverter() } });
    }

    public async Task SerialiseObjectToJsonFile(object obj, string fileName, bool saveWithTimeStamp = false, Formatting formatting = Formatting.Indented)
    {
        var jsonString = SerialiseObject(obj, formatting);

        fileName = (saveWithTimeStamp ? $"{fileName}_{DateTime.Now:yyMMddHHmmss_fffff}" : fileName);

        await File.WriteAllTextAsync(fileName, jsonString);
    }
}
