namespace CoreStack.Abstraction.Enums.Security;

/// <summary>
/// Defines supported token types used by the authentication system.
/// </summary>
public enum TokenType
{
    /// <summary>
    /// Represents a token used to authorize API access.
    /// </summary>
    AccessToken = 1,

    /// <summary>
    /// Represents a token used to obtain a new access token.
    /// </summary>
    RefreshToken = 2,

    /// <summary>
    /// Represents a token used for password reset operations.
    /// </summary>
    PasswordResetToken = 3,
}
