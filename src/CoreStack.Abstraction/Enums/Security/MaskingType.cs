namespace CoreStack.Abstraction.Enums.Security;

/// <summary>
/// Defines the available masking strategies for sensitive data.
/// </summary>
public enum MaskingType
{
    /// <summary>
    /// Indicates that no masking is applied.
    /// </summary>
    None = 0,

    /// <summary>
    /// Indicates that the entire value is fully masked.
    /// </summary>
    Full = 1,

    /// <summary>
    /// Indicates that an email address masking strategy is applied.
    /// </summary>
    Email = 2,

    /// <summary>
    /// Indicates that a phone number masking strategy is applied.
    /// </summary>
    Phone = 3,

    /// <summary>
    /// Indicates that a token masking strategy is applied.
    /// </summary>
    Token = 4,

    /// <summary>
    /// Indicates that a bank account number masking strategy is applied.
    /// </summary>
    BankAccountNumber = 5,

    /// <summary>
    /// Indicates that a card number masking strategy is applied.
    /// </summary>
    CardNumber = 6,

    /// <summary>
    /// Indicates that a national identifier masking strategy is applied.
    /// </summary>
    NationalId = 7,

    /// <summary>
    /// Indicates that a date of birth masking strategy is applied.
    /// </summary>
    DateOfBirth = 8,

    /// <summary>
    /// Indicates that an address masking strategy is applied.
    /// </summary>
    Address = 9,

    /// <summary>
    /// Indicates that a personal name masking strategy is applied.
    /// </summary>
    PersonName = 10,
}
