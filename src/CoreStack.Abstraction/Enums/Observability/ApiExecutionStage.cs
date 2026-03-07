namespace CoreStack.Abstraction.Enums.Observability;

/// <summary>
/// Defines execution stages for API processing lifecycle.
/// </summary>
public enum ApiExecutionStage
{
    /// <summary>
    /// Represents the stage when execution has been initiated.
    /// </summary>
    Initiated = 1,

    /// <summary>
    /// Represents the stage when the request has been validated.
    /// </summary>
    Validated = 2,

    /// <summary>
    /// Represents the stage when processing is in progress.
    /// </summary>
    Processing = 3,

    /// <summary>
    /// Represents the stage when execution has completed successfully.
    /// </summary>
    Completed = 4,

    /// <summary>
    /// Represents the stage when execution has failed.
    /// </summary>
    Failed = 5,
}
