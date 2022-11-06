using movieProject.Models.Movie;
using movieProject.Models.Weather;
using movieProject.Models.Product;

namespace LoginAPI.Models
{
    public class Cards
    {
        public IEnumerable<MovieModel>? Movies { get; set; }
        public IEnumerable<WeatherModel>? Weathers { get; set; }
        public IEnumerable<Product>? Products { get; set; }
        public bool Empty = true;
    }
}
