// Data/ApplicationDbContext.cs
using AdminLTE_011.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminLTE_011.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Daftarkan semua model Anda di sini sebagai tabel
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Budget> Budget { get; set; }
    }
}