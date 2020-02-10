using System;
using System.Collections.Generic;
using System.Text;

namespace SharedDTO.Models
{
   public class ExpensesModel
    {
        public Guid ExpensesId { get; set; }

        public string Title { get; set; }
        
        public DateTime Date { get; set; }

        public float Price { get; set; }

        public Guid UserId { get; set; }
    }
}
