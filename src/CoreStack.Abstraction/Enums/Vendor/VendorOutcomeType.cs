namespace CoreStack.Abstraction.Enums.Vendor;

/// <summary>
/// Defines possible outcome types for vendor operations.
/// </summary>
public enum VendorOutcomeType
{
    /// <summary>
    /// Represents a successful vendor operation.
    /// </summary>
    Success = 0,

    /// <summary>
    /// Represents a failed vendor operation.
    /// </summary>
    Failure = 1,

    /// <summary>
    /// Represents an unknown vendor operation outcome.
    /// </summary>
    Unknown = 2,
}
