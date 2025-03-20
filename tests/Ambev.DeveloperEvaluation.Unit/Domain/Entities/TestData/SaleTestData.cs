using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// </summary>
    private static Faker<Sale> CreateValidSaleHandlerFaker(List<Product> products)
    {
        var random = new Random();
        var product = products[random.Next(products.Count)];

        return new Faker<Sale>()
            .RuleFor(u => u.Number, f => f.Random.Int(1, 100))
            .RuleFor(u => u.Customer, f => f.Name.FullName())
            .RuleFor(u => u.Branch, f => f.Commerce.Department())
            .RuleFor(u => u.SaleProducts, f =>
                Enumerable.Range(1, 1)
                .Select(_ => new SaleProduct
                {
                    ProductId = product.Id,
                    Product = product,
                    Quantity = f.Random.Int(1, 20)
                }).ToList()
            )
            .FinishWith((f, sale) => sale.SetSaleValue());
    }

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated Sale will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static Sale GenerateValidSale(List<Product> products)
    {
        return CreateValidSaleHandlerFaker(products).Generate();
    }
}
