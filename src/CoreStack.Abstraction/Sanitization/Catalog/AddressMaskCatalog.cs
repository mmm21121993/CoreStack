using CoreStack.Abstraction.Enums.Security;

namespace CoreStack.Abstraction.Sanitization.Catalog;

/// <summary>
/// Defines a catalog of keys that require address masking for sensitive data handling.
/// </summary>
/// <remarks>
/// Provides centralized definitions for identifying address related sensitive keys.
/// Supports consistent masking of location information across the application.
/// Enhances protection of personal address data during logging and processing.
/// </remarks>
public static class AddressMaskCatalog
{
    /// <summary>
    /// Defines keys that require address masking.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, MaskingType> AddressMask =
        new Dictionary<string, MaskingType>(StringComparer.OrdinalIgnoreCase)
        {
            ["address"] = MaskingType.Address,
            ["addressline1"] = MaskingType.Address,
            ["addressline2"] = MaskingType.Address,
        };
}
