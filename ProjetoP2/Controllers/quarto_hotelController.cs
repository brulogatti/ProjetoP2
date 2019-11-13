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
    public class quarto_hotelController : Controller
    {
        private BancoEntities db = new BancoEntities();

        // GET: quarto_hotel
        public ActionResult Index()
        {
            var quarto_hotel = db.quarto_hotel.Include(q => q.hotel);
            return View(quarto_hotel.ToList());
        }

        // GET: quarto_hotel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quarto_hotel quarto_hotel = db.quarto_hotel.Find(id);
            if (quarto_hotel == null)
            {
                return HttpNotFound();
            }
            return View(quarto_hotel);
        }

        // GET: quarto_hotel/Create
        public ActionResult Create()
        {
            ViewBag.id_hotel = new SelectList(db.hotel, "id", "nome");
            return View();
        }

        // POST: quarto_hotel/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_hotel,tipo,preco,id")] quarto_hotel quarto_hotel)
        {
            if (ModelState.IsValid)
            {
                db.quarto_hotel.Add(quarto_hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_hotel = new SelectList(db.hotel, "id", "nome", quarto_hotel.id_hotel);
            return View(quarto_hotel);
        }

        // GET: quarto_hotel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quarto_hotel quarto_hotel = db.quarto_hotel.Find(id);
            if (quarto_hotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_hotel = new SelectList(db.hotel, "id", "nome", quarto_hotel.id_hotel);
            return View(quarto_hotel);
        }

        // POST: quarto_hotel/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_hotel,tipo,preco,id")] quarto_hotel quarto_hotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quarto_hotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_hotel = new SelectList(db.hotel, "id", "nome", quarto_hotel.id_hotel);
            return View(quarto_hotel);
        }

        // GET: quarto_hotel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quarto_hotel quarto_hotel = db.quarto_hotel.Find(id);
            if (quarto_hotel == null)
            {
                return HttpNotFound();
            }
            return View(quarto_hotel);
        }

        // POST: quarto_hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            quarto_hotel quarto_hotel = db.quarto_hotel.Find(id);
            db.quarto_hotel.Remove(quarto_hotel);
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
