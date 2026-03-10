using CoreStack.Abstraction.Enums.Security;
using CoreStack.Abstraction.Sanitization.Catalog;

namespace CoreStack.Infrastructure.Sanitization;

/// <summary>
/// Provides a registry containing the combined mask catalog used for sensitive data handling.
/// </summary>
/// <remarks>
/// Aggregates masking definitions from multiple catalog sources.
/// Builds a unified lookup used during data sanitization.
/// Ensures consistent masking behavior across the application.
/// </remarks>
internal static class MaskCatalogRegistry
{
    /// <summary>
    /// Gets the lookup containing masking rules for sensitive keys.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, MaskingType> MaskCatalog;

    /// <summary>
    /// Initializes the mask catalog registry.
    /// </summary>
    /// <remarks>
    /// Builds the masking catalog during type initialization.
    /// Ensures masking rules are available before usage.
    /// </remarks>
    static MaskCatalogRegistry()
    {
        MaskCatalog = BuildCatalog();
    }

    /// <summary>
    /// Builds the combined masking catalog from available sources.
    /// </summary>
    /// <remarks>
    /// Aggregates mask catalogs into a unified dictionary.
    /// Returns a lookup used for resolving masking behavior.
    /// </remarks>
    /// <returns>Returns the constructed masking catalog.</returns>
    private static IReadOnlyDictionary<string, MaskingType> BuildCatalog()
    {
        return
            FullMaskCatalog.FullMask
            .Concat(EmailMaskCatalog.EmailMask)
            .Concat(PhoneMaskCatalog.PhoneMask)
            .Concat(TokenMaskCatalog.TokenMask)
            .Concat(BankAccountNumberMaskCatalog.BankAccountNumberMask)
            .Concat(CardNumberMaskCatalog.CardNumberMask)
            .Concat(NationalIdMaskCatalog.NationalIdMask)
            .Concat(DateOfBirthMaskCatalog.DateOfBirthMask)
            .Concat(AddressMaskCatalog.AddressMask)
            .Concat(PersonNameMaskCatalog.PersonNameMask)
            .GroupBy(x => x.Key, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(
                k => k.Key,
                k => k.Count() > 1
                    ? throw new InvalidOperationException($"Duplicate key found in sensitive catalogs: {k.Key}")
                    : k.First().Value,
                StringComparer.OrdinalIgnoreCase);
    }
}
