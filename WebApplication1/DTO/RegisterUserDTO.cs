﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class RegisterUserDTO
    {
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
