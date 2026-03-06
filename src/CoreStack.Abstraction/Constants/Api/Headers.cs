namespace CoreStack.Abstraction.Constants.Api;

/// <summary>
/// Defines constant names for HTTP headers used by the application.
/// </summary>
/// <remarks>
/// Provides centralized identifiers for custom HTTP headers.
/// Supports consistent header usage across requests and responses.
/// Enables standardized request correlation and authentication metadata.
/// </remarks>
public static class Headers
{
    /// <summary>
    /// Represents the header containing the correlation identifier.
    /// </summary>
    public const string CorrelationId = "X-Correlation-Id";

    /// <summary>
    /// Represents the header containing the request number.
    /// </summary>
    public const string RequestNumber = "X-Request-Number";

    /// <summary>
    /// Represents the header containing the client identifier.
    /// </summary>
    public const string ClientId = "X-Client-Id";

    /// <summary>
    /// Represents the header containing the API key.
    /// </summary>
    public const string ApiKey = "X-Api-Key";
}
