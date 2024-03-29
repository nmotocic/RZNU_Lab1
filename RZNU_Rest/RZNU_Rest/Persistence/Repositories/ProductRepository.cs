﻿using Microsoft.EntityFrameworkCore;
using RZNU_Rest.Models;
using RZNU_Rest.Persistence.Contexts;
using RZNU_Rest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZNU_Rest.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {

        public ProductRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> ListAsync(int? categoryId)
        {
            var queryable = _context.Products
                                    .Include(p => p.Category)
                                    .AsNoTracking();

            if (categoryId.HasValue && categoryId > 0)
            {
                return await queryable.Where(p => p.CategoryId == categoryId)
                                      .ToListAsync();
            }

            return await queryable.ToListAsync();
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        
    }
}
