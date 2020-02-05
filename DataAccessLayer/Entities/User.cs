using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

       
    }
}
