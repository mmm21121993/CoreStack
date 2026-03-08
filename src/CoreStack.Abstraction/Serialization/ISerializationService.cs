namespace CoreStack.Abstraction.Serialization;

/// <summary>
/// Defines a contract for serialization and deserialization operations.
/// </summary>
/// <remarks>
/// Provides abstraction for converting objects to and from serialized representations.
/// Supports handling of general objects and header collections.
/// Enables consistent data serialization across application components.
/// </remarks>
public interface ISerializationService
{
    /// <summary>
    /// Serializes the provided object into a string representation.
    /// </summary>
    /// <remarks>
    /// Converts the input value into a serialized format.
    /// Returns null when the value cannot be serialized.
    /// </remarks>
    /// <param name="value">The object value to serialize.</param>
    /// <returns>Returns the serialized string representation when available; otherwise, null.</returns>
    public string? SerializeObject(object? value);

    /// <summary>
    /// Serializes the provided header collection into a string representation.
    /// </summary>
    /// <remarks>
    /// Converts the header dictionary into a serialized format.
    /// Returns null when the header collection is not provided.
    /// </remarks>
    /// <param name="headers">The header collection to serialize.</param>
    /// <returns>Returns the serialized header representation when available; otherwise, null.</returns>
    public string? SerializeHeaders(IDictionary<string, string>? headers);

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
    public T? Deserialize<T>(string? json);

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
    public object? Deserialize(string? json, Type type);
}
