using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Ventas.API.Models;
using Ventas.Common.Models;

namespace Ventas.API.Controllers
{
    public class ZonesController : ApiController
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: api/Zones
        public IQueryable<Zone> GetZones()
        {
            return db.Zones;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZoneExists(int id)
        {
            return db.Zones.Count(e => e.ZoneId == id) > 0;
        }
    }
}