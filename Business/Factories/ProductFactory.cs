using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProductFactory
{
    public static ProductModel Create(ProductEntity entity)
    {
        return new ProductModel
        {
            Id = entity.Id,
            ProductName = entity.ProductName,
            ProductDescription = entity.ProductDescription,
            Price = entity.Price
        };
    }

    public static IEnumerable<ProductModel> Create(IEnumerable<ProductEntity> productEntities)
    {
        return productEntities?.Select(Create) ?? [];
    }
}

//internal static IEnumerable<ProductModel> Create(object productEntity)
//{
//    throw new NotImplementedException();
//}

