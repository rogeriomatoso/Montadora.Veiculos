using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Montadoras.Veiculos.Dados.Entity.Context;
using Montadoras.Veiculos.Dominio;
using Montadoras.Veiculos.Web.ViewModels.Montadora;

namespace Montadoras.Veiculos.Web.Controllers
{
    public class MontadorasController : Controller
    {
        private MontadoraDbContext db = new MontadoraDbContext();

        // GET: Montadoras
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Montadora>,
                        List<MontadoraIndexViewModel>>
                        (db.Montadoras.ToList()));
        }

        // GET: Montadoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Montadora montadora = db.Montadoras.Find(id);
            if (montadora == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Montadora, MontadoraIndexViewModel>(montadora));
        }

        // GET: Montadoras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Montadoras/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Nacionalidade,MercadoPaises")] MontadoraViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Montadora montadora = Mapper.Map<MontadoraViewModel, Montadora>(viewModel);
                db.Montadoras.Add(montadora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Montadoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Montadora montadora = db.Montadoras.Find(id);
            if (montadora == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Montadora, MontadoraViewModel>(montadora));
        }

        // POST: Montadoras/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Nacionalidade,MercadoPaises")] MontadoraViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Montadora montadora = Mapper.Map<MontadoraViewModel, Montadora>(viewModel);
                db.Entry(montadora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Montadoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Montadora montadora = db.Montadoras.Find(id);
            if (montadora == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Montadora, MontadoraIndexViewModel>(montadora));
        }

        // POST: Montadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Montadora montadora = db.Montadoras.Find(id);
            db.Montadoras.Remove(montadora);
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
