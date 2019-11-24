using RZNU_Rest.Models;
using RZNU_Rest.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace RZNU_Rest.Mapping
{
    public class ModelToResourceProfile : Profile
    {

        public ModelToResourceProfile() {
            CreateMap<Category, CategoryResource>();

            CreateMap<Product, ProductResource>();
        }
    }
}
