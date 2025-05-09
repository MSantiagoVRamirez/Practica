using System.ComponentModel.DataAnnotations;

namespace Practica.Server.Models.Medicamentos
{
    public class Estado
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string estado { get; set; }
    }
}
