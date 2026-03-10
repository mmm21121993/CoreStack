using CoreStack.Abstraction.Enums.Security;

namespace CoreStack.Abstraction.Sanitization.Catalog;

/// <summary>
/// Defines a catalog of keys that require card number masking for sensitive data handling.
/// </summary>
/// <remarks>
/// Provides centralized definitions for identifying card number related sensitive keys.
/// Supports consistent masking of payment information across the application.
/// Enhances protection of financial data during logging and processing.
/// </remarks>
public static class CardNumberMaskCatalog
{
    /// <summary>
    /// Defines keys that require card number masking.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, MaskingType> CardNumberMask =
        new Dictionary<string, MaskingType>(StringComparer.OrdinalIgnoreCase)
        {
            ["cardnumber"] = MaskingType.CardNumber,
            ["creditcard"] = MaskingType.CardNumber,
            ["debitcard"] = MaskingType.CardNumber,
        };
}
