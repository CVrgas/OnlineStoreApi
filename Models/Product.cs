using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OnlineStoreApi.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public List<string> ImagesUrl { get; set; } = new List<string>();

        public string Thumbnail { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }

}
