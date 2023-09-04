using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApi.DTo
{
    public class UserProductDTo
    {
        [Key]
        public int UserProductID { get; set; }

        [ForeignKey("UserId")]
        public int UserID { get; set; }

        [ForeignKey("ProductId")]
        public int ProductID { get; set; }

        public int Quantity { get; set; }
    }
}
