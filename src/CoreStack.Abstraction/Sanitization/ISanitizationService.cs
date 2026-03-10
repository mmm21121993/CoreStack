using CoreStack.Abstraction.Sanitization.Model;

namespace CoreStack.Abstraction.Sanitization;

/// <summary>
/// Defines a contract for sanitizing sensitive data within payloads and key value collections.
/// </summary>
/// <remarks>
/// Provides abstraction for masking sensitive values in structured data.
/// Supports sanitization of JSON payloads and key value collections.
/// Enables consistent protection of confidential information during processing.
/// </remarks>
public interface ISanitizationService
{
    /// <summary>
    /// Masks sensitive values within the provided JSON payload.
    /// </summary>
    /// <remarks>
    /// Applies masking rules to protect sensitive fields.
    /// Returns a sanitized payload representation safe for logging.
    /// </remarks>
    /// <param name="jsonPayload">The JSON payload containing data to sanitize.</param>
    /// <param name="isMaskingAllowed">Indicates whether masking rules should be applied.</param>
    /// <returns>Returns the sanitized payload result.</returns>
    public SanitizedPayload MaskJsonPayload(
        string jsonPayload,
        bool isMaskingAllowed);

    /// <summary>
    /// Masks sensitive values within the provided key value collection.
    /// </summary>
    /// <remarks>
    /// Applies masking rules to protect sensitive entries.
    /// Returns a collection containing sanitized values.
    /// </remarks>
    /// <param name="keyValuePairs">The key value pairs containing data to sanitize.</param>
    /// <returns>Returns the collection containing sanitized key value pairs.</returns>
    public IDictionary<string, string> MaskKeyValuePairs(
        IDictionary<string, string> keyValuePairs);
}
