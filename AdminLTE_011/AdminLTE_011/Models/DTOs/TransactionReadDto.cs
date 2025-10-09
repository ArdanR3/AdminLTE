using System;

public class TransactionReadDto
{
    public int Id { get; set; }
    public string? Deskripsi { get; set; }
    public decimal Jumlah { get; set; }
    public DateTime Tanggal { get; set; }

    // Properti ini untuk menampilkan nama budget, bukan hanya ID-nya
    public string? BudgetNama { get; set; }
}