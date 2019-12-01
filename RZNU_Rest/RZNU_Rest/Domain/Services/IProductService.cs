using RZNU_Rest.Domain.Services.Communications;
using RZNU_Rest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZNU_Rest.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<IEnumerable<Product>> ListAsync(int? category);
        Task<ProductResponse> SaveAsync(int id, Product product);
        Task<ProductResponse> UpdateAsync(int id, Product product);
        Task<ProductResponse> DeleteAsync(int id);
       
    }
}
