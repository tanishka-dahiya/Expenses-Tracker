using System;
using System.ComponentModel.DataAnnotations;

namespace ExpensesTracker.ViewModels
{
    public class ExpensesViewModel
    {
        public int ExpensesId { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public float Price { get; set; }

        public int UserId { get; set; }
    }
}
