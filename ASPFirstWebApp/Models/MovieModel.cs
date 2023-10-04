using System.ComponentModel;

namespace ASPFirstWebApp.Models
{
    public class MovieModel
    {
        [DisplayName("Id Number")]
        public int Id { get; set; }
        [DisplayName("Movie Name")]
        public string Name { get; set; }
        [DisplayName("Cost")]
        public decimal Price { get; set; }
        [DisplayName("When the movie starts")]
        public DateTime Date { get; set; }

        public MovieModel(int id, string name, decimal price, DateTime date)
        {
            Id = id;
            Name = name;
            Price = price;
            Date = date;
        }

        public MovieModel()
        {
        }
    }
}
