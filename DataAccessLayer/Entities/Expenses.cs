using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    [Table("Expenses")]
    public class Expense
    {
        [Key]
        public Guid ExpensesId { get; set; }

        public string Title { get; set; }

        [Required]
        public DateTime Date{ get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
