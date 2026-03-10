using CoreStack.Abstraction.Enums.Security;

namespace CoreStack.Abstraction.Sanitization.Catalog;

/// <summary>
/// Defines a catalog of keys that require national identification masking for sensitive data handling.
/// </summary>
/// <remarks>
/// Provides centralized definitions for identifying national identification related sensitive keys.
/// Supports consistent masking of identity information across the application.
/// Enhances protection of personal identification data during logging and processing.
/// </remarks>
public static class NationalIdMaskCatalog
{
    /// <summary>
    /// Defines keys that require national identifier masking.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, MaskingType> NationalIdMask =
        new Dictionary<string, MaskingType>(StringComparer.OrdinalIgnoreCase)
        {
            ["ssn"] = MaskingType.NationalId,
        };
}
