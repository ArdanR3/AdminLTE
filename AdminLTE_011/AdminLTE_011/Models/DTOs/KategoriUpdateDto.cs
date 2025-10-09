// Models/DTOs/KategoriUpdateDto.cs
using System.ComponentModel.DataAnnotations;

public class KategoriUpdateDto
{
    [Required]
    public string? Tipe { get; set; }

    [Required]
    public string? Nama { get; set; }

    public string? Deskripsi { get; set; }

    [Required]
    public string? Status { get; set; }
}