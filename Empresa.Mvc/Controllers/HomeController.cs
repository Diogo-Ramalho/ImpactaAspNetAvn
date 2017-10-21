using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Empresa.Mvc.ViewModels;
using Empresa.Repositorios.SqlServer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Empresa.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmpresaDbContext _contexto;
        private IDataProtector _protectorProvider;
        private IConfiguration _configuracao;

        public HomeController(EmpresaDbContext contexto, IDataProtectionProvider protectionProvider, IConfiguration configuracao)
        {
            _contexto = contexto;
            _protectorProvider = protectionProvider.CreateProtector(configuracao.GetSection("ChaveCriptografia").Value);
            _configuracao = configuracao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrador, Vendedor")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var contato = _contexto.Contatos
                .Where(i => i.Email == viewModel.Email)
                .Where(j => _protectorProvider.Unprotect(j.Senha) == viewModel.Senha).SingleOrDefault();

            if (contato == null)
            {
                ModelState.AddModelError(string.Empty, "Usuário ou senha incorretos.");
                return View(viewModel);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, contato.Nome),
                new Claim(ClaimTypes.Email, contato.Email),

                new Claim(ClaimTypes.Role, "Vendedor"),
                new Claim(ClaimTypes.Role, "Consultor"),
                new Claim(ClaimTypes.Role, "Contabil"),

                new Claim("Contatos", "Inserir")
            };

            var identidade = new ClaimsIdentity(claims, _configuracao.GetSection("TipoAutenticacao").Value);

            var principal = new ClaimsPrincipal(identidade);

            HttpContext.Authentication.SignInAsync(_configuracao.GetSection("TipoAutenticacao").Value, principal);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AcessoNegado()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Authentication.SignOutAsync(_configuracao.GetSection("TipoAutenticacao").Value);
            return RedirectToAction("Index");
        }
    }
}
