using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace WebAppMVC.Controllers
{
    public class MovimientoStockController : Controller
    {
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            string url = "http://localhost:5190/api/MovimientoStock";

            Task<HttpResponseMessage> tarea1 = client.GetAsync(url);
            tarea1.Wait();

            HttpResponseMessage respuesta = tarea1.Result;

            if (respuesta.IsSuccessStatusCode)
            {
                HttpContent contenido = respuesta.Content;

                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();

                string json = tarea2.Result;

                List<DTOMovimientoStock> movimientoStocks = JsonConvert.DeserializeObject<List<DTOMovimientoStock>>(json);

                return View(movimientoStocks);
            }
            else
            {
                ViewBag.Mesaje = "Ocurrió un problema";
            }


            return View(new List<DTOMovimientoStock>());
        }

        // GET: movimientoStockController/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            string url = "http://localhost:5190/api/MovimientoStock/" + id;

            Task<HttpResponseMessage> tarea1 = client.GetAsync(url);
            tarea1.Wait();

            HttpResponseMessage respuesta = tarea1.Result;

            if (respuesta.IsSuccessStatusCode)
            {
                HttpContent contenido = respuesta.Content;

                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();

                string json = tarea2.Result;

                DTOMovimientoStock movimientoStock = JsonConvert.DeserializeObject<DTOMovimientoStock>(json);

                return View(movimientoStock);
            }
            else
            {
                ViewBag.Mesaje = "Ocurrió un problema";
            }

            return View();
        }

        // GET: movimientoStockController/Create
        public ActionResult Create()
        {
            //try
            //{
            //    HttpClient client = new HttpClient();
            //    string url = "http://localhost:5190/api/Articulos";

            //    Task<HttpResponseMessage> tarea1 = client.GetAsync(url);
            //    tarea1.Wait();

            //    HttpResponseMessage respuesta = tarea1.Result;

            //    if (respuesta.IsSuccessStatusCode)
            //    {
            //        HttpContent contenido = respuesta.Content;

            //        Task<string> tarea2 = contenido.ReadAsStringAsync();
            //        tarea2.Wait();

            //        string json = tarea2.Result;

            //        List<DTOArticulo> articulos = JsonConvert.DeserializeObject<List<DTOArticulo>>(json);
            //        ViewBag.Articulos = articulos.Select(a => new SelectListItem
            //        {
            //            Value = a.Id.ToString(),
            //            Text = a.Nombre
            //        }).ToList();
            //    }
            //    else
            //    {
            //        ViewBag.Mensaje = "No se pudieron obtener los artículos.";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Mensaje = "Error: " + ex.Message;
            //}

            return View();
        }

        // POST: movimientoStockController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTOMovimientoStock nuevo)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = "http://localhost:5190/api/MovimientoStock";
                nuevo.Id = 0;
                var tarea1 = client.PostAsJsonAsync(url, nuevo);
                tarea1.Wait();
                var tarea2 = tarea1.Result.Content.ReadAsStringAsync();
                tarea2.Wait();

                if (tarea1.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Mensaje = tarea2.Result;
                    return View(nuevo);
                }
            }
            catch
            {
                return View(nuevo);
            }
        }
    }
}
