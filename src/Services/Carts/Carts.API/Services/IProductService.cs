using Inveon.eCommerceExample.Carts.API.Models;

namespace Inveon.eCommerceExample.Carts.API.Services;

public interface IProductService
{
    Task<IEnumerable<Product>?> GetProducts();

    Task<Product?> GetProduct(Guid id);
}
