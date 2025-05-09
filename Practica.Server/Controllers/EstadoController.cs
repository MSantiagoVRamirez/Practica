using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica.Server.Models;
using Practica.Server.Models.Medicamentos;

namespace Practica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly MedicamentosContext _context;
        public EstadoController(MedicamentosContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("InsertarEstado")]
        public async Task<IActionResult> InsertarEstado(Estado estado)
        {
            await _context.Estado.AddAsync(estado);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpGet]
        [Route("ListarEstado")]
        public async Task<List<Estado>> ListarEstado()
        {
            var estados = await _context.Estado.ToListAsync();
            return estados;
        }
        [HttpGet]
        [Route("ConsultarEstado")]
        public async Task<Estado> ConsultarEstado(int id)
        {
            var estado = await _context.Estado.FirstOrDefaultAsync(e => e.id == id);
            return estado;
        }
        [HttpPut]
        [Route("ActualizarEstado")]
        public async Task<IActionResult> ActualizarEstado(Estado estado)
        {
            var estadoExistente = await _context.Estado.FindAsync(estado.id);
            if (estadoExistente == null)
            {
                return NotFound();
            }
            estadoExistente.estado = estado.estado;
            _context.Estado.Update(estadoExistente);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        [Route("EliminarEstado")]
        public async Task<IActionResult> EliminarEstado(int id)
        {
            var estadoBorrado = await _context.Estado.FindAsync(id);
            if (estadoBorrado == null)
            {
                return NotFound();
            }
            _context.Estado.Remove(estadoBorrado);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
 }
