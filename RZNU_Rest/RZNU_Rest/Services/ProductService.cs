using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RZNU_Rest.Models;
using RZNU_Rest.Repositories;

namespace RZNU_Rest.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }
    }
}
