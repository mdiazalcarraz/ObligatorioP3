using DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAppMVC.Controllers
{
    public class TipoMovimientoController : Controller
    {
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            string url = "http://localhost:5190/api/TipoMovimientos";

            Task<HttpResponseMessage> tarea1 = client.GetAsync(url);
            tarea1.Wait();

            HttpResponseMessage respuesta = tarea1.Result;

            if (respuesta.IsSuccessStatusCode)
            {
                HttpContent contenido = respuesta.Content;

                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();

                string json = tarea2.Result;

                List<DTOTipoMovimiento> tipoMovimientos = JsonConvert.DeserializeObject<List<DTOTipoMovimiento>>(json);

                return View(tipoMovimientos);
            }
            else
            {
                ViewBag.Mesaje = "Ocurrió un problema";
            }


            return View(new List<DTOTipoMovimiento>());
        }

        // GET: TipoMovimientoController/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            string url = "http://localhost:5190/api/TipoMovimientos/" + id;

            Task<HttpResponseMessage> tarea1 = client.GetAsync(url);
            tarea1.Wait();

            HttpResponseMessage respuesta = tarea1.Result;

            if (respuesta.IsSuccessStatusCode)
            {
                HttpContent contenido = respuesta.Content;

                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();

                string json = tarea2.Result;

                DTOTipoMovimiento tipoMovimientos = JsonConvert.DeserializeObject<DTOTipoMovimiento>(json);

                return View(tipoMovimientos);
            }
            else
            {
                ViewBag.Mesaje = "Ocurrió un problema";
            }

            return View();
        }

        // GET: TipoMovimientoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoMovimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTOTipoMovimiento nuevo)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = "http://localhost:5190/api/TipoMovimientos";
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

        // GET: TipoMovimientoController/Edit/5
        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            string url = "http://localhost:5190/api/TipoMovimientos/" + id;

            Task<HttpResponseMessage> tarea1 = client.GetAsync(url);
            tarea1.Wait();

            HttpResponseMessage respuesta = tarea1.Result;

            if (respuesta.IsSuccessStatusCode)
            {
                HttpContent contenido = respuesta.Content;

                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();

                string json = tarea2.Result;

                DTOTipoMovimiento tipoMovimiento = JsonConvert.DeserializeObject<DTOTipoMovimiento>(json);

                return View(tipoMovimiento);
            }
            else
            {
                ViewBag.Mesaje = "Ocurrió un problema";
            }

            return View();
        }

        // POST: TipoMovimientoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DTOTipoMovimiento tipoMovimiento)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = "http://localhost:5190/api/TipoMovimientos/" + tipoMovimiento.Id;

                var tarea1 = client.PutAsJsonAsync(url, tipoMovimiento);
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
                    return View(tipoMovimiento);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un problema";
                return View(tipoMovimiento);
            }
        }

        // GET: TipoMovimientoController/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            string url = "http://localhost:5190/api/TipoMovimientos/" + id;

            Task<HttpResponseMessage> tarea1 = client.GetAsync(url);
            tarea1.Wait();

            HttpResponseMessage respuesta = tarea1.Result;

            if (respuesta.IsSuccessStatusCode)
            {
                HttpContent contenido = respuesta.Content;

                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();

                string json = tarea2.Result;

                DTOTipoMovimiento tipoMovimiento = JsonConvert.DeserializeObject<DTOTipoMovimiento>(json);

                return View(tipoMovimiento);
            }
            else
            {
                ViewBag.Mesaje = "Ocurrió un problema";
            }

            return View();
        }

        // POST: TipoMovimientoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DTOTipoMovimiento tipoMovimiento)
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = "http://localhost:5190/api/TipoMovimientos/" + tipoMovimiento.Id;

                var tarea1 = client.DeleteAsync(url);
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
                    return View(tipoMovimiento);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un problema";
                return View(tipoMovimiento);
            }
        }

        //[HttpGet]
        //public ActionResult BuscarInicial()
        //{
        //    HttpClient client = new HttpClient();
        //    string url = "http://localhost:5190/api/TipoMovimientos";

        //    Task<HttpResponseMessage> tarea1 = client.GetAsync(url);
        //    tarea1.Wait();

        //    HttpResponseMessage respuesta = tarea1.Result;

        //    if (respuesta.IsSuccessStatusCode)
        //    {
        //        HttpContent contenido = respuesta.Content;

        //        Task<string> tarea2 = contenido.ReadAsStringAsync();
        //        tarea2.Wait();

        //        string json = tarea2.Result;

        //        List<DTOTema> temas = JsonConvert.DeserializeObject<List<DTOTema>>(json);

        //        return View(temas);
        //    }
        //    else
        //    {
        //        ViewBag.Mesaje = "Ocurrió un problema";
        //    }

        //    return View(new List<DTOTema>());
        //}

        //[HttpPost]
        //public ActionResult BuscarInicial(string inicial)
        //{
        //    HttpClient client = new HttpClient();
        //    string url = "http://localhost:5190/api/Temas/TipoMovimientos/" + inicial;
        //    var tarea1 = client.GetAsync(url);
        //    tarea1.Wait();
        //    var tarea2 = tarea1.Result.Content.ReadAsStringAsync();
        //    tarea2.Wait();

        //    if (tarea1.Result.IsSuccessStatusCode)
        //    {
        //        List<DTOTema> temas = JsonConvert.DeserializeObject<List<DTOTema>>(tarea2.Result);
        //        return View(temas);
        //    }
        //    else
        //    {
        //        ViewBag.Mensaje = tarea2.Result;
        //        return View(new List<DTOTema>());
        //    }
        //}

    }
}
