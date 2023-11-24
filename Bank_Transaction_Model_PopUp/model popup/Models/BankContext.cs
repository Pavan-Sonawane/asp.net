using Microsoft.EntityFrameworkCore;

namespace model_popup.Models
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Bank_Details> Details { get; set; }
    }
}
