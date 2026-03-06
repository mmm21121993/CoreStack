namespace CoreStack.Abstraction.Constants.Configurations;

/// <summary>
/// Defines configuration section names used by the application.
/// </summary>
/// <remarks>
/// Provides centralized configuration section identifiers.
/// Supports consistent configuration binding across services.
/// Enables standardized access to configuration settings.
/// </remarks>
public static class ConfigurationSections
{
    /// <summary>
    /// Represents the configuration section for database settings.
    /// </summary>
    public const string Database = "Database";

    /// <summary>
    /// Represents the configuration section for request and response logging settings.
    /// </summary>
    public const string RequestResponseLogging = "RequestResponseLogging";

    /// <summary>
    /// Represents the configuration section for password policy settings.
    /// </summary>
    public const string PasswordPolicy = "PasswordPolicy";

    /// <summary>
    /// Represents the configuration section for OTP retry policy settings.
    /// </summary>
    public const string OtpRetryPolicy = "OtpRetryPolicy";
}
