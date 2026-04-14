using etkinlikuygulaması.Models;
using EtkinlikUygulamasi.Models;
using Microsoft.EntityFrameworkCore;

namespace etkinlikuygulaması.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Admin> Adminler { get; set; }
        public DbSet<Etkinlik> Etkinlikler { get; set; }

        public DbSet<Basvuru> Basvurular { get; set; }
    }
    }
