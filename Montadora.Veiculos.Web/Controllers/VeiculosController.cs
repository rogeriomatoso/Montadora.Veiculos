using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Montadoras.Veiculos.Dados.Entity.Context;
using Montadoras.Veiculos.Dominio;

namespace Montadoras.Veiculos.Web.Controllers
{
    public class VeiculosController : Controller
    {
        private MontadoraDbContext db = new MontadoraDbContext();

        // GET: Veiculos
        public ActionResult Index()
        {
            var veiculos = db.Veiculos.Include(v => v.Montadora);
            return View(veiculos.ToList());
        }

        // GET: Veiculos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // GET: Veiculos/Create
        public ActionResult Create()
        {
            ViewBag.IdMontadora = new SelectList(db.Montadoras, "Id", "Nome");
            return View();
        }

        // POST: Veiculos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVeiculo,Modelo,Ano,IdMontadora")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Veiculos.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMontadora = new SelectList(db.Montadoras, "Id", "Nome", veiculo.IdMontadora);
            return View(veiculo);
        }

        // GET: Veiculos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMontadora = new SelectList(db.Montadoras, "Id", "Nome", veiculo.IdMontadora);
            return View(veiculo);
        }

        // POST: Veiculos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVeiculo,Modelo,Ano,IdMontadora")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMontadora = new SelectList(db.Montadoras, "Id", "Nome", veiculo.IdMontadora);
            return View(veiculo);
        }

        // GET: Veiculos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Veiculo veiculo = db.Veiculos.Find(id);
            db.Veiculos.Remove(veiculo);
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
