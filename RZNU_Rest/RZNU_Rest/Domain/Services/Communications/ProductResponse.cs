using RZNU_Rest.Models;
using RZNU_Rest.Services.Communications;


namespace RZNU_Rest.Domain.Services.Communications
{
    public class ProductResponse : BaseResponse<Product>
    {
        public ProductResponse(Product product) : base(product) { }

        public ProductResponse(string message) : base(message) { }
        
    }
}
