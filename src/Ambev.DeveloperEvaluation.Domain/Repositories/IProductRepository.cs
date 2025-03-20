using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Product entity operations
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Creates a new product in the repository
    /// </summary>
    /// <param name="product">The product to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product</returns>
    public Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get existing products in the database by the name and the unit value
    /// </summary>
    /// <param name="name">The Product name</param>
    /// <param name="unitValue">The Product unit value</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The nullable list of Products</returns>
    public Task<List<Product>?> GetByNameAndPrice(string name, decimal unitValue, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get existing product in the database by the id
    /// </summary>
    /// <param name="id">The Product id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if it is in the database or null</returns>
    public Task<Product?> GetById(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get existing products in the database by the ids
    /// </summary>
    /// <param name="ids">The Products ids</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A nullable list of Products</returns>
    public Task<List<Product>?> GetById(List<Guid> ids, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all existing products in the database
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A nullable list of Products</returns>
    public Task<List<Product>?> GetAll(CancellationToken cancellationToken = default);
}
