namespace CoreStack.Infrastructure.Sanitization;

/// <summary>
/// Defines default configuration values used for sanitization behavior.
/// </summary>
/// <remarks>
/// Provides centralized baseline settings for masking and truncation operations.
/// Ensures consistent sanitization rules across application components.
/// Supports reuse of sanitization invariants within infrastructure services.
/// </remarks>
internal static class SanitizationDefaults
{
    /// <summary>
    /// Represents the character used when masking sensitive values.
    /// </summary>
    public const char MaskCharacter = '*';

    /// <summary>
    /// Represents the default maximum length allowed for payload values.
    /// </summary>
    public const int DefaultMaxPayloadLength = 4096;

    /// <summary>
    /// Represents the minimum length required before full masking is applied.
    /// </summary>
    public const int MinimumVisibleCharacterLengthForFullMask = 16;

    /// <summary>
    /// Represents the number of visible characters retained for phone values.
    /// </summary>
    public const int VisibleCharacterLengthForPhone = 4;

    /// <summary>
    /// Represents the number of visible characters retained for bank account values.
    /// </summary>
    public const int VisibleCharacterLengthForBankAccount = 4;

    /// <summary>
    /// Represents the number of visible characters retained for card number values.
    /// </summary>
    public const int VisibleCharacterLengthForCardNumber = 4;

    /// <summary>
    /// Represents the number of visible characters retained for national identifier values.
    /// </summary>
    public const int VisibleCharacterLengthForNationId = 2;

    /// <summary>
    /// Represents the minimum character length required for token masking.
    /// </summary>
    public const int MinimumCharacterLengthForToken = 6;
}
