namespace CoreStack.Abstraction.Constants.Caching;

/// <summary>
/// Defines cache key identifiers used by the application.
/// </summary>
/// <remarks>
/// Provides centralized cache key definitions.
/// Supports consistent cache access across services.
/// Enables predictable naming of cached entries.
/// </remarks>
public static class CacheKeys
{
    /// <summary>
    /// Represents the cache key for vendor metadata.
    /// </summary>
    public const string VendorMetadata = "vendor-metadata";

    /// <summary>
    /// Represents the cache key for system settings.
    /// </summary>
    public const string SystemSettings = "system-settings";

    /// <summary>
    /// Represents the cache key for the country list.
    /// </summary>
    public const string CountryList = "country-list";
}
