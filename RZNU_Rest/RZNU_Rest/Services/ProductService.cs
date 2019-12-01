using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RZNU_Rest.Domain.Services.Communications;
using RZNU_Rest.Models;
using RZNU_Rest.Repositories;

namespace RZNU_Rest.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository) {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductResponse> DeleteAsync(int id)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);
            if (existingProduct == null) return new ProductResponse("Product not found");

            try
            {
                _productRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(existingProduct);
            }
            catch (Exception ex) {
                return new ProductResponse($"An error occured when deleteing the product: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public Task<IEnumerable<Product>> ListAsync(int? categoryId)
        {
            return _productRepository.ListAsync(categoryId);
        }

        public async Task<ProductResponse> SaveAsync(int id, Product product)
        {
            try
            {
                var existingCategory = await _categoryRepository.FindByIdAsync(product.CategoryId);
                if (existingCategory == null) return new ProductResponse("Invalid category!");

                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(product);
            }
            catch (Exception ex) {
                return new ProductResponse($"An error has occured when saving the product: {ex.Message}");
            }
        }

        

        public async Task<ProductResponse> UpdateAsync(int id, Product product)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);
            if (existingProduct == null) return new ProductResponse("Product not found!");

            var existingCategory = await _categoryRepository.FindByIdAsync(product.CategoryId);
            if (existingCategory == null) return new ProductResponse("Invalid category!");

            existingProduct.Name = product.Name;
            existingProduct.CategoryId = product.CategoryId;

            try
            {
                _productRepository.Update(existingProduct);
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(existingProduct);
            }
            catch (Exception ex) {
                return new ProductResponse($"An error has occured when updating the product: {ex.Message}");
            }
        }

        
    }
}
