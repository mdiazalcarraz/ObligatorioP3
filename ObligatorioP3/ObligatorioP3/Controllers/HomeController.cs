using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using ObligatorioP3.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;
using LogicaAplicacion.CasosUso.CasosUsoUsuario;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Http;

namespace ObligatorioP3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ICULoginUsuario CULogin { get; set; }

        public ICUEncriptarContraseniaUsuario CUEncriptarContrasenia { get; set; }
        
		public HomeController(ILogger<HomeController> logger, ICULoginUsuario cuLogin, ICUEncriptarContraseniaUsuario cUEncriptarContraseniaUsuario)
		{
			_logger = logger;
			CULogin = cuLogin;
            CUEncriptarContrasenia = cUEncriptarContraseniaUsuario;
        }

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            try
            {
                string contraEncriptada = CUEncriptarContrasenia.EncriptarContrasenia(password);
                Usuario usu = CULogin.Login(email, contraEncriptada);
                if (usu != null)
                {
                    HttpContext.Session.SetString("usu", email);
                    if (usu.Administrador) { HttpContext.Session.SetString("rol", "Admin"); }
                    return RedirectToAction("Index", "Usuarios");
                }
                else
                {
                    ViewBag.Mensaje = "Usuario o contraseña no válidos";
                    return View();
                }
            }
            catch
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado";
                return View();
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }


    }
}
