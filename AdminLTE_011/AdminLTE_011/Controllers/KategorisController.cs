using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminLTE_011.Data;
using AdminLTE_011.Models;

namespace AdminLTE_011.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KategorisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Kategoris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KategoriReadDto>>> GetKategori()
        {
            var kategoriEntities = await _context.Kategori.ToListAsync();

            // Pemetaan dari Entity -> DTO Read
            var kategoriDtos = kategoriEntities.Select(k => new KategoriReadDto
            {
                Id = k.Id,
                Nama = k.Nama,
                Tipe = k.Tipe,
                Status = k.Status
            }).ToList();

            return Ok(kategoriDtos);
        }

        // GET: api/Kategoris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KategoriReadDto>> GetKategori(int id)
        {
            var kategoriEntity = await _context.Kategori.FindAsync(id);

            if (kategoriEntity == null)
            {
                return NotFound();
            }

            // Pemetaan dari Entity -> DTO Read
            var kategoriDto = new KategoriReadDto
            {
                Id = kategoriEntity.Id,
                Nama = kategoriEntity.Nama,
                Tipe = kategoriEntity.Tipe,
                Status = kategoriEntity.Status
            };

            return Ok(kategoriDto);
        }

        // PUT: api/Kategoris/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategori(int id, KategoriUpdateDto dto)
        {
            var kategoriEntity = await _context.Kategori.FindAsync(id);

            if (kategoriEntity == null)
            {
                return NotFound();
            }

            // Pemetaan dari DTO Update -> Entity
            kategoriEntity.Nama = dto.Nama;
            kategoriEntity.Tipe = dto.Tipe;
            kategoriEntity.Deskripsi = dto.Deskripsi;
            kategoriEntity.Status = dto.Status;

            _context.Entry(kategoriEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Kategoris
        [HttpPost]
        public async Task<ActionResult<KategoriReadDto>> PostKategori(KategoriCreateDto dto)
        {
            // Pemetaan dari DTO Create -> Entity
            var kategoriEntity = new Kategori
            {
                Nama = dto.Nama,
                Tipe = dto.Tipe,
                Deskripsi = dto.Deskripsi,
                Status = dto.Status
            };

            _context.Kategori.Add(kategoriEntity);
            await _context.SaveChangesAsync();

            // Pemetaan dari Entity yang baru dibuat -> DTO Read untuk respons
            var kategoriReadDto = new KategoriReadDto
            {
                Id = kategoriEntity.Id,
                Nama = kategoriEntity.Nama,
                Tipe = kategoriEntity.Tipe,
                Status = kategoriEntity.Status
            };

            return CreatedAtAction("GetKategori", new { id = kategoriReadDto.Id }, kategoriReadDto);
        }

        // DELETE: api/Kategoris/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKategori(int id)
        {
            var kategori = await _context.Kategori.FindAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }

            _context.Kategori.Remove(kategori);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}