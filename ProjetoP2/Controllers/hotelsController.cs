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
    public class hotelsController : Controller
    {
        private BancoEntities db = new BancoEntities();

        // GET: hotels
        public ActionResult Index()
        {
            var hotel = db.hotel.Include(h => h.cidade);
            return View(hotel.ToList());
        }

        // GET: hotels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hotel hotel = db.hotel.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // GET: hotels/Create
        public ActionResult Create()
        {
            ViewBag.id_cidade = new SelectList(db.cidade, "id", "nome");
            return View();
        }

        // POST: hotels/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,tipo,id_cidade")] hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.hotel.Add(hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cidade = new SelectList(db.cidade, "id", "nome", hotel.id_cidade);
            return View(hotel);
        }

        // GET: hotels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hotel hotel = db.hotel.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cidade = new SelectList(db.cidade, "id", "nome", hotel.id_cidade);
            return View(hotel);
        }

        // POST: hotels/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,tipo,id_cidade")] hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cidade = new SelectList(db.cidade, "id", "nome", hotel.id_cidade);
            return View(hotel);
        }

        // GET: hotels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hotel hotel = db.hotel.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hotel hotel = db.hotel.Find(id);
            db.hotel.Remove(hotel);
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
