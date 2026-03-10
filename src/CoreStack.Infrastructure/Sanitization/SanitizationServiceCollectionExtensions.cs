using CoreStack.Abstraction.Sanitization;
using Microsoft.Extensions.DependencyInjection;

namespace CoreStack.Infrastructure.Sanitization;

/// <summary>
/// Provides extension methods for registering sanitization services.
/// </summary>
/// <remarks>
/// Defines service registration for sanitization infrastructure.
/// Configures dependencies required for masking sensitive data.
/// Supports centralized setup of sanitization services through dependency injection.
/// </remarks>
internal static class SanitizationServiceCollectionExtensions
{
    /// <summary>
    /// Registers sanitization services into the service collection.
    /// </summary>
    /// <remarks>
    /// Adds sanitization service dependencies required by the application.
    /// Enables sensitive data masking capabilities through dependency injection.
    /// </remarks>
    /// <param name="services">The service collection used to register dependencies.</param>
    /// <returns>Returns the updated service collection.</returns>
    public static IServiceCollection AddSanitization(
        this IServiceCollection services)
    {
        services.AddSingleton<ISanitizationService, SanitizationService>();

        return services;
    }
}
