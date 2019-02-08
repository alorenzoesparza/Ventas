using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ventas.Backend.Models;
using Ventas.Common.Models;

namespace Ventas.Backend.Controllers
{
    public class PeriodicitiesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Periodicities
        public async Task<ActionResult> Index()
        {
            return View(await db.Periodicities.ToListAsync());
        }

        // GET: Periodicities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodicity periodicity = await db.Periodicities.FindAsync(id);
            if (periodicity == null)
            {
                return HttpNotFound();
            }
            return View(periodicity);
        }

        // GET: Periodicities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Periodicities/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PeriodicityId,Descripcion")] Periodicity periodicity)
        {
            if (ModelState.IsValid)
            {
                db.Periodicities.Add(periodicity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(periodicity);
        }

        // GET: Periodicities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodicity periodicity = await db.Periodicities.FindAsync(id);
            if (periodicity == null)
            {
                return HttpNotFound();
            }
            return View(periodicity);
        }

        // POST: Periodicities/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PeriodicityId,Descripcion")] Periodicity periodicity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodicity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(periodicity);
        }

        // GET: Periodicities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodicity periodicity = await db.Periodicities.FindAsync(id);
            if (periodicity == null)
            {
                return HttpNotFound();
            }
            return View(periodicity);
        }

        // POST: Periodicities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Periodicity periodicity = await db.Periodicities.FindAsync(id);
            db.Periodicities.Remove(periodicity);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
