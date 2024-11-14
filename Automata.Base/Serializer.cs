using Automata.Activities;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Automata;

internal class ActivityTarget<T> where T : IActivity
{
    public string Namespace { get; set; } = string.Empty;
    public T? Instance { get; set; }
}

public sealed class Serializer
{
    private readonly JsonSerializerOptions _optRead = new()
    {
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
    };
    private readonly JsonSerializerOptions _optWrite = new()
    {
        WriteIndented = true,
    };

    //public T Deserialize<T>(string json) where T : IActivity
    //{
    //}
    //public async Task<T> DeserializeAsync<T>(string json, CancellationToken cancel = default) where T : IActivity
    //{
    //}

    public IActivity Deserialize(string json)
    {
        var data = JsonSerializer.Deserialize<JsonNode>(json, _optRead);
        if (data == null) throw new ArgumentException("Invalid Activity Configuration");
        var name = data["Namespace"]?.GetValue<string>();
        if (string.IsNullOrWhiteSpace(name))throw new ArgumentException("Invalid Activity Configuration - missing name");
        var type = Type.GetType(name);
        if (type == null) throw new ArgumentException($"Invalid Activity Configuration - no type `{name}`");
        if (type.GetInterface(nameof(IActivity)) == null) throw new ArgumentException($"Invalid Activity Configuration - no activity `{name}`");

        var node = data["Instance"];
        var inst = node.Deserialize(type);
        if (inst == null) throw new ArgumentException($"Invalid Activity Configuration - no instance `{name}`");

        return (IActivity)inst;
    }

    private static ActivityTarget<T> Create<T>(T instance) where T : IActivity
    {
        var name = typeof(T).Namespace ?? throw new InvalidDataException("no type specified");

        return new()
        {
            Namespace = name,
            Instance = instance,
        };
    }

    public string Serialize<T>(T activity) where T : IActivity
    {
        var temp = Create(activity);

        return JsonSerializer.Serialize(temp, _optWrite);
    }
    public async Task SerializeAsync<T>(Stream stream, T activity, CancellationToken cancel = default) where T : IActivity
    {
        var temp = Create(activity);

        await JsonSerializer.SerializeAsync(stream, temp, _optWrite);
    }
}
