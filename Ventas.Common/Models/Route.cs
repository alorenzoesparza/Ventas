namespace Ventas.Common.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class Route
    {
        [Key]
        public int RutaId { get; set; }

        [Required]
        [StringLength(60)]
        public string Descripcion { get; set; }

        // **************************************************************************************
        // Relacionar tablas
        // Relación entre rutas y clientes
        // Una Ruta puede tener varios clientes
        //[JsonIgnore]
        //public virtual ICollection<Client> Clientes { get; set; }

        // Definir relación entre rutas y clientes
        // Un Cliente puede tener varias Rutas
        [JsonIgnore]
        public virtual RouteClient RouteClients { get; set; }

        // **************************************************************************************
    }
}
