using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminLTE_011.Data;
using AdminLTE_011.Models;

namespace AdminLTE_011.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BudgetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Budgets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BudgetReadDto>>> GetBudget()
        {
            return await _context.Budget
                .Include(b => b.Kategori) // Ambil data kategori terkait
                .Select(b => new BudgetReadDto // Ubah (map) ke DTO
                {
                    Id = b.Id,
                    Nama = b.Nama,
                    TotalBudget = b.TotalBudget,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    Status = b.Status,
                    KategoriNama = b.Kategori.Nama
                }).ToListAsync();
        }

        // GET: api/Budgets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BudgetReadDto>> GetBudget(int id)
        {
            var budget = await _context.Budget.Include(b => b.Kategori).FirstOrDefaultAsync(b => b.Id == id);

            if (budget == null)
            {
                return NotFound();
            }

            var budgetReadDto = new BudgetReadDto
            {
                Id = budget.Id,
                Nama = budget.Nama,
                TotalBudget = budget.TotalBudget,
                StartDate = budget.StartDate,
                EndDate = budget.EndDate,
                Status = budget.Status,
                KategoriNama = budget.Kategori.Nama
            };

            return budgetReadDto;
        }

        // PUT: api/Budgets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBudget(int id, BudgetUpdateDto dto)
        {
            var budgetEntity = await _context.Budget.FindAsync(id);
            if (budgetEntity == null)
            {
                return NotFound();
            }

            // Map dari DTO ke Entity
            budgetEntity.Nama = dto.Nama;
            budgetEntity.Deskripsi = dto.Deskripsi;
            budgetEntity.KategoriId = dto.KategoriId;
            budgetEntity.TotalBudget = dto.TotalBudget;
            budgetEntity.StartDate = dto.StartDate;
            budgetEntity.EndDate = dto.EndDate;
            budgetEntity.IsRepeat = dto.IsRepeat;
            budgetEntity.Status = dto.Status;

            _context.Entry(budgetEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Budgets
        [HttpPost]
        public async Task<ActionResult<BudgetReadDto>> PostBudget(BudgetCreateDto dto)
        {
            var budgetEntity = new Budget
            {
                Nama = dto.Nama,
                Deskripsi = dto.Deskripsi,
                KategoriId = dto.KategoriId,
                TotalBudget = dto.TotalBudget,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsRepeat = dto.IsRepeat,
                Status = dto.Status
            };

            _context.Budget.Add(budgetEntity);
            await _context.SaveChangesAsync();

            // Dapatkan kembali kategori untuk nama
            await _context.Entry(budgetEntity).Reference(b => b.Kategori).LoadAsync();

            var budgetReadDto = new BudgetReadDto
            {
                Id = budgetEntity.Id,
                Nama = budgetEntity.Nama,
                TotalBudget = budgetEntity.TotalBudget,
                StartDate = budgetEntity.StartDate,
                EndDate = budgetEntity.EndDate,
                Status = budgetEntity.Status,
                KategoriNama = budgetEntity.Kategori.Nama
            };

            return CreatedAtAction("GetBudget", new { id = budgetReadDto.Id }, budgetReadDto);
        }

        // DELETE: api/Budgets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudget(int id)
        {
            var budget = await _context.Budget.FindAsync(id);
            if (budget == null)
            {
                return NotFound();
            }

            _context.Budget.Remove(budget);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}