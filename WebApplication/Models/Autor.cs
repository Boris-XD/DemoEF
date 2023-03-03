using DemoEF.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoEF.Models
{
    public class Autor : IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 4, ErrorMessage = "El campo {0} no debe tener más de {1} carácteres")]
        [FirstChartUpper]
        public string Name { get; set; }

        [NotMapped]
        public string LastName { get; set; }

        [NotMapped]
        public int Mayor { get; set; }

        [NotMapped]
        public int Menor { get; set; }

        //[Range(18, 100, ErrorMessage = "El rango debe ser entre {1} y {2}")]
        //[NotMapped]
        //public int Edad { get; set; }
        //[CreditCard]
        //[NotMapped]
        //public string TarjetaDeCredito { get; set; }
        //[Url]
        //[NotMapped]
        //public string Url { get; set; }

        /* Añade validaciones a los atributos de IValidatableObject */
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(LastName))
            {
                var firstLetter = LastName[0].ToString();
                if (firstLetter != firstLetter.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe ser mayucula",
                        new string[] { nameof(LastName) });
                }
            }

            if(Menor > Mayor)
            {
                yield return new ValidationResult("El valor de Menor no debe ser Mayor al campo Mayor",
                    new string[] { nameof(Menor) });
            }
        }
    }
}
