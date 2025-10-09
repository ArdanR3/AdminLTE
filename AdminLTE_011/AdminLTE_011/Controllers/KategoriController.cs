using AdminLTE_011.Data;
using AdminLTE_011.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Authorize]
public class KategoriController : Controller
{
    private readonly ApplicationDbContext _context;

    public KategoriController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Kategori
    public async Task<IActionResult> Index()
    {
        return View(await _context.Kategori.ToListAsync());
    }

    // GET: /Kategori/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Kategori/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Kategori kategori)
    {
        if (ModelState.IsValid)
        {
            _context.Add(kategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(kategori);
    }

    // GET: /Kategori/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var kategori = await _context.Kategori.FindAsync(id);
        if (kategori == null)
        {
            return NotFound();
        }
        return View(kategori);
    }

    // POST: /Kategori/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Kategori kategori)
    {
        if (id != kategori.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(kategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(kategori);
    }

    // GET: /Kategori/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var kategori = await _context.Kategori.FirstOrDefaultAsync(m => m.Id == id);
        if (kategori == null)
        {
            return NotFound();
        }
        return View(kategori);
    }

    // POST: /Kategori/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var kategori = await _context.Kategori.FindAsync(id);
        if (kategori != null)
        {
            _context.Kategori.Remove(kategori);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}