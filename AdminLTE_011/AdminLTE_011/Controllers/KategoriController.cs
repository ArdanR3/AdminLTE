using AdminLTE_011.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize] // Melindungi semua action di controller ini, hanya bisa diakses setelah login
public class KategoriController : Controller
{
    // --- DATA SEMENTARA ---
    // Di aplikasi nyata, bagian ini akan diganti dengan koneksi ke database.
    private static List<Kategori> _kategoriList = new List<Kategori>
    {
        new Kategori { Id = 1, Nama = "Gaji", Tipe = "Income", Deskripsi = "Pemasukan dari gaji bulanan", Status = "Active" },
        new Kategori { Id = 2, Nama = "Transportasi", Tipe = "Expense", Deskripsi = "Pengeluaran untuk transportasi", Status = "Active" },
        new Kategori { Id = 3, Nama = "Makanan & Minuman", Tipe = "Expense", Deskripsi = "Pengeluaran untuk konsumsi harian", Status = "Active" }
    };

    // GET: /Kategori
    // Menampilkan daftar semua kategori
    public IActionResult Index()
    {
        return View(_kategoriList.OrderBy(k => k.Id).ToList());
    }

    // GET: /Kategori/Create
    // Menampilkan halaman form untuk menambah data baru
    public IActionResult Create()
    {
        // Pastikan view ini memiliki baris Layout = "_AdminLayout.cshtml"
        return View();
    }

    // POST: /Kategori/Create
    // Memproses data yang dikirim dari form tambah data
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Kategori kategori)
    {
        if (ModelState.IsValid)
        {
            // Buat ID baru secara otomatis
            kategori.Id = _kategoriList.Any() ? _kategoriList.Max(k => k.Id) + 1 : 1;
            _kategoriList.Add(kategori);
            return RedirectToAction(nameof(Index));
        }
        return View(kategori);
    }

    // GET: /Kategori/Edit/5
    // Menampilkan halaman form untuk mengubah data berdasarkan ID
    public IActionResult Edit(int id)
    {
        var kategori = _kategoriList.FirstOrDefault(k => k.Id == id);
        if (kategori == null)
        {
            return NotFound();
        }
        // Pastikan view ini memiliki baris Layout = "_AdminLayout.cshtml"
        return View(kategori);
    }

    // POST: /Kategori/Edit/5
    // Memproses data yang dikirim dari form ubah data
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Kategori kategori)
    {
        if (id != kategori.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var existingKategori = _kategoriList.FirstOrDefault(k => k.Id == id);
            if (existingKategori != null)
            {
                existingKategori.Tipe = kategori.Tipe;
                existingKategori.Nama = kategori.Nama;
                existingKategori.Deskripsi = kategori.Deskripsi;
                existingKategori.Status = kategori.Status;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(kategori);
    }

    // GET: /Kategori/Delete/5
    // Menampilkan halaman konfirmasi sebelum menghapus data
    public IActionResult Delete(int id)
    {
        var kategori = _kategoriList.FirstOrDefault(k => k.Id == id);
        if (kategori == null)
        {
            return NotFound();
        }
        // Pastikan view ini memiliki baris Layout = "_AdminLayout.cshtml"
        return View(kategori);
    }

    // POST: /Kategori/Delete/5
    // Memproses penghapusan data setelah dikonfirmasi
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var kategori = _kategoriList.FirstOrDefault(k => k.Id == id);
        if (kategori != null)
        {
            _kategoriList.Remove(kategori);
        }

        return RedirectToAction(nameof(Index));
    }
}