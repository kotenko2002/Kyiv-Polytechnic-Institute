using System;

namespace Lab_1.Models
{
    public class Record
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public decimal Sum { get; set; }
    }
}
