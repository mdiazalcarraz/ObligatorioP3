using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
                HttpClient client = new HttpClient();
                string url = "http://localhost:5190/api/Usuario/" + email + password; // Esta mal

                Task<HttpResponseMessage> tarea1 = client.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    HttpContent contenido = respuesta.Content;

                    Task<string> tarea2 = contenido.ReadAsStringAsync();
                    tarea2.Wait();

                    string json = tarea2.Result;

                    DTOUsuario usuario = JsonConvert.DeserializeObject<DTOUsuario>(json);

                    HttpContext.Session.SetString("usu", email);
                    if (usuario.EsEncargado != null )
                    {
                        if (usuario.EsEncargado) { HttpContext.Session.SetString("rol","Encargado"); }
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex;
            }
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

    }
}
