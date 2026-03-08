using System.Text.Json;
using CoreStack.Abstraction.Serialization;
using Microsoft.Extensions.Options;

namespace CoreStack.Infrastructure.Serialization;

/// <summary>
/// Provides JSON based serialization and deserialization services.
/// </summary>
/// <remarks>
/// Implements conversion of objects and header collections to serialized representations.
/// Uses configured JSON serializer options for consistent processing.
/// Supports deserialization of JSON payloads into strongly typed objects.
/// </remarks>
internal sealed class SerializationService
    : ISerializationService
{
    /// <summary>
    /// Stores JSON serializer configuration used for serialization operations.
    /// </summary>
    private readonly JsonSerializerOptions _serializerOptions;

    /// <summary>
    /// Initializes a new instance with serializer configuration options.
    /// </summary>
    /// <remarks>
    /// Retrieves serializer options from the options provider.
    /// Enables consistent JSON serialization behavior across the application.
    /// </remarks>
    /// <param name="jsonSerializerOptions">The options containing serializer configuration.</param>
    public SerializationService(
        IOptions<JsonSerializerOptions> jsonSerializerOptions)
    {
        _serializerOptions = jsonSerializerOptions.Value;
    }

    /// <summary>
    /// Serializes the provided object into a string representation.
    /// </summary>
    /// <remarks>
    /// Converts the input value into a serialized format.
    /// Returns null when the value cannot be serialized.
    /// </remarks>
    /// <param name="value">The object value to serialize.</param>
    /// <returns>Returns the serialized string representation when available; otherwise, null.</returns>
    public string? SerializeObject(
        object? value)
    {
        if (value is null)
        {
            return null;
        }

        if (value is string payload)
        {
            return payload;
        }

        return JsonSerializer.Serialize(value, _serializerOptions);
    }

    /// <summary>
    /// Serializes the provided header collection into a string representation.
    /// </summary>
    /// <remarks>
    /// Converts the header dictionary into a serialized format.
    /// Returns null when the header collection is not provided.
    /// </remarks>
    /// <param name="headers">The header collection to serialize.</param>
    /// <returns>Returns the serialized header representation when available; otherwise, null.</returns>
    public string? SerializeHeaders(
        IDictionary<string, string>? headers)
    {
        if (headers == null || headers.Count == 0)
        {
            return null;
        }

        var normalizedHeaders = new Dictionary<string, string>(
            headers,
            StringComparer.OrdinalIgnoreCase);

        return JsonSerializer.Serialize(normalizedHeaders, _serializerOptions);
    }

    /// <summary>
    /// Deserializes the provided JSON string into the specified type.
    /// </summary>
    /// <remarks>
    /// Converts the JSON representation into the target type.
    /// Returns null when the input JSON cannot be deserialized.
    /// </remarks>
    /// <typeparam name="T">The target type for deserialization.</typeparam>
    /// <param name="json">The JSON string to deserialize.</param>
    /// <returns>Returns the deserialized object when successful; otherwise, null.</returns>
    public T? Deserialize<T>(
        string? json)
    {
        if (string.IsNullOrEmpty(json))
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(json, _serializerOptions);
    }

    /// <summary>
    /// Deserializes the provided JSON string into the specified runtime type.
    /// </summary>
    /// <remarks>
    /// Converts the JSON representation into the specified type instance.
    /// Returns null when the input JSON cannot be deserialized.
    /// </remarks>
    /// <param name="json">The JSON string to deserialize.</param>
    /// <param name="type">The runtime type used for deserialization.</param>
    /// <returns>Returns the deserialized object when successful; otherwise, null.</returns>
    public object? Deserialize(
        string? json,
        Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        if (string.IsNullOrEmpty(json))
        {
            return null;
        }

        return JsonSerializer.Deserialize(json, type, _serializerOptions);
    }
}
