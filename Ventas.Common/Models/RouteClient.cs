namespace Ventas.Common.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RouteClient
    {
        [Key]
        public int RouteClientId { get; set; }

        public int RutaId { get; set; }

        public int ClientId { get; set; }

        // Relación entre clientes y rutas
        // 
        [JsonIgnore]
        public virtual ICollection<Route> Rutas { get; set; }

        [JsonIgnore]
        public virtual ICollection<Client> Clientes { get; set; }
        // **************************************************************************************
    }
}
