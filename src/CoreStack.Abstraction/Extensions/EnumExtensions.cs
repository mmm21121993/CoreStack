namespace CoreStack.Abstraction.Extensions;

/// <summary>
/// Provides extension methods for working with enumeration types.
/// </summary>
/// <remarks>
/// Defines helper utilities for enumeration value inspection and conversion.
/// Supports enumeration validation, parsing, and metadata retrieval.
/// Enables consistent handling of enumeration values across the application.
/// </remarks>
public static class EnumExtensions
{
    /// <summary>
    /// Returns all values of the specified enumeration type as a list.
    /// </summary>
    /// <remarks>
    /// Retrieves all defined values for the enumeration type.
    /// Returns the values as a read only list.
    /// </remarks>
    /// <typeparam name="T">The enumeration type.</typeparam>
    /// <returns>Returns the list containing all enumeration values.</returns>
    public static IReadOnlyList<T> ToList<T>()
        where T : struct, Enum
    {
        return Enum.GetValues<T>();
    }

    /// <summary>
    /// Determines whether the enumeration value is defined in the type.
    /// </summary>
    /// <remarks>
    /// Evaluates whether the provided value exists in the enumeration.
    /// Returns a value indicating whether the value is defined.
    /// </remarks>
    /// <typeparam name="T">The enumeration type.</typeparam>
    /// <param name="value">The enumeration value to evaluate.</param>
    /// <returns>Returns a value indicating whether the enumeration value is defined.</returns>
    public static bool IsDefined<T>(this T value)
        where T : struct, Enum
    {
        return Enum.IsDefined(value);
    }

    /// <summary>
    /// Retrieves the name associated with the enumeration value.
    /// </summary>
    /// <remarks>
    /// Returns the string representation of the enumeration value name.
    /// Provides access to the defined identifier of the enumeration member.
    /// </remarks>
    /// <typeparam name="T">The enumeration type.</typeparam>
    /// <param name="value">The enumeration value.</param>
    /// <returns>Returns the name associated with the enumeration value.</returns>
    public static string GetName<T>(this T value)
        where T : struct, Enum
    {
        return Enum.GetName(value) ?? value.ToString();
    }

    /// <summary>
    /// Attempts to parse the provided string into the enumeration value.
    /// </summary>
    /// <remarks>
    /// Evaluates the string against defined enumeration member names.
    /// Returns a value indicating whether parsing succeeded.
    /// </remarks>
    /// <typeparam name="T">The enumeration type.</typeparam>
    /// <param name="value">The string representation of the enumeration value.</param>
    /// <param name="result">The parsed enumeration value when parsing succeeds.</param>
    /// <returns>Returns a value indicating whether parsing succeeded.</returns>
    public static bool TryParse<T>(string value, out T result)
        where T : struct, Enum
    {
        return Enum.TryParse(value, true, out result);
    }
}
