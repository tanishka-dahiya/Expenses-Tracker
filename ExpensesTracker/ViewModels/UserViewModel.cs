using System.ComponentModel.DataAnnotations;

namespace ExpensesTracker.ViewModels
{
    public class UserViewModel
    { 
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
