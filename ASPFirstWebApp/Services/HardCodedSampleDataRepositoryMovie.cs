using ASPFirstWebApp.Models;
using Bogus;

namespace ASPFirstWebApp.Services
{
    public class HardCodedSampleDataRepositoryMovie : IProductDataService<MovieModel>
    {
        static List<MovieModel> products;

        public HardCodedSampleDataRepositoryMovie()
        {
            products = new List<MovieModel>();
            for (int i = 0; i < 100; i++)
            {
                products.Add(new Faker<MovieModel>()
                .RuleFor(p => p.Id, i)
                .RuleFor(p => p.Name, f => f.Random.Word())
                .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                .RuleFor(p => p.Date, f => f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2023, 1, 1)))
                );
            }
        }

        public List<MovieModel> AllProducts()
        {
            return products;
        }

        public bool Delete(MovieModel product)
        {
            throw new NotImplementedException();
        }

        public MovieModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(MovieModel product)
        {
            throw new NotImplementedException();
        }

        public List<MovieModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(MovieModel product)
        {
            throw new NotImplementedException();
        }
    }
}
