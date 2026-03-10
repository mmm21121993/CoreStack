using CoreStack.Abstraction.Enums.Security;

namespace CoreStack.Abstraction.Sanitization.Catalog;

/// <summary>
/// Defines a catalog of keys that require token specific masking for sensitive data handling.
/// </summary>
/// <remarks>
/// Provides centralized definitions for identifying token related sensitive keys.
/// Supports consistent masking of token values across the application.
/// Enhances protection of security sensitive information during logging and processing.
/// </remarks>
public static class TokenMaskCatalog
{
    /// <summary>
    /// Defines keys that require token masking.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, MaskingType> TokenMask =
        new Dictionary<string, MaskingType>(StringComparer.OrdinalIgnoreCase)
        {
            ["accesstoken"] = MaskingType.Token,
            ["sessiontoken"] = MaskingType.Token,
            ["refreshtoken"] = MaskingType.Token,
            ["authorization"] = MaskingType.Token,
            ["token"] = MaskingType.Token,
        };
}
