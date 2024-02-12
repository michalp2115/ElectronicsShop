﻿using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop.Models
{
    public class RegisterRequest
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
