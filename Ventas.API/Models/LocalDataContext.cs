﻿namespace Ventas.API.Models
{
    using Ventas.Domain.Models;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<Ventas.Common.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Ventas.Common.Models.Client> Clients { get; set; }
    }
}