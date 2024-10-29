/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Api.Context;
using RegistroTecnicos.Api.DTO;
using RegistroTecnicos.Api.Models;

namespace RegistroTecnicos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajosController(IDbContextFactory<TecnicosContext> DbFactory) : ControllerBase
    {

        // GET: api/Trabajos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trabajos>>> GetTrabajos()
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Trabajos.ToListAsync();
        }

        // GET: api/Trabajos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trabajos>> GetTrabajos(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var trabajos = await context.Trabajos.FindAsync(id);

            if (trabajos == null)
            {
                return NotFound();
            }

            return trabajos;
        }

        // PUT: api/Trabajos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrabajos(int id, Trabajos trabajos)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            if (id != trabajos.TrabajoId)
            {
                return BadRequest();
            }

            context.Entry(trabajos).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var existe = await TrabajosExists(id);
                if (!existe)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Trabajos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trabajos>> PostTrabajos(TrabajosDto trabajoDto)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var trabajo = new Trabajos
            {
                Fecha = DateTime.Now,
                Descripcion = trabajoDto.Descripcion,
                Monto = trabajoDto.Monto,
                PrioridadId = trabajoDto.PrioridadId
            };
            context.Trabajos.Add(trabajo);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetTrabajos", new { id = trabajo.TrabajoId }, trabajoDto);
        }

        // DELETE: api/Trabajos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrabajos(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            var trabajos = await context.Trabajos.FindAsync(id);
            if (trabajos == null)
            {
                return NotFound();
            }

            context.Trabajos.Remove(trabajos);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> TrabajosExists(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Trabajos.AnyAsync(e => e.TrabajoId == id);
        }
    }
}
*/