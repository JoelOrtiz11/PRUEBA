using Microsoft.EntityFrameworkCore;

namespace prueba.Models
{
    public class trabajosDbContext : DbContext
    {
        public trabajosDbContext(DbContextOptions<trabajosDbContext> options) : base(options)
        { }
    
        public DbSet<empresa> empresa { get; set; } 
    }
}
