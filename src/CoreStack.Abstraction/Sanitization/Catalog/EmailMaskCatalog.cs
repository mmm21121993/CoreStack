using CoreStack.Abstraction.Enums.Security;

namespace CoreStack.Abstraction.Sanitization.Catalog;

/// <summary>
/// Defines a catalog of keys that require email specific masking for sensitive data handling.
/// </summary>
/// <remarks>
/// Provides centralized definitions for identifying email related sensitive keys.
/// Supports consistent masking of email values across the application.
/// Enhances protection of personal information during logging and processing.
/// </remarks>
public static class EmailMaskCatalog
{
    /// <summary>
    /// Defines keys that require email masking.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, MaskingType> EmailMask =
        new Dictionary<string, MaskingType>(StringComparer.OrdinalIgnoreCase)
        {
            ["email"] = MaskingType.Email,
            ["emailaddress"] = MaskingType.Email,
        };
}
