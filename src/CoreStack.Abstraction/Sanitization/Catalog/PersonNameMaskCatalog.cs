using CoreStack.Abstraction.Enums.Security;

namespace CoreStack.Abstraction.Sanitization.Catalog;

/// <summary>
/// Defines a catalog of keys that require person name masking for sensitive data handling.
/// </summary>
/// <remarks>
/// Provides centralized definitions for identifying person name related sensitive keys.
/// Supports consistent masking of personal identity information across the application.
/// Enhances protection of personal name data during logging and processing.
/// </remarks>
public static class PersonNameMaskCatalog
{
    /// <summary>
    /// Defines keys that require personal name masking.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, MaskingType> PersonNameMask =
        new Dictionary<string, MaskingType>(StringComparer.OrdinalIgnoreCase)
        {
            ["displayname"] = MaskingType.PersonName,
        };
}
