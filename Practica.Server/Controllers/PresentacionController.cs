using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica.Server.Models;
using Practica.Server.Models.Medicamentos;

namespace Practica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentacionController : ControllerBase
    {
        private readonly MedicamentosContext _context;
        public PresentacionController(MedicamentosContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        [Route("InsertarPresentacion")]
        public async Task<IActionResult> InsertarPresentacion(Presentacion presentacion)
        {
            await _context.Presentacion.AddAsync(presentacion);
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpGet]
        [Route("ListarPresentacion")]
        public async Task<List<Presentacion>> ListarPresentacion()
        {
            var presentacionLista = await _context.Presentacion
                .Include(p => p.EstadoFk)
                .ToListAsync();
            return presentacionLista;
        }
        [HttpGet]
        [Route("ConsultarPresentacion")]
        public async Task <Presentacion> ConsultarPresentacion(int id)
        {
            var presentacionConsultar = await _context.Presentacion
                .Include(p => p.EstadoFk)
                .FirstOrDefaultAsync(p => p.id == id);
            return presentacionConsultar;
        }
        [HttpPut]
        [Route("ActualizarPresentacion")]
        public async Task <IActionResult> ActualizarPresentacion(Presentacion presentacion)
        {
            var presentacionExistente = await _context.Presentacion.FirstOrDefaultAsync(p => p.id == presentacion.id);
            if (presentacionExistente == null)
            {
                return BadRequest();
            }
            presentacionExistente.nombre = presentacion.nombre;
            presentacionExistente.estadoPresentacion = presentacion.estadoPresentacion;
            _context.Presentacion.Update(presentacionExistente);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Route("EliminarPresentacion")]

        public async Task <IActionResult> EliminarPresentacion (int id)
        {
            var presentacionBorrada = await _context.Presentacion.FindAsync(id);
            if (presentacionBorrada ==null)
            {
                return BadRequest();
            }
            _context.Presentacion.Remove(presentacionBorrada);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
    }
