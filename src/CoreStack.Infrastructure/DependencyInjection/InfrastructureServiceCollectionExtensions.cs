using CoreStack.Infrastructure.Sanitization;
using CoreStack.Infrastructure.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace CoreStack.Infrastructure.DependencyInjection;

/// <summary>
/// Provides extension methods for registering infrastructure services.
/// </summary>
/// <remarks>
/// Defines service registration for infrastructure layer components.
/// Configures dependencies required by infrastructure implementations.
/// Supports centralized setup of infrastructure services through dependency injection.
/// </remarks>
public static class InfrastructureServiceCollectionExtensions
{
    /// <summary>
    /// Registers infrastructure services into the service collection.
    /// </summary>
    /// <remarks>
    /// Adds infrastructure dependencies required by the application.
    /// Enables infrastructure capabilities through dependency injection.
    /// </remarks>
    /// <param name="services">The service collection used to register dependencies.</param>
    /// <returns>Returns the updated service collection.</returns>
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services)
    {
        services.AddSerialization();

        services.AddSanitization();

        return services;
    }
}
