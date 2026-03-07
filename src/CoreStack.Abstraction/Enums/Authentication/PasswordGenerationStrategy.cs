namespace CoreStack.Abstraction.Enums.Authentication;

/// <summary>
/// Defines the available strategies for generating passwords.
/// </summary>
public enum PasswordGenerationStrategy
{
    /// <summary>
    /// Uses the default password generation behavior.
    /// </summary>
    Default = 1,

    /// <summary>
    /// Uses a system-generated password strategy.
    /// </summary>
    SystemGenerated = 2,
}
