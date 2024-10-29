using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tecnicos.Abstractions;
using Tecnicos.Data.Models;
using Tecnicos.Domain.DTO;

namespace RegistroTecnicos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadesController(IPrioridadesService prioridadesService) : ControllerBase
    {

        // GET: api/Prioridades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrioridadesDto>>> GetPrioridades()
        {
            return await prioridadesService.Listar(p => true);
        }

        // GET: api/Prioridades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrioridadesDto>> GetPrioridades(int id)
        {
            return await prioridadesService.Buscar(id);
        }

        // PUT: api/Prioridades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrioridades(int id, PrioridadesDto prioridadDto)
        {

            if (id != prioridadDto.PrioridadId)
            {
                return BadRequest();
            }
            await prioridadesService.Guardar(prioridadDto);
            return NoContent();
        }

        // POST: api/Prioridades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prioridades>> PostPrioridades(PrioridadesDto prioridadDto)
        { 
            await prioridadesService.Guardar(prioridadDto);

            return CreatedAtAction("GetPrioridades", new { id = prioridadDto.PrioridadId }, prioridadDto);
        }

        // DELETE: api/Prioridades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrioridades(int id)
        {
            await prioridadesService.Eliminar(id);
            return NoContent();
        }
    }
}
