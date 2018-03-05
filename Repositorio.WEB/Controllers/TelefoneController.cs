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

namespace Repositorio.WEB.Controllers
{
    public class TelefoneController : Controller
    {
        private readonly TelefoneRepositorio repTel = new TelefoneRepositorio();

        // GET: Telefone
        public ActionResult Index()
        {
            return View(repTel.GetAll().ToList());
        }

        // GET: Telefone/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Telefone telefone = repTel.Find(id);

            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        // GET: Telefone/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Telefone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TelefoneID,ContatoID,NumeroTelefone,TipoTelefone")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                repTel.Adicionar(telefone);
                repTel.SalvarTodos();
                return RedirectToAction("Index");
            }

            return View(telefone);
        }

        // GET: Telefone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefone telefone = repTel.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        // POST: Telefone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TelefoneID,ContatoID,NumeroTelefone,TipoTelefone")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                repTel.Atualizar(telefone);
                repTel.SalvarTodos();
                return RedirectToAction("Index");
            }
            return View(telefone);
        }

        // GET: Telefone/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefone telefone = repTel.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        // POST: Telefone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefone telefone = repTel.Find(id);
            repTel.Excluir(t => t == telefone);
            repTel.SalvarTodos();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            repTel.Dispose();
            base.Dispose(disposing);
        }
    }
}
