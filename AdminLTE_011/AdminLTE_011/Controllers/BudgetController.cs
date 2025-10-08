using AdminLTE_011.Data;
using AdminLTE_011.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Authorize]
public class BudgetController : Controller
{
    private readonly ApplicationDbContext _context;

    public BudgetController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var budgets = _context.Budget.Include(b => b.Kategori);
        return View(await budgets.ToListAsync());
    }

    public IActionResult Create()
    {
        ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Nama");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Budget budget)
    {
        if (ModelState.IsValid)
        {
            _context.Add(budget);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Nama", budget.KategoriId);
        return View(budget);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var budget = await _context.Budget.FindAsync(id);
        if (budget == null) return NotFound();
        ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Nama", budget.KategoriId);
        return View(budget);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Budget budget)
    {
        if (id != budget.Id) return NotFound();
        if (ModelState.IsValid)
        {
            _context.Update(budget);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Nama", budget.KategoriId);
        return View(budget);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var budget = await _context.Budget
            .Include(b => b.Kategori)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (budget == null) return NotFound();
        return View(budget);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var budget = await _context.Budget.FindAsync(id);
        if (budget != null)
        {
            _context.Budget.Remove(budget);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}