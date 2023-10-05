using ASPFirstWebApp.Models;
using Microsoft.Data.SqlClient;

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
            {
                SqlCommand command = new SqlCommand(SQLStatement, con);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel
                        (
                            (int)reader[0],
                            (string)reader[1],
                            (decimal)reader[2],
                            (string)reader[3]
                        ));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundProducts;
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
            List<ProductModel> foundProducts = new List<ProductModel>();

            string SQLStatement = "SELECT * FROM dbo.Products WHERE Name LIKE @name";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SQLStatement, con);

                command.Parameters.AddWithValue("@name", '%' + searchTerm + '%');

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel
                        (
                            (int)reader[0],
                            (string)reader[1],
                            (decimal)reader[2],
                            (string)reader[3]
                        ));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundProducts;
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
