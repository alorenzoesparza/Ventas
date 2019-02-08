using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ventas.Backend.Models;
using Ventas.Common.Models;

namespace Ventas.Backend.Helpers
{
    public class CombosHelper
    {
        private static LocalDataContext db = new LocalDataContext();

        public static List<Zone> LeerZonas()
        {
            // Ordenar el combobox por descripción de zonas
            var zonas = db.Zones.ToList();
            zonas.Add(new Zone
            {
                ZoneId = 0,
                Descripcion = "[Seleccionar zona...]"
            });

            return zonas.OrderBy(d => d.Descripcion).ToList();
        }

        public static List<Periodicity> LeerPeriodicidad()
        {
            // Ordenar el combobox por Periodicidad
            var periodicidad = db.Periodicities.ToList();
            periodicidad.Add(new Periodicity
            {
                PeriodicityId = 0,
                Descripcion = "[Seleccionar periodicidad...]"
            });

            return periodicidad.OrderBy(d => d.Descripcion).ToList();
        }
    }
}