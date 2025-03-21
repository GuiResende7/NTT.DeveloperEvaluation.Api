using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Sale entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class SaleTests
{
    private readonly IProductRepository _productRepository;

    public SaleTests()
    {
        _productRepository = Substitute.For<IProductRepository>();
    }

    /// <summary>
    /// Tests that when a active sale is canceled, their flag changes to Canceled as true.
    /// </summary>
    [Fact(DisplayName = "Sale should change to cancel when canceled")]
    public async Task Given_ActiveSale_When_Canceled_Then_CanceledIsTrue()
    {
        var products = await _productRepository.GetAll();
        if (products is null || !products.Any())
        {
            throw new InvalidOperationException("No products found in the database");
        }
        // Arrange
        var sale = SaleTestData.GenerateValidSale(products);

        // Act
        sale.Cancel();

        // Assert
        Assert.True(sale.Canceled);
    }
}
