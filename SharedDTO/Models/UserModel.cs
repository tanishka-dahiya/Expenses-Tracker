using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedDTO.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }
        
        public string Password { get; set; }

        public string Token { get; set; }

    }
}
