using CoreStack.Abstraction.Enums.Security;

namespace CoreStack.Abstraction.Sanitization.Catalog;

/// <summary>
/// Defines a catalog of keys that require date of birth masking for sensitive data handling.
/// </summary>
/// <remarks>
/// Provides centralized definitions for identifying date of birth related sensitive keys.
/// Supports consistent masking of personal information across the application.
/// Enhances protection of sensitive demographic data during logging and processing.
/// </remarks>
public static class DateOfBirthMaskCatalog
{
    /// <summary>
    /// Defines keys that require date of birth masking.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, MaskingType> DateOfBirthMask =
        new Dictionary<string, MaskingType>(StringComparer.OrdinalIgnoreCase)
        {
            ["dateofbirth"] = MaskingType.DateOfBirth,
        };
}
