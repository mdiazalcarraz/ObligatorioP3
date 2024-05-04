using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.ExcepcionesPropias;

namespace ObligatorioP3.Controllers
{
    public class ArticulosController : Controller
    {

        public ICUListado<Articulo> CUListado { get; set; }

        public ICUAlta<Articulo> CUAlta { get; set; }

        public ICUBuscarPorId<Articulo> CUBuscar { get; set; }

        public ICUBaja<Articulo> CUBajaArt { get; set; }

        public ArticulosController(ICUListado<Articulo> cuListado, ICUAlta<Articulo> cuAlta, ICUBuscarPorId<Articulo> cUBuscar, ICUBaja<Articulo> cUBajaArt)
        {
            CUListado = cuListado;
            CUAlta = cuAlta;
            CUBuscar = cUBuscar;
            CUBajaArt = cUBajaArt;
        }

        // GET: Articulos
        public ActionResult Index()
        {
            List<Articulo> articulos = CUListado.ObtenerListado();
            articulos = articulos.OrderBy(u => u.Nombre).ToList();
            return View(articulos);
        }


        // GET: Articulos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Articulo nuevo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CUAlta.Alta(nuevo);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DatosInvalidosException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado. No se hizo el alta de Articulo";
            }

            return View(nuevo);
        }

        // GET: Articulos/Edit/5


        // POST: Articulos/Edit/5


        // GET: Articulos/Delete/5
        public ActionResult Delete(int id)
        {
            Articulo u = CUBuscar.Buscar(id);
            return View(u);
        }

        //POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Articulo u)
        {
            try
            {
                CUBajaArt.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
