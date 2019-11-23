using RZNU_Rest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZNU_Rest.Services.Communications
{
    public class SaveCategoryResponse : BaseResponse
    {
        public Category Category { get; private set; }

        private SaveCategoryResponse(bool success, string message, Category category): base(success, message) {
            Category = category;
        }

        public SaveCategoryResponse(Category category) : this(true, string.Empty, category) { }

        public SaveCategoryResponse(string message) : this(false, message, null) { }
        
    }
}
