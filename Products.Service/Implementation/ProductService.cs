using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Products.Entities;
using Products.Repo.Interface;
using Products.Service.Interface;
using Products.Service.ViewModels;

namespace Products.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;
        public ProductService(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var products = await _productRepo.GetProducts();
            var productsViewModel = _mapper.Map<IEnumerable<ProductViewModel>>(products);
            return productsViewModel;
        }

        public async Task<int> Create(ProductViewModel product)
        {
            var prod = _mapper.Map<Product>(product);
            var res = await _productRepo.Create(prod);
            return res;
        }

        public async Task<ProductViewModel> GetProductDetails(int id)
        {
            var product = await _productRepo.GetProductDetails(id);
            var productsViewModel = _mapper.Map<ProductViewModel>(product);
            return productsViewModel;
        }

        public async Task<int> Update(ProductViewModel product)
        {
            var prod = _mapper.Map<Product>(product);
            var res = await _productRepo.Update(prod);
            return res;
        }
    }
}
