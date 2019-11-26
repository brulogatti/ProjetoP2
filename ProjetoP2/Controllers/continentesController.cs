﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using ProjetoP2;

namespace ProjetoP2.Controllers
{
    public class continentesController : Controller
    {
        private BancoEntities db = new BancoEntities();

        // GET: continentes
        public ActionResult Index()
        {
            return View(db.continente.ToList());
        }

        // GET: continentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            continente continente = db.continente.Find(id);
            if (continente == null)
            {
                return HttpNotFound();
            }
            return View(continente);
        }

        // GET: continentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: continentes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,populacao,area")] continente continente)
        {
            if (ModelState.IsValid)
            {
                db.continente.Add(continente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(continente);
        }

        // GET: continentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            continente continente = db.continente.Find(id);
            if (continente == null)
            {
                return HttpNotFound();
            }
            return View(continente);
        }

        // POST: continentes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,populacao,area")] continente continente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(continente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(continente);
        }

        // GET: continentes/Delete/5
        public ActionResult Delete(int? id)
        {
            string message = "Deseja verificar se existem países atrelados a esse continente?";
            string caption = "Atenção!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);

            if (result == DialogResult.Yes)
            {

                return Redirect("/pais/Index");

            }
            else
            { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            continente continente = db.continente.Find(id);
            if (continente == null)
            {
                return HttpNotFound();
            }
            return View(continente);
            }
        }

        // POST: continentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            continente continente = db.continente.Find(id);
            db.continente.Remove(continente);
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
