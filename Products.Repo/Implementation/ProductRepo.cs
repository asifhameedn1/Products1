using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Products.Entities;
using Products.Repo.Interface;

namespace Products.Repo.Implementation
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductDbContext _dbContext;
        public ProductRepo(ProductDbContext productDbContext)
        {
            _dbContext = productDbContext;
        }

        public async Task<int> Create(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> Update(Product product)
        {
            var prod = await _dbContext.Products.FirstAsync(x => x.Id == product.Id);
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.ColorName = product.ColorName;
            prod.Stock = product.Stock;
            prod.Size = product.Size;
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<Product> GetProductDetails(int id)
        {
            return await _dbContext.Products.FirstAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }
    }
}
