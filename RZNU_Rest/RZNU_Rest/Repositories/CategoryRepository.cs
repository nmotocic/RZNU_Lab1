using Microsoft.EntityFrameworkCore;
using RZNU_Rest.Models;
using RZNU_Rest.Persistence.Contexts;
using RZNU_Rest.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZNU_Rest.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task AddAsync(Category category) {
            await _context.Categories.AddAsync(category);
        }

    }
}
