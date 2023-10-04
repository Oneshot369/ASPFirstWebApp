using System.ComponentModel;

namespace ASPFirstWebApp.Models
{
    public class ProductModel
    {
        [DisplayName("Id Number")]
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public string Name { get; set; }
        [DisplayName("Cost")]
        public decimal Price { get; set; }
        [DisplayName("What you get")]
        public string Description { get; set; }

        public ProductModel(int id, string name, decimal price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public ProductModel()
        {
        }
    }
}
