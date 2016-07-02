using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using shanuMVCUserRoles.Models;

namespace shanuMVCUserRoles.Controllers
{
    [Authorize]
    public class BienesModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BienesModels
        public ActionResult Index()
        {
            return View(db.BienesModels.ToList());
        }

        // GET: BienesModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BienesModel bienesModel = db.BienesModels.Find(id);
            if (bienesModel == null)
            {
                return HttpNotFound();
            }
            return View(bienesModel);
        }

        // GET: BienesModels/Create
        public ActionResult Create()
        {
            BienesViewModel viewModel = new BienesViewModel();
            return View(viewModel);
        }

        // POST: BienesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BienesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                BienesModel model = new BienesModel();
                model.Id = Guid.NewGuid();
                model.Descripcion = viewModel.Descripcion;
                model.NombrePropiedad = viewModel.NombrePropiedad;
                model.Precio = viewModel.Precio;
                model.Telefono = viewModel.Telefono;
                model.Ubicacion = viewModel.Ubicacion;
                model.UserId = User.Identity.GetUserId();
                db.BienesModels.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: BienesModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BienesModel bienesModel = db.BienesModels.Find(id);
            if (bienesModel == null)
            {
                return HttpNotFound();
            }
            return View(bienesModel);
        }

        // POST: BienesModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Telefono,Imagen,NombrePropiedad,Descripcion,Ubicacion,Precio")] BienesModel bienesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bienesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bienesModel);
        }

        // GET: BienesModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BienesModel bienesModel = db.BienesModels.Find(id);
            if (bienesModel == null)
            {
                return HttpNotFound();
            }
            return View(bienesModel);
        }

        // POST: BienesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            BienesModel bienesModel = db.BienesModels.Find(id);
            db.BienesModels.Remove(bienesModel);
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
