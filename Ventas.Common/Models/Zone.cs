namespace Ventas.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Zone
    {
        [Key]
        public int ZoneId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(40, ErrorMessage = "El campo{0} debe tener como máximo {1} caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
