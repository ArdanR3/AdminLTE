// Models/Kategori.cs
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdminLTE_011.Models
{
    public class Kategori
    {
        public int Id { get; set; }

        [Required]
        public string? Tipe { get; set; } // "Income" atau "Expense"

        [Required]
        public string? Nama { get; set; }

        public string? Deskripsi { get; set; }

        [Required]
        public string? Status { get; set; } // "Active" atau "Not Active"
    }
}