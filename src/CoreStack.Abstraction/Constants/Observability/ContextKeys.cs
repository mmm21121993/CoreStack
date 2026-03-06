namespace CoreStack.Abstraction.Constants.Observability;

/// <summary>
/// Defines keys used within request context storage.
/// </summary>
/// <remarks>
/// Provides centralized identifiers for contextual request data.
/// Supports consistent storage and retrieval of request metadata.
/// Enables propagation of contextual information across layers.
/// </remarks>
public static class ContextKeys
{
    /// <summary>
    /// Represents the context key for correlation identifier.
    /// </summary>
    public const string CorrelationId = "CorrelationId";

    /// <summary>
    /// Represents the context key for request number.
    /// </summary>
    public const string RequestNumber = "RequestNumber";

    /// <summary>
    /// Represents the context key for user information.
    /// </summary>
    public const string User = "User";

    /// <summary>
    /// Represents the context key for user identifier.
    /// </summary>
    public const string UserId = "UserId";
}
