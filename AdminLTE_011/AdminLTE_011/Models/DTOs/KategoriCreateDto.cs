// Models/DTOs/KategoriCreateDto.cs
using System.ComponentModel.DataAnnotations;

public class KategoriCreateDto
{
    [Required]
    public string? Tipe { get; set; }

    [Required]
    public string? Nama { get; set; }

    public string? Deskripsi { get; set; }

    [Required]
    public string? Status { get; set; }
}