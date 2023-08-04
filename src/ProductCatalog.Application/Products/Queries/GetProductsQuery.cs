using MediatR;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>> { }
}
