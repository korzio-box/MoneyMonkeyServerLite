using Microsoft.EntityFrameworkCore;
using MoneyMonkeyServerLite.Data.Models;


namespace MoneyMonkeyServerLite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base  (options)
        {
                
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Purchase> purchases { get; set; }


    }
}
