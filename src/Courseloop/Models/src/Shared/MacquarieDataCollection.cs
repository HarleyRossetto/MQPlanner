namespace Courseloop.Models.Shared;

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;


public class MacquarieDataCollection<T> where T : MacquarieMetadata
{
    //Empty constructor for JSON.net to use
    public MacquarieDataCollection() { }

    public MacquarieDataCollection(int capacity)
    {
        Collection = new List<T>(capacity);
    }

    public MacquarieDataCollection(IEnumerable<T> tempCollection)
    {
        Collection = new List<T>(tempCollection);
    }

    [JsonProperty("contentlets")]
    public List<T> Collection { get; set; }

    public T this[int index] { get => Collection[index]; set => Collection[index] = value; }

    public int Count { get => Collection.Count; }

    public IEnumerator<T> GetEnumerator() => Collection.GetEnumerator();

    public void Add(T value) => Collection.Add(value);

    public IEnumerable<T> AsEnumerable()
    {
        return Collection.AsEnumerable();
    }
}
