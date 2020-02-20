using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    [Table("Expenses")]
    public class Expense
    {
        [Key]
        public int ExpensesId { get; set; }

        public string Title { get; set; }

        [Required]
        public DateTime Date{ get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
