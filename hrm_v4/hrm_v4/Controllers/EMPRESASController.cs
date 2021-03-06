﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hrm_v4.Models;

namespace hrm_v4.Controllers
{
    public class EMPRESASController : Controller
    {
        private Entities db = new Entities();

        // GET: EMPRESAS
        public ActionResult Index()
        {
            return View(db.EMPRESAS.ToList());
        }

        // GET: EMPRESAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESAS eMPRESAS = db.EMPRESAS.Find(id);
            if (eMPRESAS == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESAS);
        }

        // GET: EMPRESAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EMPRESAS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EMPRESA,NOMBRE,RAZON_SOCIAL,CEDULA_JURIDICA,FECHA_FUNDACION,PAIS_ORIGEN,SEDE_CENTRAL,ESTADO")] EMPRESAS eMPRESAS)
        {
            if (ModelState.IsValid)
            {
                db.EMPRESAS.Add(eMPRESAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eMPRESAS);
        }

        // GET: EMPRESAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESAS eMPRESAS = db.EMPRESAS.Find(id);
            if (eMPRESAS == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESAS);
        }

        // POST: EMPRESAS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EMPRESA,NOMBRE,RAZON_SOCIAL,CEDULA_JURIDICA,FECHA_FUNDACION,PAIS_ORIGEN,SEDE_CENTRAL,ESTADO")] EMPRESAS eMPRESAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPRESAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMPRESAS);
        }

        // GET: EMPRESAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESAS eMPRESAS = db.EMPRESAS.Find(id);
            if (eMPRESAS == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESAS);
        }

        // POST: EMPRESAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPRESAS eMPRESAS = db.EMPRESAS.Find(id);
            db.EMPRESAS.Remove(eMPRESAS);
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
