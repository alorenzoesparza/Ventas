﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ventas.Backend.Helpers;
using Ventas.Backend.Models;
using Ventas.Common.Models;

namespace Ventas.Backend.Controllers
{
    public class ClientsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Clients
        public async Task<ActionResult> Index()
        {
            var clients = await db.Clients.OrderBy(c => c.ZoneId + c.Apellidos).ToListAsync();
            return View(clients);
        }

        // GET: Clients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.ZoneId = new SelectList(CombosHelper.LeerZonas(), "ZoneId", "Descripcion");
            ViewBag.PeriodicityId = new SelectList(CombosHelper.LeerPeriodicidad(), "PeriodicityId", "Descripcion");

            return View();
        }

        // POST: Clients/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ClientId,Nombre,Apellidos,PeriodicityId,ZoneId,EsActivo")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ZoneId = new SelectList(CombosHelper.LeerZonas(), "ZoneId", "Descripcion", client.ClientId);
            ViewBag.PeriodicityId = new SelectList(CombosHelper.LeerPeriodicidad(), "PeriodicityId", "Descripcion", client.PeriodicityId);

            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }

            ViewBag.ZoneId = new SelectList(CombosHelper.LeerZonas(), "ZoneId", "Descripcion", client.ClientId);
            ViewBag.PeriodicityId = new SelectList(CombosHelper.LeerPeriodicidad(), "PeriodicityId", "Descripcion", client.PeriodicityId);

            return View(client);
        }

        // POST: Clients/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ClientId,Nombre,Apellidos,PeriodicityId,ZoneId,EsActivo")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ZoneId = new SelectList(CombosHelper.LeerZonas(), "ZoneId", "Descripcion", client.ClientId);
            ViewBag.PeriodicityId = new SelectList(CombosHelper.LeerPeriodicidad(), "PeriodicityId", "Descripcion", client.PeriodicityId);

            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Client client = await db.Clients.FindAsync(id);
            db.Clients.Remove(client);
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
