﻿using AutoMapper;
using MediatR;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Application.Products.Commands;
using ProductCatalog.Application.Products.Queries;
using ProductCatalog.Application.Utilities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IMediator mediator, IProductRepository productRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _productRepository = productRepository;
        }

        public async Task<PaginatedList<ProductDTO>> GetProductsPaginated(int pageNumber, int pageSize, string filter)
        {
            var products = await _productRepository.GetProductsAsync();

            if (!string.IsNullOrEmpty(filter))
            {
                products = products.Where(p => p.Name.Contains(filter, StringComparison.OrdinalIgnoreCase));
            }

            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);
            
            var paginatedProducts = PaginatedList<ProductDTO>.Create(productDTOs, pageNumber, pageSize);

            return paginatedProducts;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            foreach (var productDTO in productDTOs)
            {
                var product = products.FirstOrDefault(p => p.Id == productDTO.Id);
                if (product != null && product.Category != null)
                {
                    productDTO.CategoryName = product.Category.Name;
                }
            }

            return productDTOs;
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null) 
            {
                throw new Exception($"Entity could not be loadded.");
            }

            var result = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task Add(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productUpdteCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(productUpdteCommand);
        }

        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if (productRemoveCommand == null) 
            {
                throw new Exception($"Entity could not be loaded.");
            }

            await _mediator.Send(productRemoveCommand);
        }
    }
}
