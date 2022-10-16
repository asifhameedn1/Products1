using Products.Entities;

namespace Products.Repo.Interface
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductDetails(int id);
        Task<int> Create(Product product);
        Task<int> Update(Product product);
    }
}
