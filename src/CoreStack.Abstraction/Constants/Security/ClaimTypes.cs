namespace CoreStack.Abstraction.Constants.Security;

/// <summary>
/// Defines claim type identifiers used for identity information.
/// </summary>
/// <remarks>
/// Provides centralized claim type definitions.
/// Supports consistent handling of identity claims across authentication flows.
/// Enables standardized access to user identity attributes.
/// </remarks>
public static class ClaimTypes
{
    /// <summary>
    /// Represents the claim type containing the user value.
    /// </summary>
    public const string User = "User";

    /// <summary>
    /// Represents the claim type containing the user identifier.
    /// </summary>
    public const string UserId = "UserId";

    /// <summary>
    /// Represents the claim type containing the client identifier.
    /// </summary>
    public const string ClientId = "ClientId";

    /// <summary>
    /// Represents the claim type containing the role identifier.
    /// </summary>
    public const string RoleId = "RoleId";
}
