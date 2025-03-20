using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IProductRepository using Entity Framework Core
/// </summary>
public class ProductRepository(DefaultContext context) : IProductRepository
{
    private readonly DefaultContext _context = context;

    /// <summary>
    /// Creates a new Product in the database
    /// </summary>
    /// <param name="product">The Product to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Product</returns>
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    /// <summary>
    /// Get existing products in the database by the name and the unit value
    /// </summary>
    /// <param name="name">The Product name</param>
    /// <param name="unitValue">The Product unit value</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A nullable list of Products</returns>
    public async Task<List<Product>?> GetByNameAndPrice(string name, decimal unitValue, CancellationToken cancellationToken = default)
    {
        return await _context.Products.Where(w => w.Name == name &&
                                                  w.UnitValue == unitValue).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Get existing product in the database by the id
    /// </summary>
    /// <param name="id">The Product id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if it is in the database or null</returns>
    public async Task<Product?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products.FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
    }

    /// <summary>
    /// Get existing products in the database by the ids
    /// </summary>
    /// <param name="ids">The Products ids</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A nullable list of Products</returns>
    public async Task<List<Product>?> GetById(List<Guid> ids, CancellationToken cancellationToken = default)
    {
        return await _context.Products.Where(w => ids.Any(a => a == w.Id)).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Get all existing products in the database
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A nullable list of Products</returns>
    public async Task<List<Product>?> GetAll(CancellationToken cancellationToken = default)
    {
        return await _context.Products.ToListAsync(cancellationToken);
    }
}
