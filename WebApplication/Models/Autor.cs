using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoEF.Models
{
    public class Autor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 4, ErrorMessage = "El campo {0} no debe tener más de {1} carácteres")]
        public string Name { get; set; }
        [Range(18, 100, ErrorMessage = "El rango debe ser entre {1} y {2}")]
        [NotMapped]
        public int Edad { get; set; }
        [CreditCard]
        [NotMapped]
        public string TarjetaDeCredito { get; set; }
        [Url]
        [NotMapped]
        public string Url { get; set; }
    }
}
