namespace CoreStack.Abstraction.Enums.Vendor;

/// <summary>
/// Defines supported data sources for resolving vendor information.
/// </summary>
public enum VendorDataSource
{
    /// <summary>
    /// Represents data retrieved from a payload property.
    /// </summary>
    PayloadProperty = 1,

    /// <summary>
    /// Represents data retrieved using a JSON path within the payload.
    /// </summary>
    PayloadJsonPath = 2,

    /// <summary>
    /// Represents data retrieved from a response header.
    /// </summary>
    ResponseHeader = 3,

    /// <summary>
    /// Represents data retrieved from the HTTP status code.
    /// </summary>
    HttpStatusCode = 4,

    /// <summary>
    /// Represents data retrieved using a custom source.
    /// </summary>
    Custom = 5,
}
