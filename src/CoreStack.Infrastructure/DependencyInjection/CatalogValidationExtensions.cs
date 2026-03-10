using CoreStack.Infrastructure.Sanitization;
using Microsoft.AspNetCore.Builder;

namespace CoreStack.Infrastructure.DependencyInjection;

/// <summary>
/// Provides extension methods for validating application catalogs during startup.
/// </summary>
/// <remarks>
/// Defines validation helpers executed during application initialization.
/// Ensures configured catalogs comply with expected rules.
/// Supports early detection of invalid catalog configurations.
/// </remarks>
public static class CatalogValidationExtensions
{
    /// <summary>
    /// Validates configured catalogs during application startup.
    /// </summary>
    /// <remarks>
    /// Executes validation logic for registered catalog definitions.
    /// Ensures catalog configurations are verified before request processing.
    /// </remarks>
    /// <param name="app">The application builder used to configure the request pipeline.</param>
    /// <returns>Returns the application builder for further configuration.</returns>
    public static IApplicationBuilder ValidateCatalogs(
        this IApplicationBuilder app)
    {
        app.ValidateSensitiveKeyCatalog();

        return app;
    }

    /// <summary>
    /// Validates the sensitive key catalog configuration.
    /// </summary>
    /// <remarks>
    /// Executes validation logic for registered sensitive key catalogs.
    /// Ensures masking definitions are correctly configured.
    /// </remarks>
    /// <param name="app">The application builder used to configure the request pipeline.</param>
    /// <returns>Returns the application builder for further configuration.</returns>
    private static IApplicationBuilder ValidateSensitiveKeyCatalog(
        this IApplicationBuilder app)
    {
        MaskCatalogValidator.ValidateSensitiveKeyCatalog(
            MaskCatalogRegistry.MaskCatalog);

        return app;
    }
}
