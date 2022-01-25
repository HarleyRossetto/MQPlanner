namespace Planner.Api.Tools.Statistics;

using System.Reflection;

public class ObjectStatistics
{
    /*
        Statistics
            Type: Name


    */
    public static Statistics GetObjectStatistics<T>(IEnumerable<T> objectCollection, bool b) {
        if (objectCollection is null || !objectCollection.Any()) {
            return new Statistics() { TypeName = "__InputNull" };
        }

        var objType = objectCollection.First()?.GetType();
        var objProperties = objType.GetProperties();

        var stats = new Statistics() { TypeName = objType?.Name };

        /*
            Select each property that is public.
            Get the value as a string and add it to the stats value dictionary, or increment the counter if it already exists.
        */
        var validProperties = from property in objProperties
                              where property.GetMethod.IsPublic
                              select property;

        //For each object in the collection parameter
        foreach (var listItem in objectCollection) {
            stats.Properties.Add(GetObjectStatistics(listItem));
            /* if (listItem is not null) {


                 foreach (var prop in validProperties) {
                     var newStat = new Statistics() { TypeName = prop.Name };
                     stats.Properties.Add(newStat);

                     var key = prop.GetValue(listItem)?.ToString() ?? "null";

                     if (newStat.Values.ContainsKey(key)) {
                         newStat.Values[key]++;
                     } else {
                         newStat.Values.Add(key, 1);
                     }

                     if (prop.DeclaringType?.Assembly.GetName().Name?.Contains("MQHandbookLib") ?? false) {
                         newStat.Properties.Add(GetObjectStatistics(prop.GetValue(listItem)));
                     }
                 }
             }
             */
        }

        return stats;
    }

    public static Statistics GetObjectStatistics<T>(T obj) {
        if (obj is null) {
            return new Statistics() { TypeName = "__InputNull" };
        }

        var objType = obj.GetType();
        var objProperties = objType.GetProperties(BindingFlags.Public);

        var stats = new Statistics() { TypeName = objType.Name };

        //For each object in the collection parameter
        /*
            Select each property that is public.
            Get the value as a string and add it to the stats value dictionary, or increment the counter if it already exists.
        */
        var validProperties = from property in objProperties
                              where property.GetMethod.IsPublic
                              select property;

        foreach (var prop in validProperties) {
            var key = prop.GetValue(obj)?.ToString() ?? "null";

            if (stats.Values.ContainsKey(key)) {
                stats.Values[key]++;
            } else {
                stats.Values.Add(key, 1);
            }

            if (prop.DeclaringType?.Assembly.GetName().Name?.Contains("MQHandbookLib") ?? false) {
                stats.Properties.Add(GetObjectStatistics(new List<Object>() { prop.GetValue(obj) }));
            }
        }

        return stats;
    }
}

public class Statistics
{
    public string? TypeName { get; set; } = string.Empty;
    public List<Statistics> Properties { get; set; } = new();
    public Dictionary<string, int> Values { get; set; } = new();
}