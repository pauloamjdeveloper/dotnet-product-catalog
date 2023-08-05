using AutoMapper;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Products.Commands;

namespace ProductCatalog.Application.Mappings
{
    public class DTOoCommandMappingProfile : Profile
    {
        public DTOoCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
