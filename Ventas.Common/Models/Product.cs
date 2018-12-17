namespace Ventas.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(80, ErrorMessage = "El campo{0} debe tener como máximo {1} caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        //[Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Precio { get; set; }

        [Display(Name = "Está activo")]
        public bool EsActivo { get; set; }

        //[Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Alta")]
        public DateTime? FechaAlta { get; set; }
    }
}
