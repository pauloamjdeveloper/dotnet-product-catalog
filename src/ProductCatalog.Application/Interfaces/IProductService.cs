using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Utilities;

namespace ProductCatalog.Application.Interfaces
{
    public interface IProductService
    {
        Task<PaginatedList<ProductDTO>> GetProductsPaginated(int pageNumber, int pageSize);

        Task<IEnumerable<ProductDTO>> GetProducts();

        Task<ProductDTO> GetById(int? id);
        
        Task Add(ProductDTO productDto);

        Task Update(ProductDTO productDto);

        Task Remove(int? id);
    }
}
