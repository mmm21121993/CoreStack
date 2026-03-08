using System.Text;
using CoreStack.Abstraction.Constants.Api;

namespace CoreStack.Abstraction.Extensions;

/// <summary>
/// Provides extension methods for working with API name identifiers.
/// </summary>
/// <remarks>
/// Defines helper utilities for evaluating and transforming API name values.
/// Supports common operations used across API execution and logging workflows.
/// Enables consistent representation of API identifiers.
/// </remarks>
public static class ApiNameExtensions
{
    /// <summary>
    /// Determines whether the API name represents a health probe operation.
    /// </summary>
    /// <remarks>
    /// Compares the provided API name with the health probe identifier.
    /// Returns a value indicating whether the API corresponds to the health probe.
    /// </remarks>
    /// <param name="apiName">The API name to evaluate.</param>
    /// <returns>Returns a value indicating whether the API name represents the health probe.</returns>
    public static bool IsHealthProbe(
        this string apiName)
    {
        return string.Equals(apiName, ApiNames.HealthProbe, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Converts the API name into a human readable display name.
    /// </summary>
    /// <remarks>
    /// Transforms the identifier into a formatted display value.
    /// Returns the formatted representation suitable for presentation.
    /// </remarks>
    /// <param name="apiName">The API name to convert.</param>
    /// <returns>Returns the display name representation of the API identifier.</returns>
    public static string ToDisplayName(
        this string apiName)
    {
        if (string.IsNullOrWhiteSpace(apiName))
        {
            return ApiNames.Unknown;
        }

        return ConvertToDisplayName(apiName);
    }

    /// <summary>
    /// Converts an API identifier into a display friendly format.
    /// </summary>
    /// <remarks>
    /// Applies formatting rules to produce a readable representation.
    /// Used internally to generate display names for API identifiers.
    /// </remarks>
    /// <param name="apiName">The API name to convert.</param>
    /// <returns>Returns the display friendly representation of the API name.</returns>
    private static string ConvertToDisplayName(
        string apiName)
    {
        var builder = new StringBuilder(apiName.Length);

        for (var i = 0; i < apiName.Length; i++)
        {
            var c = apiName[i];

            if (i > 0 && char.IsUpper(c))
            {
                builder.Append(' ');
            }

            builder.Append(c);
        }

        return builder.ToString();
    }
}
