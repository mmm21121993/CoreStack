using CoreStack.Abstraction.Enums.Security;

namespace CoreStack.Abstraction.Sanitization.Catalog;

/// <summary>
/// Defines a catalog of keys that require phone specific masking for sensitive data handling.
/// </summary>
/// <remarks>
/// Provides centralized definitions for identifying phone related sensitive keys.
/// Supports consistent masking of phone values across the application.
/// Enhances protection of personal information during logging and processing.
/// </remarks>
public static class PhoneMaskCatalog
{
    /// <summary>
    /// Defines keys that require phone number masking.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, MaskingType> PhoneMask =
        new Dictionary<string, MaskingType>(StringComparer.OrdinalIgnoreCase)
        {
            ["phone"] = MaskingType.Phone,
            ["phonenumber"] = MaskingType.Phone,
            ["mobile"] = MaskingType.Phone,
            ["mobilenumber"] = MaskingType.Phone,
        };
}
