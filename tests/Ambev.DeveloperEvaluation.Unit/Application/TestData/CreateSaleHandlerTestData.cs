using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateSaleHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// </summary>
    private static Faker<CreateSaleCommand> CreateValidSaleHandlerFaker(List<Guid> productIds)
    {
        return new Faker<CreateSaleCommand>()
            .RuleFor(u => u.Customer, f => f.Name.FullName())
            .RuleFor(u => u.Branch, f => f.Commerce.Department())
            .RuleFor(u => u.SaleProducts, f =>
                Enumerable.Range(1, f.Random.Int(1, 10))
                .Select(_ => new CreateSaleProductCommand
                {
                    ProductId = f.PickRandom(productIds),
                    Quantity = f.Random.Int(1, 20)
                }).ToList()
            );
    }

    /// <summary>
    /// Configures the Faker to generate invalid Sale entities.
    /// </summary>
    private static Faker<CreateSaleCommand> CreateInvalidSaleHandlerFaker(List<Guid> productIds)
    {
        return new Faker<CreateSaleCommand>()
            .RuleFor(u => u.Customer, f => f.Name.FullName())
            .RuleFor(u => u.Branch, f => f.Commerce.Department())
            .RuleFor(u => u.SaleProducts, f =>
                Enumerable.Range(1, f.Random.Int(1, 10))
                .Select(_ => new CreateSaleProductCommand
                {
                    ProductId = f.PickRandom(productIds),
                    Quantity = f.Random.Int(20, 50)
                }).ToList()
            );
    }

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated sale will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static CreateSaleCommand GenerateValidCommand(List<Guid> productIds)
    {
        return CreateValidSaleHandlerFaker(productIds).Generate();
    }

    /// <summary>
    /// Generates a invalid Sale entity with more than 20 items.
    /// The generated sale will have all properties populated with valid values
    /// except on the SaleProducts property that will have more than 20 items.
    /// </summary>
    /// <returns>A invalid Sale entity with randomly generated data.</returns>
    public static CreateSaleCommand GenerateInvalidCommand(List<Guid> productIds)
    {
        return CreateInvalidSaleHandlerFaker(productIds).Generate();
    }
}
