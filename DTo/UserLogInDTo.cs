using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApi.DTo
{
    public class UserLogInDTo
    {
        [EmailAddress]
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
