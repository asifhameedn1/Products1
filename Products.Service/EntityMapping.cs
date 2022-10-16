using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Products.Entities;
using Products.Service.ViewModels;

namespace Products.Service
{
    internal class EntityMapping : Profile
    {
        public EntityMapping()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            string[] splitpath = path.Split("bin");
            var newPath = splitpath[0];

            CreateMap<Product, ProductViewModel>(); 
            CreateMap<ProductViewModel,Product>();
        }
    }
}
