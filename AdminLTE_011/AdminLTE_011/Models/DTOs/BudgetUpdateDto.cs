// Models/DTOs/BudgetUpdateDto.cs
using System;
using System.ComponentModel.DataAnnotations;

public class BudgetUpdateDto
{
    [Required]
    public int KategoriId { get; set; }

    [Required]
    public string Nama { get; set; } = null!;

    public string? Deskripsi { get; set; }

    [Required]
    public decimal TotalBudget { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    public bool IsRepeat { get; set; }

    [Required]
    public string Status { get; set; } = null!;
}