using Reactives;
using System.Collections.Generic;
using UnityEngine;

public class DataScript {
    public static Dictionary<Reactive, int> values = new Dictionary<Reactive, int>();

    override public string ToString()
    {
        if (values.Count == 0)
        {
            return "{}";
        }
        string result = "{";
        foreach (KeyValuePair<Reactive, int> reactive in values)
        {
            result += reactive.Key + "=" + reactive.Value + ", ";
        }
        result = result.Substring(0, result.Length - 2) + "}";
        return result;
    }
}
