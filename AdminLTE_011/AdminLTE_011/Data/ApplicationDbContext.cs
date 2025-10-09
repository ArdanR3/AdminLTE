using AdminLTE_011.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminLTE_011.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet yang sudah ada
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Budget> Budget { get; set; }

        // TAMBAHKAN BARIS INI
        public DbSet<Transaction> Transaction { get; set; }
    }
}