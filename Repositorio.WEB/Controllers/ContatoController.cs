using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repositorio.DAL;
using Repositorio.Entidades;
using Repositorio.DAL.Repositorios;
using PagedList;
using PagedList.Mvc;


namespace Repositorio.WEB.Controllers
{
    public class ContatoController : Controller
    {
        private BancoContexto db = new BancoContexto();
        private readonly ContatoRepositorio repCont = new ContatoRepositorio();

        // GET: /Contato/
        public ActionResult Index(int? pagina)
        {
            int paginaTamanho = 4;
            int paginaNumero = (pagina ?? 1);


            var dataModel = (from cont in db.Contato
                   join tel in db.Telefone on cont.ContatoID equals tel.ContatoID
                   group tel by new {
                       cont.ContatoID,
                       cont.Nome,
                       tel.NumeroTelefone,
                       tel.TipoTelefone,
                       cont.EmailProfissional
                   } into g
                   select new ContatoViewModel
                   {
                       ContatoID = g.Key.ContatoID,
                       Nome = g.Key.Nome,
                       NumeroTelefone = g.Key.NumeroTelefone,
                       TipoTelefone = g.Key.TipoTelefone,
                       EmailProfissional = g.Key.EmailProfissional
                       
             }).ToList();
            return View(dataModel.ToPagedList(paginaNumero, paginaTamanho));
        }

        // GET: /Contato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = repCont.Find(id);

            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // GET: /Contato/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContatoID,Nome,DataNascimento,EmailProfissional,EmailPessoal")] Contato contato)
        {
            using (var ctx = new BancoContexto())
            {
                var result = ctx.Contato.Where(x => x.Nome == contato.Nome).FirstOrDefault();

                if (result == null)
                {
                    repCont.Adicionar(contato);
                    repCont.SalvarTodos();
                    return RedirectToAction("Index");
                }
            }

            return View(contato);
        }

        // GET: /Contato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = repCont.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContatoID,Nome,DataNascimento,EmailProfissional,EmailPessoal")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                repCont.Atualizar(contato);

                //db.SaveChanges();
                repCont.SalvarTodos();
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        // GET: /Contato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = repCont.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: /Contato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contato contato = repCont.Find(id);

            repCont.Excluir(c => c == contato);

            //db.SaveChanges();
            repCont.SalvarTodos();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            repCont.Dispose();
            base.Dispose(disposing);
        }
    }
}
