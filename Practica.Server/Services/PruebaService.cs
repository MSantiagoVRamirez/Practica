using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Practica.Server.Models;
using Practica.Server.Models.Medicamentos;

namespace Practica.Server.Services
{
    public class PruebaService : IPruebaService
    {
        private readonly MedicamentosContext _context;
        public PruebaService(MedicamentosContext context)
        {
            _context = context;
        }
        public async Task <decimal> ListarMedicamentos()
        {
            var medicamentosLista = await _context.Medicamento.ToListAsync();

            decimal total = 0;
            foreach (var medicamento in medicamentosLista)
            {
                total += medicamento.valor;
            }
            return total;
        }

        public async Task<decimal?> sumaMedicamentos()
        {
            var medicamentos = await _context.Medicamento.Where(m => m.estado == true).ToListAsync();
            if (medicamentos == null || !medicamentos.Any())
            {
                return null;
            }
            var suma = medicamentos.Sum(m => m.valor);
            return suma;
        }
        public async Task <decimal> SumaEstados(int presentacionId)

        {
            var listaEstado = await _context.Medicamento.Where(m => m.estado == true && m.presentacionId == presentacionId).ToListAsync();
      
            decimal total = 0;
           
            foreach (var medicamento in listaEstado)
            {
                total += medicamento.valor;
            }
            return total;
        }
    }
}
