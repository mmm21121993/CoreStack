using System.Text.Json;
using System.Text.Json.Nodes;
using CoreStack.Abstraction.Enums.Security;
using CoreStack.Abstraction.Sanitization;
using CoreStack.Abstraction.Sanitization.Model;
using Microsoft.Extensions.Options;

namespace CoreStack.Infrastructure.Sanitization;

/// <summary>
/// Defines a contract for sanitizing sensitive data within payloads and key value collections.
/// </summary>
/// <remarks>
/// Provides abstraction for masking sensitive values in structured data.
/// Supports sanitization of JSON payloads and key value collections.
/// Enables consistent protection of confidential information during processing.
/// </remarks>
internal sealed class SanitizationService
    : ISanitizationService
{
    /// <summary>
    /// Stores JSON serializer configuration used during sanitization operations.
    /// </summary>
    private readonly JsonSerializerOptions _serializerOptions;

    /// <summary>
    /// Initializes a new instance with serializer configuration options.
    /// </summary>
    /// <remarks>
    /// Retrieves serializer options from the options provider.
    /// Enables consistent JSON processing during sanitization.
    /// </remarks>
    /// <param name="jsonSerializerOptions">The options containing serializer configuration.</param>
    public SanitizationService(
        IOptions<JsonSerializerOptions> jsonSerializerOptions)
    {
        ArgumentNullException.ThrowIfNull(jsonSerializerOptions);

        _serializerOptions = jsonSerializerOptions.Value;
    }

    /// <summary>
    /// Masks sensitive values within the provided JSON payload.
    /// </summary>
    /// <remarks>
    /// Applies masking rules to protect sensitive fields.
    /// Returns a sanitized payload representation safe for logging.
    /// </remarks>
    /// <param name="jsonPayload">The JSON payload containing data to sanitize.</param>
    /// <param name="isMaskingAllowed">Indicates whether masking rules should be applied.</param>
    /// <returns>Returns the sanitized payload result.</returns>
    public SanitizedPayload MaskJsonPayload(
        string jsonPayload,
        bool isMaskingAllowed)
    {
        if (string.IsNullOrWhiteSpace(jsonPayload))
        {
            return new SanitizedPayload
            {
                Value = string.Empty,
                IsTruncated = false,
            };
        }

        var maskedPayload = isMaskingAllowed ? MaskPayload(jsonPayload) : jsonPayload;
        if (maskedPayload.Length > SanitizationDefaults.DefaultMaxPayloadLength)
        {
            return new SanitizedPayload
            {
                Value = maskedPayload[..SanitizationDefaults.DefaultMaxPayloadLength] +
                    $" ...(truncated at {SanitizationDefaults.DefaultMaxPayloadLength} chars)",
                IsTruncated = true,
            };
        }

        return new SanitizedPayload
        {
            Value = maskedPayload,
            IsTruncated = false,
        };
    }

    /// <summary>
    /// Masks sensitive values within the provided key value collection.
    /// </summary>
    /// <remarks>
    /// Applies masking rules to protect sensitive entries.
    /// Returns a collection containing sanitized values.
    /// </remarks>
    /// <param name="keyValuePairs">The key value pairs containing data to sanitize.</param>
    /// <returns>Returns the collection containing sanitized key value pairs.</returns>
    public IDictionary<string, string> MaskKeyValuePairs(
        IDictionary<string, string> keyValuePairs)
    {
        if (keyValuePairs is null || keyValuePairs.Count == 0)
        {
            return new Dictionary<string, string>(0);
        }

        return MaskDictionary(keyValuePairs);
    }

    /// <summary>
    /// Masks a JSON value based on the specified masking type.
    /// </summary>
    /// <remarks>
    /// This method applies type-specific masking logic to JSON values.
    /// </remarks>
    /// <param name="type">The masking strategy to apply.</param>
    /// <param name="value">The JSON value to be masked.</param>
    /// <returns>Returns the masked JSON value.</returns>
    private static JsonValue MaskJsonValue(
        MaskingType type,
        JsonValue value)
    {
        var rawValue = value.ToString();
        var maskedValue = MaskByType(type, rawValue);
        return JsonValue.Create(maskedValue);
    }

    /// <summary>
    /// Applies masking rules to all values in the provided dictionary.
    /// </summary>
    /// <remarks>
    /// This method creates a new dictionary containing masked values.
    /// </remarks>
    /// <param name="source">The source dictionary containing raw values.</param>
    /// <returns>Returns a dictionary with masked values applied.</returns>
    private static Dictionary<string, string> MaskDictionary(
        IDictionary<string, string> source)
    {
        var result = new Dictionary<string, string>(
            source.Count,
            StringComparer.OrdinalIgnoreCase);

        foreach (var (key, value) in source)
        {
            result[key] = MaskSensitiveValue(key, value);
        }

        return result;
    }

    /// <summary>
    /// Masks a sensitive value based on the provided key.
    /// </summary>
    /// <remarks>
    /// This method determines the masking strategy using the field key.
    /// </remarks>
    /// <param name="key">The key associated with the sensitive value.</param>
    /// <param name="value">The raw value to be masked.</param>
    /// <returns>Returns the masked value.</returns>
    private static string MaskSensitiveValue(
        string key,
        string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        if (!MaskCatalogRegistry.MaskCatalog.TryGetValue(key, out var maskType))
        {
            return value;
        }

        return MaskByType(maskType, value);
    }

    /// <summary>
    /// Masks a value using the specified masking strategy.
    /// </summary>
    /// <remarks>
    /// This method applies strategy-specific masking rules.
    /// </remarks>
    /// <param name="maskType">The masking strategy to apply.</param>
    /// <param name="value">The raw value to be masked.</param>
    /// <returns>Returns the masked value.</returns>
    private static string MaskByType(
        MaskingType maskType,
        string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        return maskType switch {
            MaskingType.Full => MaskFull(value.Length),
            MaskingType.Email => MaskEmail(value),
            MaskingType.Phone => MaskLastN(value, SanitizationDefaults.VisibleCharacterLengthForPhone),
            MaskingType.Token => MaskToken(value),
            MaskingType.BankAccountNumber => MaskLastN(value, SanitizationDefaults.VisibleCharacterLengthForBankAccount),
            MaskingType.CardNumber => MaskLastN(value, SanitizationDefaults.VisibleCharacterLengthForCardNumber),
            MaskingType.NationalId => MaskLastN(value, SanitizationDefaults.VisibleCharacterLengthForNationId),
            MaskingType.DateOfBirth => MaskDateOfBirth(value),
            MaskingType.Address => MaskAddress(value),
            MaskingType.PersonName => MaskPersonName(value),
            _ => value
        };
    }

    /// <summary>
    /// Produces a fully masked string of the specified length.
    /// </summary>
    /// <remarks>
    /// This method generates a masking placeholder using a repeated mask character.
    /// </remarks>
    /// <param name="length">The length of the masked value to generate.</param>
    /// <returns>Returns a fully masked string.</returns>
    private static string MaskFull(
        int length)
    {
        if (length <= 0)
        {
            return string.Empty;
        }

        return new string(SanitizationDefaults.MaskCharacter, Math.Min(length, SanitizationDefaults.MinimumVisibleCharacterLengthForFullMask));
    }

    /// <summary>
    /// Masks an email address using an email-specific masking strategy.
    /// </summary>
    /// <remarks>
    /// This method preserves limited identifiable structure while hiding sensitive parts.
    /// </remarks>
    /// <param name="email">The email address to be masked.</param>
    /// <returns>Returns the masked email address.</returns>
    private static string MaskEmail(
        string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return email;
        }

        var atIndex = email.IndexOf('@');
        if (atIndex <= 1 || atIndex == email.Length - 1)
        {
            return MaskFull(email.Length);
        }

        return email[0] + "***" + email[atIndex..];
    }

    /// <summary>
    /// Masks all but the specified number of trailing characters in the value.
    /// </summary>
    /// <remarks>
    /// This method retains a limited visible suffix for identification purposes.
    /// </remarks>
    /// <param name="value">The original value to be masked.</param>
    /// <param name="visibleCharLength">The length of the characters to be made visible.</param>
    /// <returns>Returns the partially masked value.</returns>
    private static string MaskLastN(
        string value,
        int visibleCharLength)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        if (visibleCharLength <= 0 || value.Length <= visibleCharLength)
        {
            return MaskFull(value.Length);
        }

        return MaskFull(value.Length - visibleCharLength) + value[^visibleCharLength..];
    }

    /// <summary>
    /// Masks a token value using a token-specific masking strategy.
    /// </summary>
    /// <remarks>
    /// This method hides sensitive token content while preserving format safety.
    /// </remarks>
    /// <param name="token">The token value to be masked.</param>
    /// <returns>Returns the masked token.</returns>
    private static string MaskToken(
        string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return token;
        }

        return token.Length <= SanitizationDefaults.MinimumCharacterLengthForToken
            ? MaskFull(token.Length)
            : token[..2] + MaskFull(token.Length - 4) + token[^2..];
    }

    /// <summary>
    /// Masks a date of birth value to prevent exposure of personal information.
    /// </summary>
    /// <remarks>
    /// This method obscures date components while retaining a valid representation.
    /// </remarks>
    /// <param name="dateOfBirth">The date of birth value to be masked.</param>
    /// <returns>Returns the masked date of birth.</returns>
    private static string MaskDateOfBirth(
        string dateOfBirth)
    {
        if (string.IsNullOrWhiteSpace(dateOfBirth))
        {
            return dateOfBirth;
        }

        return "***-**-****";
    }

    /// <summary>
    /// Masks an address value to protect location-related personal information.
    /// </summary>
    /// <remarks>
    /// This method obscures address details while maintaining structural consistency.
    /// </remarks>
    /// <param name="address">The address value to be masked.</param>
    /// <returns>Returns the masked address.</returns>
    private static string MaskAddress(
        string address)
    {
        if (string.IsNullOrWhiteSpace(address))
        {
            return address;
        }

        return "***";
    }

    /// <summary>
    /// Masks a personal name value to prevent direct identification.
    /// </summary>
    /// <remarks>
    /// This method applies name-specific masking rules.
    /// </remarks>
    /// <param name="personName">The personal name value to be masked.</param>
    /// <returns>Returns the masked personal name.</returns>
    private static string MaskPersonName(
        string personName)
    {
        if (string.IsNullOrWhiteSpace(personName))
        {
            return personName;
        }

        if (personName.Length <= 2)
        {
            return MaskFull(personName.Length);
        }

        return personName[0] + MaskFull(personName.Length - 1);
    }

    /// <summary>
    /// Masks sensitive values within the provided JSON payload.
    /// </summary>
    /// <remarks>
    /// Applies masking rules to protect sensitive fields in the payload.
    /// Produces a sanitized JSON representation safe for logging or transport.
    /// </remarks>
    /// <param name="jsonPayload">The JSON payload containing data to sanitize.</param>
    /// <returns>Returns the sanitized JSON payload with masked sensitive values.</returns>
    private string MaskPayload(
        string jsonPayload)
    {
        try
        {
            var node = JsonNode.Parse(jsonPayload);
            if (node is null)
            {
                return jsonPayload;
            }

            MaskNode(node, currentDepth: 0);
            return node.ToJsonString(_serializerOptions);
        }
        catch (JsonException)
        {
            return jsonPayload;
        }
    }

    /// <summary>
    /// Applies masking to a JSON node based on its structure and depth.
    /// </summary>
    /// <remarks>
    /// This method traverses the JSON node hierarchy to mask sensitive values.
    /// </remarks>
    /// <param name="node">The JSON node to process.</param>
    /// <param name="currentDepth">The current traversal depth within the JSON structure.</param>
    private void MaskNode(
        JsonNode node,
        int currentDepth)
    {
        if (currentDepth >= _serializerOptions.MaxDepth)
        {
            return;
        }

        switch (node)
        {
            case JsonObject obj:

                var properties = obj.ToArray();

                foreach (var property in properties)
                {
                    var key = property.Key;
                    var value = property.Value;

                    if (value is null)
                    {
                        continue;
                    }

                    if (MaskCatalogRegistry.MaskCatalog.TryGetValue(key, out var maskType)
                        && value is JsonValue jsonValue)
                    {
                        obj[key] = MaskJsonValue(maskType, jsonValue);
                        continue;
                    }

                    MaskNode(value, currentDepth + 1);
                }

                break;
            case JsonArray array:
                foreach (var item in array)
                {
                    if (item is not null)
                    {
                        MaskNode(item, currentDepth + 1);
                    }
                }

                break;
        }
    }
}
