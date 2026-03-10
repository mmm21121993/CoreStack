using CoreStack.Abstraction.Enums.Security;

namespace CoreStack.Abstraction.Sanitization.Catalog;

/// <summary>
/// Defines a catalog of keys that require bank account number masking for sensitive data handling.
/// </summary>
/// <remarks>
/// Provides centralized definitions for identifying bank account related sensitive keys.
/// Supports consistent masking of financial information across the application.
/// Enhances protection of banking data during logging and processing.
/// </remarks>
public static class BankAccountNumberMaskCatalog
{
    /// <summary>
    /// Defines keys that require bank account number masking.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, MaskingType> BankAccountNumberMask =
        new Dictionary<string, MaskingType>(StringComparer.OrdinalIgnoreCase)
        {
            ["accountnumber"] = MaskingType.BankAccountNumber,
            ["bankaccount"] = MaskingType.BankAccountNumber,
            ["iban"] = MaskingType.BankAccountNumber,
        };
}
