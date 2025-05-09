using System.Collections.Generic;

public class Blackboard {
    private Dictionary<string, object> data = new();

    public void Set<T>(string key, T value) {
        data[key] = value;
    }

    public bool TryGet<T>(string key, out T value) {
        if (data.TryGetValue(key, out var obj) && obj is T t) {
            value = t;
            return true;
        }
        value = default;
        return false;
    }

    public T Get<T>(string key) {
        if (TryGet(key, out T val)) {
            return val;
        }
        throw new KeyNotFoundException($"Blackboard: no key '{key}'");
    }

    public bool Contains(string key) {
        return data.ContainsKey(key);
    }
}