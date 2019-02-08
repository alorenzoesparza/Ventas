using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Common.Models
{
    public class Periodicity
    {
        [Key]
        public int PeriodicityId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(40, ErrorMessage = "El campo{0} debe tener como máximo {1} caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
