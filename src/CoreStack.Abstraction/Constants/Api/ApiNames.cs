namespace CoreStack.Abstraction.Constants.Api;

/// <summary>
/// Defines constant identifiers representing API operation names.
/// </summary>
/// <remarks>
/// Provides centralized names used to identify API operations.
/// Supports consistent referencing of API endpoints across the application.
/// Enables standardized logging and telemetry correlation.
/// </remarks>
public static class ApiNames
{
    /// <summary>
    /// Represents the health probe API operation.
    /// </summary>
    public const string HealthProbe = "HealthProbe";

    /// <summary>
    /// Represents the user registration API operation.
    /// </summary>
    public const string RegisterUser = "RegisterUser";

    /// <summary>
    /// Represents the user login API operation.
    /// </summary>
    public const string LoginUser = "LoginUser";

    /// <summary>
    /// Represents the password reset API operation.
    /// </summary>
    public const string ResetPassword = "ResetPassword";

    /// <summary>
    /// Represents the forgot password API operation.
    /// </summary>
    public const string ForgotPassword = "ForgotPassword";

    /// <summary>
    /// Represents the user logout API operation.
    /// </summary>
    public const string LogoutUser = "LogoutUser";

    /// <summary>
    /// Represents the token refresh API operation.
    /// </summary>
    public const string RefreshToken = "RefreshToken";

    /// <summary>
    /// Represents the user profile retrieval API operation.
    /// </summary>
    public const string GetUserProfile = "GetUserProfile";

    /// <summary>
    /// Represents the country list retrieval API operation.
    /// </summary>
    public const string GetCountries = "GetCountries";
}
