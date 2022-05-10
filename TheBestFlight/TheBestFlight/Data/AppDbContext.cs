using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBestFlight.Models;

namespace TheBestFlight.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Tratta> eleTratte { get; set; }
        public DbSet<Associazione> eleAssociazioni { get; set; }
    }
}
