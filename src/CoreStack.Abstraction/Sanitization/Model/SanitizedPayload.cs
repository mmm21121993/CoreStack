namespace CoreStack.Abstraction.Sanitization.Model;

/// <summary>
/// Represents a sanitized payload produced after data masking or truncation.
/// </summary>
/// <remarks>
/// Encapsulates sanitized content safe for logging or transport.
/// Indicates whether the value was truncated during sanitization.
/// Supports consistent handling of protected payload data.
/// </remarks>
public sealed class SanitizedPayload
{
    /// <summary>
    /// Gets the sanitized payload value.
    /// </summary>
    required public string Value { get; init; }

    /// <summary>
    /// Gets a value indicating whether the payload value was truncated.
    /// </summary>
    public bool IsTruncated { get; init; }
}
