﻿using RZNU_Rest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZNU_Rest.Services.Communications
{
    public class CategoryResponse : BaseResponse
    {
        public Category Category { get; private set; }

        private CategoryResponse(bool success, string message, Category category): base(success, message) {
            Category = category;
        }

        public CategoryResponse(Category category) : this(true, string.Empty, category) { }

        public CategoryResponse(string message) : this(false, message, null) { }
        
    }
}
