using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU3.Models
{
    class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseNpgsql("Host=localhost; Database=ExamenU3; Username=postgres; password=Roman55;").EnableSensitiveDataLogging(true);
        }

        public DbSet<Fichas> Fichas { get; set; }
        public DbSet<Historial> Historial { get; set; }
    }
}
