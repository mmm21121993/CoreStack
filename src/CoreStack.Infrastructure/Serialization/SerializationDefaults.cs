namespace CoreStack.Infrastructure.Serialization;

/// <summary>
/// Defines default configuration values used for serialization behavior.
/// </summary>
/// <remarks>
/// Provides centralized baseline settings for JSON serialization operations.
/// Ensures consistent serializer configuration across application components.
/// Supports reuse of serialization invariants within infrastructure services.
/// </remarks>
internal static class SerializationDefaults
{
    /// <summary>
    /// Represents the maximum depth allowed during serialization operations.
    /// </summary>
    public const int MaxDepth = 32;

    /// <summary>
    /// Represents whether property name comparison is case insensitive.
    /// </summary>
    public const bool IsCaseInsensitive = false;

    /// <summary>
    /// Represents whether null values should be ignored during serialization.
    /// </summary>
    public const bool IgnoreNullValues = false;
}
