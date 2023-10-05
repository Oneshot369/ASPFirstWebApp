using ASPFirstWebApp.Models;
using Bogus;

namespace ASPFirstWebApp.Services
{
    public class HardCodedSampleDataRepository : IProductDataService<ProductModel>
    {
        static List<ProductModel> products;

        public HardCodedSampleDataRepository()
        {
            products = new List<ProductModel>();
            for (int i = 0; i < 100; i++)
            {
                products.Add(new Faker<ProductModel>()
                .RuleFor(p => p.Id, i)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                .RuleFor(p => p.Description, f => f.Rant.Review())
                );
            }
        }

        public List<ProductModel> AllProducts()
        {
            return products;
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
