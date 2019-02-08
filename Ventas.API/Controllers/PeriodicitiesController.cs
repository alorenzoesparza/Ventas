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
    public class PeriodicitiesController : ApiController
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: api/Periodicities
        public IQueryable<Periodicity> GetPeriodicities()
        {
            return db.Periodicities;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeriodicityExists(int id)
        {
            return db.Periodicities.Count(e => e.PeriodicityId == id) > 0;
        }
    }
}