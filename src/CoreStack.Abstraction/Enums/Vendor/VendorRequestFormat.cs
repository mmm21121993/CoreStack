namespace CoreStack.Abstraction.Enums.Vendor;

/// <summary>
/// Defines supported formats for sending data in vendor requests.
/// </summary>
public enum VendorRequestFormat
{
    /// <summary>
    /// Represents data sent as query string parameters in the request URL.
    /// </summary>
    QueryString = 1,

    /// <summary>
    /// Represents data sent as path parameters within the request URL.
    /// </summary>
    PathParameter = 2,

    /// <summary>
    /// Represents data sent within the request body.
    /// </summary>
    RequestBody = 3,

    /// <summary>
    /// Represents data sent using form fields.
    /// </summary>
    FormData = 4,

    /// <summary>
    /// Represents data sent using URL encoded form fields.
    /// </summary>
    FormUrlEncoded = 5,

    /// <summary>
    /// Represents data sent using multipart content.
    /// </summary>
    Multipart = 6,

    /// <summary>
    /// Represents data sent as a file upload.
    /// </summary>
    FileUpload = 7,

    /// <summary>
    /// Represents data sent as binary content.
    /// </summary>
    Binary = 8,
}
