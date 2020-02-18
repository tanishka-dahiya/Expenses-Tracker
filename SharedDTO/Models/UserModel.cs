using System;
using System.ComponentModel.DataAnnotations;

namespace SharedDTO.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Token { get; set; }

    }
}
