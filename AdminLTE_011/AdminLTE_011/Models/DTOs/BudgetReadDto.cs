// Models/DTOs/BudgetReadDto.cs
using System;

public class BudgetReadDto
{
    public int Id { get; set; }
    public string? Nama { get; set; }
    public decimal TotalBudget { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Status { get; set; }

    // Properti ini untuk menampilkan nama kategori, bukan hanya ID-nya
    public string? KategoriNama { get; set; }
}