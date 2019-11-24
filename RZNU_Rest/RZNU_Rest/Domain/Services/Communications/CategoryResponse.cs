using RZNU_Rest.Models;
using RZNU_Rest.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZNU_Rest.Domain.Services.Communications
{
    public class CategoryResponse : BaseResponse<Category>
    {
        public Category Category { get; private set; }

        private CategoryResponse(bool success, string message, Category category): base(success, message) {
            Category = category;
        }

        public CategoryResponse(Category category) : base(category) { }

        public CategoryResponse(string message) : base(message) { }
        
    }
}
