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
    [Authorize(Roles = "admin")]
    public class AsignacionDocentesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AsignacionDocentes
        public ActionResult Index()
        {
            var asignacionDocentes = db.AsignacionDocentes.Include(a => a.Curso).Include(a => a.GrupoClase).Include(a => a.User);
            return View(asignacionDocentes.ToList());
        }

        // GET: AsignacionDocentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionDocente asignacionDocente = db.AsignacionDocentes.Find(id);
            if (asignacionDocente == null)
            {
                return HttpNotFound();
            }
            return View(asignacionDocente);
        }

        // GET: AsignacionDocentes/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Ano");
            ViewBag.GrupoClaseId = new SelectList(db.GrupoClases, "GrupoClaseId", "Nombre");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: AsignacionDocentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsignacionDocenteId,UserId,GrupoClaseId,CursoId")] AsignacionDocente asignacionDocente)
        {
            if (ModelState.IsValid)
            {
                db.AsignacionDocentes.Add(asignacionDocente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Ano", asignacionDocente.CursoId);
            ViewBag.GrupoClaseId = new SelectList(db.GrupoClases, "GrupoClaseId", "Nombre", asignacionDocente.GrupoClaseId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", asignacionDocente.UserId);
            return View(asignacionDocente);
        }

        // GET: AsignacionDocentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionDocente asignacionDocente = db.AsignacionDocentes.Find(id);
            if (asignacionDocente == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Ano", asignacionDocente.CursoId);
            ViewBag.GrupoClaseId = new SelectList(db.GrupoClases, "GrupoClaseId", "Nombre", asignacionDocente.GrupoClaseId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", asignacionDocente.UserId);
            return View(asignacionDocente);
        }

        // POST: AsignacionDocentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AsignacionDocenteId,UserId,GrupoClaseId,CursoId")] AsignacionDocente asignacionDocente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacionDocente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Ano", asignacionDocente.CursoId);
            ViewBag.GrupoClaseId = new SelectList(db.GrupoClases, "GrupoClaseId", "Nombre", asignacionDocente.GrupoClaseId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", asignacionDocente.UserId);
            return View(asignacionDocente);
        }

        // GET: AsignacionDocentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionDocente asignacionDocente = db.AsignacionDocentes.Find(id);
            if (asignacionDocente == null)
            {
                return HttpNotFound();
            }
            return View(asignacionDocente);
        }

        // POST: AsignacionDocentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignacionDocente asignacionDocente = db.AsignacionDocentes.Find(id);
            db.AsignacionDocentes.Remove(asignacionDocente);
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
