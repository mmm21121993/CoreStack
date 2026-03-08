using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CoreStack.Infrastructure.Serialization;

/// <summary>
/// Provides default configuration behavior for JSON serializer options.
/// </summary>
/// <remarks>
/// This type centralizes JSON serialization defaults used across the application.
/// It ensures consistent serialization behavior for payload processing.
/// It is intended to be applied during service or serializer configuration.
/// </remarks>
public static class JsonSerializerDefaults
{
    /// <summary>
    /// Defines an action used to configure JSON serializer options.
    /// </summary>
    public static readonly Action<JsonSerializerOptions> Configure =
        (options) =>
        {
            options.WriteIndented = false;
            options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;

            options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            options.PropertyNameCaseInsensitive = true;

            options.MaxDepth = 32;

            options.NumberHandling = JsonNumberHandling.AllowReadingFromString;

            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        };
}
