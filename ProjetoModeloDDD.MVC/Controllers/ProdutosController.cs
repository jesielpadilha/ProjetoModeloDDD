using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IClienteAppService _clienteApp;
        private readonly IProdutoAppService _produtoApp;
        private readonly IMapper _mapper;

        public ProdutosController(IClienteAppService clienteApp, IProdutoAppService produtoApp, IMapper mapper)
        {
            _clienteApp = clienteApp;
            _produtoApp = produtoApp;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var ProdutoViewModel = _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.GetAll());
            return View(ProdutoViewModel);
        }

        //public ActionResult Especiais()
        //{
        //    var ProdutoViewModel = _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_ProdutoApp.ObterProdutosEspeciais());
        //    return View(ProdutoViewModel);
        //}

        public ActionResult Details(int id)
        {
            var produto = _produtoApp.GetById(id);
            var ProdutoViewModel = _mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(ProdutoViewModel);
        }

        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = _mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Add(produtoDomain);

                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }

        public ActionResult Edit(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = _mapper.Map<Produto, ProdutoViewModel>(produto);

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteId);
            return View(produtoViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = _mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Update(produtoDomain);

                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }

        public ActionResult Delete(int id)
        {
            var produto = _produtoApp.GetById(id);
            var ProdutoViewModel = _mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(ProdutoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var Produto = _produtoApp.GetById(id);
            _produtoApp.Remove(Produto);

            return RedirectToAction("Index");
        }
    }
}
