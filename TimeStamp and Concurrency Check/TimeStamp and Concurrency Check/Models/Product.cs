using System.ComponentModel.DataAnnotations;

namespace TimeStamp_and_Concurrency_Check.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
