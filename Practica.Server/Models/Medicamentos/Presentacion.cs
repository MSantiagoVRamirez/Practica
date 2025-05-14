using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica.Server.Models.Medicamentos
{
    public class Presentacion
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
       
        [ForeignKey("Estado")]
        public int estadoPresentacion { get; set; }
        public Estado? EstadoFk { get; set; }

        //Valor calculado
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal valorTotal { get; set; }

    }
}
