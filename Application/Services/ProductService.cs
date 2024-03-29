﻿using Application.DTOs.Category;
using Application.DTOs.Product;
using Application.IServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common.Enums;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Domain.Common;
namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepsitory;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHistoryRepository _historyRepository;
        public ProductService(IProductRepository productRepsitory, IMapper mapper,
            IHistoryRepository historyRepository, IHttpContextAccessor httpContextAccessor)
        {
            _productRepsitory = productRepsitory;
            _mapper = mapper;
            _historyRepository = historyRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll(ProductFilterDTO? filter)
        {
            if (filter == null)
            {
                var allproduct = await _productRepsitory.GetAllQueryAble().ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).ToListAsync();
                return allproduct;
            }
            var produts = await _productRepsitory.GetByCategoryAsync(filter.Category).ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return produts;
        }
        public async Task<IEnumerable<ProductSearchViewDTO>> SearchProductTerm(ProductSearchDTO? searchTerm)
        {

            if (searchTerm == null || string.IsNullOrEmpty(searchTerm.SearchTerm) || string.IsNullOrEmpty(searchTerm.SearchTerm.Trim()))
            {
                return null;
            }
            else
            {
                var result = await _productRepsitory.SearchProduct(searchTerm.SearchTerm)
                    .ProjectTo<ProductSearchViewDTO>(_mapper.ConfigurationProvider).ToListAsync();
                return result;
            }
        }
        public async Task<int> Create(ProductCreateDTO product)
        {
            var newProduct = _mapper.Map<ProductCreateDTO, Product>(product);
            var result = await _productRepsitory.Insert(newProduct);
            var newHistory = new History(nameof(Product), ActionType.Create, _httpContextAccessor.GetUserId(), result);
            await _historyRepository.Insert(newHistory);
            return result;

        }
        public async Task<ProductUpdateDTO> GetById(int id)
        {
            var product = (await _productRepsitory.Get(id));
            var targetProduct = _mapper.Map<Product, ProductUpdateDTO>(product);
            return targetProduct;
        }
        public async Task Update(ProductUpdateDTO product)
        {
            var newProduct = _mapper.Map<ProductUpdateDTO, Product>(product);
            await _productRepsitory.Update(newProduct);
            var newHistory = new History(nameof(Product), ActionType.Update, _httpContextAccessor.GetUserId(), product.Id);
            await _historyRepository.Insert(newHistory);

        }
        public async Task Delete(ProductDeleteDTO product)
        {
            await _productRepsitory.DeleteById(product.Id);
            var newHistory = new History(nameof(Product), ActionType.Delete, _httpContextAccessor.GetUserId(), product.Id);
            await _historyRepository.Insert(newHistory);

        }

    }
}
