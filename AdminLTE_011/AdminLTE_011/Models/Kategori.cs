using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdminLTE_011.Models
{
    public class Kategori
    {
        public int Id { get; set; }

        [Required]
        public string Tipe { get; set; } = null!; // Alternatif: Beri nilai awal

        [Required]
        public string Nama { get; set; } = null!; // Alternatif: Beri nilai awal

        public string? Deskripsi { get; set; } // Tambah ?

        [Required]
        public string Status { get; set; } = null!; // Alternatif: Beri nilai awal
    }
}