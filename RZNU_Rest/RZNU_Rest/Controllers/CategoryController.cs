using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RZNU_Rest.Models;
using RZNU_Rest.Resources;
using RZNU_Rest.Services;
using AutoMapper;
using RZNU_Rest.Extensions;
using RZNU_Rest.Authentication;

namespace RZNU_Rest.Controllers
{
    [Route("api/[controller]")]
    [Route("/api/categories")]
    [Produces("application/json")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper) {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all existing categories.
        /// </summary>
        /// <returns>List of categories.</returns>
        [HttpGet]
        [BasicAuthentication]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync() {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }



        /// <summary>
        /// Saves a new product.
        /// </summary>
        /// <param name="id">Category identifier.</param>
        /// <param name="resource">Category data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [BasicAuthentication]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);
            if (!result.Success) return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }


        /// <summary>
        /// Updates an existing category according to an identifier.
        /// </summary>
        /// <param name="id">Category identifier.</param>
        /// <param name="resource">Category data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [BasicAuthentication]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success) return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
                return Ok(categoryResource);
        }

        /// <summary>
        /// Deletes a given category according to an identifier.
        /// </summary>
        /// <param name="id">Category identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [BasicAuthentication]
        public async Task<IActionResult> DeleteAsync(int id) {
            var result = await _categoryService.DeleteAsync(id);
            if (!result.Success) return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

    }
}