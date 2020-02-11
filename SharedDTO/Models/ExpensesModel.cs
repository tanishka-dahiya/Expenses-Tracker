using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedDTO.Models
{
   public class ExpensesModel
    {
        public Guid ExpensesId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public float Price { get; set; }

        public Guid UserId { get; set; }
    }
}
