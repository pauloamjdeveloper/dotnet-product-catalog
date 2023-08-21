using AutoMapper;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Mappings;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Tests.Mappings
{
    public class DomainToDTOMappingTest
    {
        [Fact(DisplayName = "Map - Mapping Valid Between Category and CategoryDTO")]
        public void DomainToDTOMappingProfile_Map_ShouldReturnMappingBetweenCategoryAndCategoryDTO()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<DomainToDTOMappingProfile>());
            var mapper = new Mapper(configuration);

            var category = new Category();
            var categoryDTO = mapper.Map<CategoryDTO>(category);

            Assert.NotNull(categoryDTO);
            Assert.Equal(category.Name, categoryDTO.Name);
        }

        [Fact(DisplayName = "Map - Mapping Valid Between Product and ProductDTO")]
        public void DomainToDTOMappingProfile_Map_ShouldReturnMappingBetweenProductAndProductDTO()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<DomainToDTOMappingProfile>());
            var mapper = new Mapper(configuration);

            var product = new Product(1, "Product Name", "Product Description", 100.00m, 10, "product.jpg");

            var productDTO = mapper.Map<ProductDTO>(product);

            Assert.NotNull(productDTO);
            Assert.Equal(product.Id, productDTO.Id);
            Assert.Equal(product.Name, productDTO.Name);
            Assert.Equal(product.Description, productDTO.Description);
            Assert.Equal(product.Price, productDTO.Price);
            Assert.Equal(product.Stock, productDTO.Stock);
            Assert.Equal(product.Image, productDTO.Image);
        }

    }
}