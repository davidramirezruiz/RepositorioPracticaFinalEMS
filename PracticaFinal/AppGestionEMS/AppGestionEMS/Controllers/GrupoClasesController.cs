﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppGestionEMS.Models;

namespace AppGestionEMS.Controllers
{
    [Authorize(Roles = " profesor, admin")]
    public class GrupoClasesController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GrupoClases
        public ActionResult Index()
        {
            return View(db.GrupoClases.ToList());
        }

        // GET: GrupoClases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoClase grupoClase = db.GrupoClases.Find(id);
            if (grupoClase == null)
            {
                return HttpNotFound();
            }
            return View(grupoClase);
        }

        // GET: GrupoClases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupoClases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrupoClaseId,Nombre,Plazas")] GrupoClase grupoClase)
        {
            if (ModelState.IsValid)
            {
                db.GrupoClases.Add(grupoClase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupoClase);
        }

        // GET: GrupoClases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoClase grupoClase = db.GrupoClases.Find(id);
            if (grupoClase == null)
            {
                return HttpNotFound();
            }
            return View(grupoClase);
        }

        // POST: GrupoClases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GrupoClaseId,Nombre,Plazas")] GrupoClase grupoClase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoClase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupoClase);
        }

        // GET: GrupoClases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoClase grupoClase = db.GrupoClases.Find(id);
            if (grupoClase == null)
            {
                return HttpNotFound();
            }
            return View(grupoClase);
        }

        // POST: GrupoClases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrupoClase grupoClase = db.GrupoClases.Find(id);
            db.GrupoClases.Remove(grupoClase);
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
