using Microsoft.EntityFrameworkCore;

namespace Library_Management_Module_MVC_PopUp.Models.Dbcontext
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrowed_Book> BorrowedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Borrowed_Book>()
                .HasOne(b => b.User)
                .WithMany(u => u.BorrowedBooks)
                .HasForeignKey(b => b.UserID);

            modelBuilder.Entity<Borrowed_Book>()
                .HasOne(b => b.Book)
                .WithMany(bk => bk.BorrowedBooks)
                .HasForeignKey(b => b.BookID);
        }   
    }
}
