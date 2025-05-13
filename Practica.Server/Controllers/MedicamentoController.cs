using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica.Server.Models;
using Practica.Server.Models.Medicamentos;

namespace Practica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private readonly MedicamentosContext _context;
        public MedicamentoController ( MedicamentosContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("InsertarMedicamentos")]
        public async Task <IActionResult> InsertarMedicamento(Medicamento medicamento)
        {
            await _context.Medicamento.AddAsync(medicamento);
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpGet]
        [Route("ListarMedicamentos")]
        public async Task <List<Medicamento>> ListarMedicamentos()
        {
            var medicamentoLista = await _context.Medicamento
                .Include(m => m.categoriaId)
                .Include(m => m.presentacionId)
                .ToListAsync();
                return medicamentoLista;

        }
        [HttpGet]
        [Route("ConsultarMedicamento")]
        public async Task <Medicamento> ConsultarMedicamento(int id)
        {
            var medicamentoConsultado = await _context.Medicamento
                .Include(m => m.categoriaId)
                .Include(m => m.presentacionId)
                .FirstOrDefaultAsync(m => m.id == id);
            return medicamentoConsultado;
        }


        [HttpPut]
        [Route("ActualizarMedicamento")]
        public async Task <IActionResult> ActualizarMedicamento(Medicamento medicamento)
        {
            var medicamentoExistente = await _context.Medicamento.FirstOrDefaultAsync(m => m.id == medicamento.id);
            if (medicamentoExistente ==null)
            {
                return BadRequest();
            }
            medicamentoExistente.nombre = medicamento.nombre;
            medicamentoExistente.descripcion = medicamento.descripcion;
            medicamentoExistente.presentacionId = medicamento.presentacionId;
            medicamentoExistente.categoriaId = medicamento.categoriaId;
            medicamentoExistente.precio = medicamento.precio;
            medicamentoExistente.stock = medicamento.stock;
            _context.Medicamento.Update(medicamentoExistente);
            _context.SaveChanges();
            return Ok();
            
        }


        [HttpDelete]
        [Route("EliminarMedicamento")]
        public async Task <IActionResult> EliminarMedicamento(int id)
        {
            var medicamentoBorrado = await _context.Medicamento.FindAsync(id);
            if (medicamentoBorrado ==null)
            {
                return BadRequest();
            }
            _context.Medicamento.Remove(medicamentoBorrado);
            await _context.SaveChangesAsync();
            return Ok();
        }





    }
}
