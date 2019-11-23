using Microsoft.EntityFrameworkCore;
using RZNU_Rest.Models;
using RZNU_Rest.Persistence.Contexts;
using RZNU_Rest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZNU_Rest.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        

        public CategoryRepository(AppDbContext context) : base(context) { }

        public Task AddAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
