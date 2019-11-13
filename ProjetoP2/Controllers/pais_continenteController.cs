using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoP2;

namespace ProjetoP2.Controllers
{
    public class pais_continenteController : Controller
    {
        private BancoEntities db = new BancoEntities();

        // GET: pais_continente
        public ActionResult Index()
        {
            var pais_continente = db.pais_continente.Include(p => p.continente).Include(p => p.pais);
            return View(pais_continente.ToList());
        }

        // GET: pais_continente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pais_continente pais_continente = db.pais_continente.Find(id);
            if (pais_continente == null)
            {
                return HttpNotFound();
            }
            return View(pais_continente);
        }

        // GET: pais_continente/Create
        public ActionResult Create()
        {
            ViewBag.id_continente = new SelectList(db.continente, "id", "nome");
            ViewBag.id_pais = new SelectList(db.pais, "id", "nome");
            return View();
        }

        // POST: pais_continente/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pais,id_continente,id")] pais_continente pais_continente)
        {
            if (ModelState.IsValid)
            {
                db.pais_continente.Add(pais_continente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_continente = new SelectList(db.continente, "id", "nome", pais_continente.id_continente);
            ViewBag.id_pais = new SelectList(db.pais, "id", "nome", pais_continente.id_pais);
            return View(pais_continente);
        }

        // GET: pais_continente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pais_continente pais_continente = db.pais_continente.Find(id);
            if (pais_continente == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_continente = new SelectList(db.continente, "id", "nome", pais_continente.id_continente);
            ViewBag.id_pais = new SelectList(db.pais, "id", "nome", pais_continente.id_pais);
            return View(pais_continente);
        }

        // POST: pais_continente/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pais,id_continente,id")] pais_continente pais_continente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pais_continente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_continente = new SelectList(db.continente, "id", "nome", pais_continente.id_continente);
            ViewBag.id_pais = new SelectList(db.pais, "id", "nome", pais_continente.id_pais);
            return View(pais_continente);
        }

        // GET: pais_continente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pais_continente pais_continente = db.pais_continente.Find(id);
            if (pais_continente == null)
            {
                return HttpNotFound();
            }
            return View(pais_continente);
        }

        // POST: pais_continente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pais_continente pais_continente = db.pais_continente.Find(id);
            db.pais_continente.Remove(pais_continente);
            db.SaveChanges();
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
