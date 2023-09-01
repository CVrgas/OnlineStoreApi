using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApi.DTo
{
    public class ProductDTo
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
