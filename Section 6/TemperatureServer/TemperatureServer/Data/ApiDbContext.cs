using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TemperatureServer.Models;

namespace TemperatureServer.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Temperature> Temperatures { get; set; }
    }
}
