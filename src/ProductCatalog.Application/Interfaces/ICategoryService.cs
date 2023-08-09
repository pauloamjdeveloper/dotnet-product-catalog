using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Utilities;

namespace ProductCatalog.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<PaginatedList<CategoryDTO>> GetCategoriesPaginated(int pageNumber, int pageSize, string filter);

        Task<IEnumerable<CategoryDTO>> GetCategories();

        Task<CategoryDTO> GetById(int? id);

        Task Add(CategoryDTO categoryDto);

        Task Update(CategoryDTO categoryDto);

        Task Remove(int? id);
    }
}
