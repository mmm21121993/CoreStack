namespace CoreStack.Abstraction.Constants.Environment;

/// <summary>
/// Defines environment name identifiers used by the application.
/// </summary>
/// <remarks>
/// Provides centralized environment name definitions.
/// Supports environment specific configuration and behavior.
/// Enables consistent environment detection across the application.
/// </remarks>
public static class EnvironmentNames
{
    /// <summary>
    /// Represents the development environment.
    /// </summary>
    public const string Development = "Development";

    /// <summary>
    /// Represents the staging environment.
    /// </summary>
    public const string Staging = "Staging";

    /// <summary>
    /// Represents the production environment.
    /// </summary>
    public const string Production = "Production";
}
