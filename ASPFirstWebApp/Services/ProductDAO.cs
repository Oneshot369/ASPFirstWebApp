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

        public bool Delete(int Id)
        {
            bool didDel = false;

            string sqlStatment = "DELETE from dbo.Products WHERE Id = @id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, con);

                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    con.Open();
                    int rows = command.ExecuteNonQuery();
                    if (rows > 0)
                        didDel = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return didDel;
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel product = null;

            string sqlStatment = "SELECT * from dbo.Products WHERE Id = @id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, con);

                command.Parameters.AddWithValue("@id", id);

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        product = (new ProductModel
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

            return product;
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
            int newIdNumber = -1;
            string sqlStatment = "Update dbo.Products SET Name = @name, Price = @price, Description = @description WHERE Id = @id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatment, con);

                command.Parameters.AddWithValue("@id", product.Id);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@description", product.Description);
                command.Parameters.AddWithValue("@price", product.Price);

                try
                {
                    con.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return newIdNumber;
            }
        }
    }
}
