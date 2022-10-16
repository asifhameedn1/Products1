using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Service.ViewModels;

namespace Products.Service.Interface
{  
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<int> Create(ProductViewModel product);
        Task<ProductViewModel> GetProductDetails(int id);
        Task<int> Update(ProductViewModel product);
    }
}
