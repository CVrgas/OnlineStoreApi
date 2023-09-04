using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineStoreApi.Models;

namespace OnlineStoreApi.DTo
{
    public class ProductDTo
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public List<string> ImagesUrl { get; set; } = new List<string>();

        public string Thumbnail { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
