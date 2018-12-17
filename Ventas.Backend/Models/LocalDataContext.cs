namespace Ventas.Backend.Models
{
    using Ventas.Domain.Models;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<Ventas.Common.Models.Product> Products { get; set; }
    }
}