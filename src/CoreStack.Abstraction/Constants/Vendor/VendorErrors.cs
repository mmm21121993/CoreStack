namespace CoreStack.Abstraction.Constants.Vendor;

/// <summary>
/// Defines constant identifiers representing vendor error codes.
/// </summary>
/// <remarks>
/// Provides centralized vendor error code definitions.
/// Supports consistent handling of vendor failure scenarios.
/// Enables standardized reporting of vendor integration errors.
/// </remarks>
public static class VendorErrors
{
    /// <summary>
    /// Represents a generic vendor operation failure.
    /// </summary>
    public const string VendorFailure = "VENDOR_FAILURE";

    /// <summary>
    /// Represents a transport level failure during vendor communication.
    /// </summary>
    public const string TransportFailure = "TRANSPORT_FAILURE";

    /// <summary>
    /// Represents an invalid vendor response scenario.
    /// </summary>
    public const string InvalidVendorResponse = "INVALID_VENDOR_RESPONSE";

    /// <summary>
    /// Represents a vendor operation failure condition.
    /// </summary>
    public const string OperationFailed = "OPERATION_FAILED";

    /// <summary>
    /// Represents an incomplete vendor operation condition.
    /// </summary>
    public const string OperationIncomplete = "OPERATION_INCOMPLETE";

    /// <summary>
    /// Represents an unknown vendor failure condition.
    /// </summary>
    public const string UnknownVendorFailure = "UNKNOWN_VENDOR_FAILURE";
}
