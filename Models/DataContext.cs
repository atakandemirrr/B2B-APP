using Microsoft.EntityFrameworkCore;

namespace B2B_Deneme.Models
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
