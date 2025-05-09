using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica.Server.Models.Medicamentos
{
    public class Medicamento
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
       
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]

        public string descripcion { get; set; }
        [ForeignKey("Presentacion")]
        public int presentacionId { get; set; }
        public Presentacion? PresentacionfK { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [ForeignKey("Categoria")]
        public int categoriaId { get; set; }
        public Categoria? CategoriaFk { get; set; }
       
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal precio { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int stock { get; set; }
    }
}
