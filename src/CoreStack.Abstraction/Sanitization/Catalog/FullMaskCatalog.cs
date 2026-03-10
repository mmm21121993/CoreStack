using CoreStack.Abstraction.Enums.Security;

namespace CoreStack.Abstraction.Sanitization.Catalog;

/// <summary>
/// Defines a catalog of keys that require full masking for sensitive data handling.
/// </summary>
/// <remarks>
/// Provides centralized definitions for identifying sensitive keys.
/// Supports consistent masking of confidential values across the application.
/// Enhances protection of sensitive information during logging and processing.
/// </remarks>
public static class FullMaskCatalog
{
    /// <summary>
    /// Defines keys that require full value masking.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, MaskingType> FullMask =
        new Dictionary<string, MaskingType>(StringComparer.OrdinalIgnoreCase)
        {
            ["password"] = MaskingType.Full,
            ["pwd"] = MaskingType.Full,
            ["otp"] = MaskingType.Full,
            ["pin"] = MaskingType.Full,
            ["otpcode"] = MaskingType.Full,
            ["validationreferenceid"] = MaskingType.Full,
            ["apikey"] = MaskingType.Full,
            ["secret"] = MaskingType.Full,
            ["mfacode"] = MaskingType.Full,
            ["mfaId"] = MaskingType.Full,
            ["validationCode"] = MaskingType.Full,
            ["validateEmailId"] = MaskingType.Full,
        };
}
