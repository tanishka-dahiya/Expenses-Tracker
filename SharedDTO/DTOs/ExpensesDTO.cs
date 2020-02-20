using System;

namespace SharedDTO.DTOs
{
    public class ExpensesDTO
    {
        public int ExpensesId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }
        public int UserId { get; set; }
    }
}
