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
            try
            {
                HttpClient client = new HttpClient();
                string url = "http://localhost:5190/api/Articulos";

                Task<HttpResponseMessage> tarea1 = client.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    HttpContent contenido = respuesta.Content;

                    Task<string> tarea2 = contenido.ReadAsStringAsync();
                    tarea2.Wait();

                    string json = tarea2.Result;

                    List<DTOArticulo> articulos = JsonConvert.DeserializeObject<List<DTOArticulo>>(json);
                    HttpContext.Session.SetString("Articulos", JsonConvert.SerializeObject(articulos));
                }
                else
                {
                    ViewBag.Mensaje = "No se pudieron obtener los artículos.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error: " + ex.Message;
            }

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
    }
}
