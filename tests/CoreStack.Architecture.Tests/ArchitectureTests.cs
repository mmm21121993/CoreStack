using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace CoreStack.Architecture.Tests;

/// <summary>
/// Defines architecture validation tests for solution layer dependencies.
/// </summary>
/// <remarks>
/// Verifies dependency rules between solution layers.
/// Ensures layering constraints are enforced during development.
/// Uses architecture testing utilities to detect violations.
/// </remarks>
public sealed class ArchitectureTests
{
    /// <summary>
    /// Defines the namespace used by the abstractions layer.
    /// </summary>
    private const string _abstractionProjectNamespace = "CoreStack.Abstraction";

    /// <summary>
    /// Defines the namespace used by the API layer.
    /// </summary>
    private const string _apiProjectNamespace = "CoreStack.Api";

    /// <summary>
    /// Defines the namespace used by the application layer.
    /// </summary>
    private const string _applicationProjectNamespace = "CoreStack.Application";

    /// <summary>
    /// Defines the namespace used by the domain layer.
    /// </summary>
    private const string _domainProjectNamespace = "CoreStack.Domain";

    /// <summary>
    /// Defines the namespace used by the infrastructure layer.
    /// </summary>
    private const string _infrastructureProjectNamespace = "CoreStack.Infrastructure";

    /// <summary>
    /// Defines the namespace used by architecture testing utilities.
    /// </summary>
    private const string _architectureNamespace = "NetArchTest";

    /// <summary>
    /// Validates that the domain layer has no external dependencies.
    /// </summary>
    /// <remarks>
    /// Ensures domain types remain independent from other layers.
    /// Enforces isolation of domain logic.
    /// </remarks>
    [Fact]
    public void Domain_Should_Have_No_Dependencies()
    {
        var result = Types.InAssembly(typeof(Domain.AssemblyReference).Assembly)
            .ShouldNot()
            .HaveDependencyOnAny(
                _apiProjectNamespace,
                _applicationProjectNamespace,
                _abstractionProjectNamespace,
                _infrastructureProjectNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    /// <summary>
    /// Validates that the abstractions layer has no external dependencies.
    /// </summary>
    /// <remarks>
    /// Ensures abstractions remain independent from implementation layers.
    /// Enforces isolation of shared contracts.
    /// </remarks>
    [Fact]
    public void Abstractions_Should_Have_No_Dependencies()
    {
        var result = Types.InAssembly(typeof(Abstraction.AssemblyReference).Assembly)
            .ShouldNot()
            .HaveDependencyOnAny(
                _apiProjectNamespace,
                _applicationProjectNamespace,
                _domainProjectNamespace,
                _infrastructureProjectNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    /// <summary>
    /// Validates that the application layer depends only on domain and abstractions.
    /// </summary>
    /// <remarks>
    /// Ensures application logic depends only on allowed layers.
    /// Enforces correct layering boundaries.
    /// </remarks>
    [Fact]
    public void Application_Should_Only_Depend_On_Domain_And_Abstractions()
    {
        var result = Types.InAssembly(typeof(Application.AssemblyReference).Assembly)
            .ShouldNot()
            .HaveDependencyOnAny(
                _infrastructureProjectNamespace,
                _apiProjectNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    /// <summary>
    /// Validates that the infrastructure layer does not depend on the API layer.
    /// </summary>
    /// <remarks>
    /// Ensures infrastructure implementation remains independent from presentation logic.
    /// Enforces correct dependency direction.
    /// </remarks>
    [Fact]
    public void Infrastructure_Should_Not_Depend_On_Api()
    {
        var result = Types.InAssembly(typeof(Infrastructure.AssemblyReference).Assembly)
            .ShouldNot()
            .HaveDependencyOn(_apiProjectNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    /// <summary>
    /// Validates that the API layer does not depend directly on the domain layer.
    /// </summary>
    /// <remarks>
    /// Ensures API interactions occur through application services.
    /// Enforces proper separation of presentation and domain concerns.
    /// </remarks>
    [Fact]
    public void Api_Should_Not_Depend_On_Domain_Directly()
    {
        var result = Types.InAssembly(typeof(Api.AssemblyReference).Assembly)
            .ShouldNot()
            .HaveDependencyOn(_domainProjectNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    /// <summary>
    /// Validates that the domain layer does not reference architecture testing utilities.
    /// </summary>
    /// <remarks>
    /// Ensures testing frameworks are not referenced in domain code.
    /// Enforces strict separation between domain logic and test dependencies.
    /// </remarks>
    [Fact]
    public void Domain_Should_Not_Reference_NetArchTest()
    {
        var result = Types.InAssembly(typeof(Domain.AssemblyReference).Assembly)
            .ShouldNot()
            .HaveDependencyOn(_architectureNamespace)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
