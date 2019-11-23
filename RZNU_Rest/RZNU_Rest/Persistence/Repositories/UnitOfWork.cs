using RZNU_Rest.Persistence.Contexts;
using RZNU_Rest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZNU_Rest.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context) {
            _context = context;
        }


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
