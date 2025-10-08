using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminLTE_011.Models
{
    public class Budget
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori wajib dipilih.")]
        [Display(Name = "Kategori")]
        public int KategoriId { get; set; }
    

        [Required(ErrorMessage = "Nama wajib diisi.")]
        public string Nama { get; set; } = null!; // Alternatif: Beri nilai awal

        public string? Deskripsi { get; set; } // Tambah ?

        [Required(ErrorMessage = "Total Budget wajib diisi.")]
        [Display(Name = "Total Budget")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalBudget { get; set; }

        [Required(ErrorMessage = "Start Date wajib diisi.")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date wajib diisi.")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Ulangi?")]
        public bool IsRepeat { get; set; }

        [Required(ErrorMessage = "Status wajib dipilih.")]
        public string Status { get; set; } = null!; // Alternatif: Beri nilai awal
    }
}