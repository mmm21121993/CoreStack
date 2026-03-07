namespace CoreStack.Abstraction.Enums.Observability;

/// <summary>
/// Defines log severity levels for application logging.
/// </summary>
/// <remarks>
/// Represents ordered log event importance.
/// Used to categorize log entries.
/// Lower values indicate lower severity.
/// Higher values indicate critical failures.
/// Intended for consistent logging semantics.
/// </remarks>
public enum LogEventType
{
    /// <summary>
    /// Represents detailed trace-level logging.
    /// </summary>
    Trace = 0,

    /// <summary>
    /// Represents debug-level diagnostic logging.
    /// </summary>
    Debug = 1,

    /// <summary>
    /// Represents informational logging events.
    /// </summary>
    Information = 2,

    /// <summary>
    /// Represents warning conditions that require attention.
    /// </summary>
    Warning = 3,

    /// <summary>
    /// Represents error conditions that affect processing.
    /// </summary>
    Error = 4,

    /// <summary>
    /// Represents critical failures requiring immediate action.
    /// </summary>
    Critical = 5,
}
