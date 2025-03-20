using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="CreateSaleHandler"/> class.
/// </summary>
public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly CreateSaleHandler _handler;

    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _productRepository = Substitute.For<IProductRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new CreateSaleHandler(_saleRepository, _productRepository, _mapper);
    }

    /// <summary>
    /// Tests that a valid sale creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid sale data When creating sale Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        var products = await _productRepository.GetAll();
        if (products is null || !products.Any())
        {
            throw new InvalidOperationException("No products found in the database");
        }

        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand(products.Select(s => s.Id).ToList());
        var sale = new Sale
        {
            Id = Guid.NewGuid(),
            Customer = command.Customer,
            Branch = command.Branch,
            SaleProducts = command.SaleProducts.Select(sp => new SaleProduct
            {
                ProductId = sp.ProductId,
                Quantity = sp.Quantity
            }).ToList()
        };

        var result = new CreateSaleResult
        {
            Id = sale.Id,
            Number = sale.Number,
            SaleDate = sale.SaleDate,
            Customer = sale.Customer,
            Branch = sale.Branch,
            TotalAmount = sale.TotalAmount,
            TotalAmountWithDiscount = sale.TotalAmountWithDiscount,
            Discount = sale.Discount,
            DiscountPercentage = sale.DiscountPercentage,
            Canceled = sale.Canceled,
            SaleProducts = sale.SaleProducts.Select(sp => new CreateSaleProductResult
            {
                ProductId = sp.ProductId,
                Quantity = sp.Quantity
            }).ToList()
        };


        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);

        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        // When
        var CreateSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        CreateSaleResult.Should().NotBeNull();
        CreateSaleResult.Id.Should().Be(sale.Id);
        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid sale creation request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid sale data When creating sale Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new CreateSaleCommand(); // Empty command will fail validation

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    /// <summary>
    /// Tests that the sale has above 20 items
    /// </summary>
    [Fact(DisplayName = "Given invalid command that has above 20 items When handling Then thorws invalid operation exception")]
    public async Task Handle_ValidRequest_MapsCommandToUser()
    {
        var products = await _productRepository.GetAll();
        if (products is null || !products.Any())
        {
            throw new InvalidOperationException("No products found in the database");
        }
        // Given
        var command = CreateSaleHandlerTestData.GenerateInvalidCommand(products.Select(s => s.Id).ToList());
        var sale = new Sale
        {
            Id = Guid.NewGuid(),
            Customer = command.Customer,
            Branch = command.Branch,
            SaleProducts = command.SaleProducts.Select(sp => new SaleProduct
            {
                ProductId = sp.ProductId,
                Quantity = sp.Quantity
            }).ToList()
        };

        _mapper.Map<Sale>(command).Returns(sale);
        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        // When & Then
        await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
    }
}
