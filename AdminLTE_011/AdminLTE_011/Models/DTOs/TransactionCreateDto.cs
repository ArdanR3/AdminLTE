using System;
using System.ComponentModel.DataAnnotations;

public class TransactionCreateDto
{
    [Required(ErrorMessage = "Deskripsi wajib diisi.")]
    [MaxLength(200)]
    public string Deskripsi { get; set; } = null!;

    [Required(ErrorMessage = "Jumlah wajib diisi.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Jumlah harus lebih besar dari 0.")]
    public decimal Jumlah { get; set; }

    [Required(ErrorMessage = "Tanggal wajib diisi.")]
    public DateTime Tanggal { get; set; }

    [Required(ErrorMessage = "Budget wajib dipilih.")]
    public int BudgetId { get; set; }
}