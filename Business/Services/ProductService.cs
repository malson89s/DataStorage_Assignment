using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ProductService(IProductRepository productRepository)
{
    private readonly IProductRepository _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

    // Hämta alla produkter
    public async Task<IEnumerable<ProductModel>> GetProductsAsync()
    {
        var productEntities = await _productRepository.GetAsync();
        return ProductFactory.Create(productEntities);
    }

    // Hämta en specifik produkt baserat på ID
    public async Task<ProductModel?> GetProductByIdAsync(int productId)
    {
        var productEntity = await _productRepository.GetAsync(p => p.Id == productId);
        return productEntity == null ? null : ProductFactory.Create(productEntity);
    }
}

