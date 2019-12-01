using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RZNU_Rest.Services;
using RZNU_Rest.Resources;
using RZNU_Rest.Models;
using RZNU_Rest.Authentication;

namespace RZNU_Rest.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [BasicAuthentication]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper) {
            _productService = productService;
            _mapper = mapper;
        }


        /// <summary>
        /// Lists all existing products.
        /// </summary>
        /// <returns>List of products.</returns>
        [HttpGet]
        
        public async Task<IEnumerable<ProductResource>> GetAsync() {
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        [HttpGet("{id}")]
        /// <summary>
        /// Lists all existing products under category.
        /// </summary>
        /// <returns>List of products.</returns>
        public async Task<IEnumerable<ProductResource>> GetAsync(int? categoryId) {
            var products = await _productService.ListAsync(categoryId);
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        /// <summary>
        /// Saves a new product.
        /// </summary>
        /// <param name="id">Product identifier.</param>
        /// <param name="resource">Product data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        
        public async Task<IActionResult> PostAsync(int id, [FromBody] SaveProductResource resource) {
            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.SaveAsync(id, product);

            if (!result.Success) { return BadRequest(result.Message); }

            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }

        /// <summary>
        /// Updates an existing product according to an identifier.
        /// </summary>
        /// <param name="id">Product identifier.</param>
        /// <param name="resource">Product data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource) {
            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.UpdateAsync(id, product);
            if (!result.Success) return BadRequest(result.Message);

            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }

        /// <summary>
        /// Deletes a given product according to an identifier.
        /// </summary>
        /// <param name="id">Product identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeleteAsync(int id) {
            var result = await _productService.DeleteAsync(id);
            if (!result.Success) return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(categoryResource);
        }
    }
}