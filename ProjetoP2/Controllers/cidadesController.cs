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
    public class cidadesController : Controller
    {
        private BancoEntities db = new BancoEntities();

        // GET: cidades
        public ActionResult Index()
        {
            var cidade = db.cidade.Include(c => c.pais);
            return View(cidade.ToList());
        }

        // GET: cidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cidade cidade = db.cidade.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // GET: cidades/Create
        public ActionResult Create()
        {
            ViewBag.id_pais = new SelectList(db.pais, "id", "nome");
            return View();
        }

        // POST: cidades/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,estado,populacao,id_pais")] cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.cidade.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pais = new SelectList(db.pais, "id", "nome", cidade.id_pais);
            return View(cidade);
        }

        // GET: cidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cidade cidade = db.cidade.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pais = new SelectList(db.pais, "id", "nome", cidade.id_pais);
            return View(cidade);
        }

        // POST: cidades/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,estado,populacao,id_pais")] cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pais = new SelectList(db.pais, "id", "nome", cidade.id_pais);
            return View(cidade);
        }

        // GET: cidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cidade cidade = db.cidade.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // POST: cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cidade cidade = db.cidade.Find(id);
            db.cidade.Remove(cidade);
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
