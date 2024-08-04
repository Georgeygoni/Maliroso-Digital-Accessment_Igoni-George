using Microsoft.EntityFrameworkCore;


namespace Maliroso_Task3_Databases
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-JOFBHPG; Database=Maliroso_Task3; Trusted_Connection=true; TrustServerCertificate=True;");
        }
    }
}
