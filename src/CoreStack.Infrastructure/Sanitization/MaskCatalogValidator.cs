using CoreStack.Abstraction.Enums.Security;

namespace CoreStack.Infrastructure.Sanitization;

internal static class MaskCatalogValidator
{
    /// <summary>
    /// Validates the provided sensitive keys catalog.
    /// </summary>
    /// <remarks>
    /// This operation verifies that catalog entries meet expected constraints.
    /// </remarks>
    /// <param name="catalog">The catalog containing sensitive field masking definitions.</param>
    public static void ValidateSensitiveKeyCatalog(
        IReadOnlyDictionary<string, MaskingType> catalog)
    {
        // Validate for empty sensitive key catalog
        if (catalog is null || catalog.Count == 0)
        {
            throw new InvalidOperationException("Sensitive keys catalog is empty or not initialized.");
        }

        // Initialize a list to collect error messages
        var errors = new List<string>();

        // Check for keys with whitespace or key are invalid
        var invalidKeys = catalog
            .Where(x => string.IsNullOrWhiteSpace(x.Key))
            .Select(x => $"'{x.Key}'")
            .ToList();

        if (invalidKeys.Count > 0)
        {
            errors.Add($"Invalid (empty/whitespace) sensitive keys detected: {string.Join(", ", invalidKeys)}");
        }

        // Check for the duplicate key assignment
        var duplicateKeys = catalog.Keys
            .GroupBy(x => x, StringComparer.OrdinalIgnoreCase)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

        if (duplicateKeys.Count > 0)
        {
            errors.Add($"Duplicate sensitive keys detected: {string.Join(", ", duplicateKeys)}");
        }

        // Validate the mask typings for all key-value resources
        var invalidMaskTypes = catalog
            .Where(static x => !(Enum.IsDefined<MaskingType>(x.Value)
                        && x.Value != MaskingType.None))
            .Select(x => $"{x.Key}:{x.Value}")
            .ToList();

        if (invalidMaskTypes.Count > 0)
        {
            errors.Add($"Invalid MaskingType detected: {string.Join(", ", invalidMaskTypes)}");
        }

        if (errors.Count > 0)
        {
            throw new InvalidOperationException(
                "Sensitive Keys Catalog validation failed:\n" +
                string.Join(Environment.NewLine, errors));
        }
    }
}
