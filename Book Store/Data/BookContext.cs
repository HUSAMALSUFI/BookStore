using Microsoft.EntityFrameworkCore;
using Book_Store.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Book_Store.Data
{
    public class BookContext : IdentityDbContext<ApplicationUser>
    {
        IConfiguration Config;
        public BookContext(IConfiguration _Config)
        {
            Config = _Config;
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Authors> authors { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<Book> books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.GetConnectionString("HRConnection"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
