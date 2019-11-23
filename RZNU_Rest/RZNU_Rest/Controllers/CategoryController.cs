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

namespace RZNU_Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper) {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync() {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }

        [HttpPost]
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
    }
}