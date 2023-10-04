using ASPFirstWebApp.Models;

namespace ASPFirstWebApp.Services
{
    public interface IProductDataService<T>
    {
        List<T> AllProducts();
        List<T> SearchProducts(string searchTerm);
        T GetProductById(int id);
        int Insert(T product);
        bool Delete(T product);
        int Update(T product);
    }
}
