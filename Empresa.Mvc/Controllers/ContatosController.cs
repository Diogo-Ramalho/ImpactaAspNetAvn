using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Empresa.Repositorios.SqlServer;
using Empresa.Dominio;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Empresa.Mvc.Controllers
{
    public class ContatosController : Controller
    {
        private readonly EmpresaDbContext _contexto;
        public ContatosController(EmpresaDbContext contexto)
        {
            _contexto = contexto;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_contexto.Contatos.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            if (!ModelState.IsValid)
            {
                return View(contato);
            }

            _contexto.Add(contato);
            _contexto.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}