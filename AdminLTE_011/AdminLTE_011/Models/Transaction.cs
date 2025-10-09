using AdminLTE_011.Models;

public class Transaction
{
    public int Id { get; set; }
    public string Deskripsi { get; set; }
    public decimal Jumlah { get; set; }
    public DateTime Tanggal { get; set; }
    // Foreign Key ke Budget
    public int BudgetId { get; set; }
    public Budget? Budget { get; set; }
}