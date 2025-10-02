// Models/Budget.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminLTE_011.Models
{
    public class Budget
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Kategori")]
        public int KategoriId { get; set; }

        [Required]
        public string? Nama { get; set; }

        public string? Deskripsi { get; set; }

        [Required]
        [Display(Name = "Total Budget")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalBudget { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Is Repeat?")]
        public bool IsRepeat { get; set; }

        [Required]
        public string? Status { get; set; }
    }
}