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
using Montadoras.Veiculos.Repositorios.Comum;
using Montadoras.Veiculos.Repositorios.Entity;
using Montadoras.Veiculos.Web.ViewModels.Montadora;
using Montadoras.Veiculos.Web.ViewModels.Veiculo;

namespace Montadoras.Veiculos.Web.Controllers
{
    [Authorize]
    public class VeiculosController : Controller
    {
        //private MontadoraDbContext db = new MontadoraDbContext();
        private IRepositorioGenerico<Veiculo, long>
            repositorioVeiculos = new VeiculosRepositorio(new MontadoraDbContext());

        private IRepositorioGenerico<Montadora, int>
            repositorioMontadoras = new MontadorasRepositorio(new MontadoraDbContext());

        // GET: Veiculos
        public ActionResult Index()
        {
            // var veiculos = db.Veiculos.Include(v => v.Montadora);
            return View(Mapper.Map<List<Veiculo>,
                        List<VeiculoIndexViewModel>>
                        (repositorioVeiculos.Selecionar()));
        }

        // GET: Veiculos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = repositorioVeiculos.SelecionarPorId(id.Value);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Veiculo, VeiculoIndexViewModel>(veiculo));
        }

        // GET: Veiculos/Create
        public ActionResult Create()
        {
            // ViewBag.IdMontadora = new SelectList(db.Montadoras, "Id", "Nome");
            List<MontadoraIndexViewModel> montadoras = Mapper.Map<List<Montadora>, 
                List<MontadoraIndexViewModel>>(repositorioMontadoras.Selecionar());

            SelectList dropDownMontadoras = new SelectList(montadoras, "Id", "Nome");
            ViewBag.DropDownMontadoras = dropDownMontadoras;

            return View();
        }

        // POST: Veiculos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVeiculo,Modelo,Ano,IdMontadora")] VeiculoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Veiculo veiculo = Mapper.Map<VeiculoViewModel, Veiculo>(viewModel);
                repositorioVeiculos.Inserir(veiculo);
                return RedirectToAction("Index");
            }

           // ViewBag.IdMontadora = new SelectList(db.Montadoras, "Id", "Nome", veiculo.IdMontadora);
            return View(viewModel);
        }

        // GET: Veiculos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = repositorioVeiculos.SelecionarPorId(id.Value);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            //ViewBag.IdMontadora = new SelectList(db.Montadoras, "Id", "Nome", veiculo.IdMontadora);

            List<MontadoraIndexViewModel> montadoras = Mapper.Map<List<Montadora>,
                            List<MontadoraIndexViewModel>>(repositorioMontadoras.Selecionar());

            SelectList dropDownMontadoras = new SelectList(montadoras, "Id", "Nome");
            ViewBag.DropDownMontadoras = dropDownMontadoras;
            return View(Mapper.Map<Veiculo, VeiculoViewModel>(veiculo));
        }

        // POST: Veiculos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVeiculo,Modelo,Ano,IdMontadora")] VeiculoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Veiculo veiculo = Mapper.Map<VeiculoViewModel, Veiculo>(viewModel);
                repositorioVeiculos.Alterar(veiculo);
                return RedirectToAction("Index");
            }
            //ViewBag.IdMontadora = new SelectList(db.Montadoras, "Id", "Nome", veiculo.IdMontadora);
            return View(viewModel);
        }

        // GET: Veiculos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = repositorioVeiculos.SelecionarPorId(id.Value);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Veiculo, VeiculoIndexViewModel>(veiculo));
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repositorioVeiculos.ExcluirPorId(id);
            return RedirectToAction("Index");
        }        
    }
}
