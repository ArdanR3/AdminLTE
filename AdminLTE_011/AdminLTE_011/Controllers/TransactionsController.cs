using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminLTE_011.Data;
using AdminLTE_011.Models;

namespace AdminLTE_011.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionReadDto>>> GetTransaction()
        {
            return await _context.Transaction
                .Include(t => t.Budget) // Ambil data budget terkait
                .Select(t => new TransactionReadDto // Ubah (map) ke DTO
                {
                    Id = t.Id,
                    Deskripsi = t.Deskripsi,
                    Jumlah = t.Jumlah,
                    Tanggal = t.Tanggal,
                    BudgetNama = t.Budget.Nama
                }).ToListAsync();
        }

        // POST: api/Transactions
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(TransactionCreateDto dto)
        {
            var budget = await _context.Budget.FindAsync(dto.BudgetId);
            if (budget == null)
            {
                return BadRequest("BudgetId tidak valid.");
            }

            var transactionEntity = new Transaction
            {
                Deskripsi = dto.Deskripsi,
                Jumlah = dto.Jumlah,
                Tanggal = dto.Tanggal,
                BudgetId = dto.BudgetId
            };

            _context.Transaction.Add(transactionEntity);
            await _context.SaveChangesAsync();

            return Ok("Transaksi berhasil dibuat.");
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}