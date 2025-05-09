using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica.Server.Models.Medicamentos
{
    public class Categoria
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string descripcionCategoria { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
       
        [ForeignKey("Estado")]
        public int estadoCategoria { get; set; }
        public Estado? EstadoFk { get; set; }
    }
}
