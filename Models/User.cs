using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace OnlineStoreApi.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public byte[] Salt { get; } = RandomNumberGenerator.GetBytes(128 / 8);
        public ICollection<Product>? Cart { get; set; }
    }
}
