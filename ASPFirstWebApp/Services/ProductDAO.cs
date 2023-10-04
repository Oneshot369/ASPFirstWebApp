using ASPFirstWebApp.Models;
using System.Data.SqlClient;

namespace ASPFirstWebApp.Services
{
    public class ProductDAO : IProductDataService<ProductModel>
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public List<ProductModel> AllProducts()
        {
            List<ProductModel> foundProducts = new List<ProductModel>();

            string SQLStatement = "SELECT * FROM dbo.Products";

            using (SqlConnection con = new SqlConnection(connectionString))
        }

        public bool Delete(ProductModel product)
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
