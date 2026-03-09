using System.Text.Json;
using CoreStack.Abstraction.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace CoreStack.Infrastructure.Serialization;

/// <summary>
/// Provides extension methods for registering serialization services.
/// </summary>
/// <remarks>
/// Defines service registration for serialization infrastructure.
/// Configures dependencies required for JSON serialization operations.
/// Supports centralized setup of serialization services through dependency injection.
/// </remarks>
internal static class SerializationServiceCollectionExtensions
{
    /// <summary>
    /// Registers serialization services into the service collection.
    /// </summary>
    /// <remarks>
    /// Adds serialization service dependencies required by the application.
    /// Enables JSON serialization capabilities through dependency injection.
    /// </remarks>
    /// <param name="services">The service collection used to register dependencies.</param>
    /// <returns>Returns the updated service collection.</returns>
    public static IServiceCollection AddSerialization(
        this IServiceCollection services)
    {
        services.Configure<JsonSerializerOptions>(JsonSerializerDefaults.Configure);

        services.AddSingleton<ISerializationService, SerializationService>();

        return services;
    }
}
