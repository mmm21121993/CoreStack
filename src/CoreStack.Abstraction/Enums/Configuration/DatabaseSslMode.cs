namespace CoreStack.Abstraction.Enums.Configuration;

/// <summary>
/// Defines the available ssl modes for the database connectivity.
/// </summary>
public enum DatabaseSslMode
{
    /// <summary>
    /// Disables SSL for the database connection.
    /// </summary>
    Disable = 1,

    /// <summary>
    /// Requires SSL for the database connection without full verification.
    /// </summary>
    Require = 2,

    /// <summary>
    /// Requires SSL with full certificate verification.
    /// </summary>
    VerifyFull = 3,
}
