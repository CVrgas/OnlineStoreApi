﻿using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApi.DTo
{
    // clase utilizada para recivir user
    public class UserDTo
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
