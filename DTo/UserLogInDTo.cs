using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApi.DTo
{
    // clase utilizada para recivir y authorizar users
    public class UserLogInDTo
    {
        [EmailAddress]
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
