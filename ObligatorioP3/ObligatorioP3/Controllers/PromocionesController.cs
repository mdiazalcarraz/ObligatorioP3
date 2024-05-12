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
    public class PromocionesController : Controller
    {
        public ICUListado<Promocion> CUListado { get; set; }

        public ICUAlta<Promocion> CUAlta { get; set; }

        public ICUBaja<Promocion> CUBaja { get; set; }

        public ICUBuscarPorId<Promocion> CUBuscar { get; set; }

        public PromocionesController(ICUListado<Promocion> cuListado, ICUAlta<Promocion> cuAlta, ICUBaja<Promocion> cuBaja, ICUBuscarPorId<Promocion> cUBuscarPorId)
        {
            CUListado = cuListado;
            CUAlta = cuAlta;
            CUBaja = cuBaja;
            CUBuscar = cUBuscarPorId;
        }

        // GET: Promocions
        public ActionResult Index()
        {
            List<Promocion> promo = CUListado.ObtenerListado();
            return View(promo);
        }

        // GET: Promocions/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Promocion nueva)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CUAlta.Alta(nueva);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DatosInvalidosException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado. No se hizo el alta de Promocion";
            }

            return View(nueva);
        }

        // GET: Promocions/Delete/5
        public ActionResult Delete(int id)
        {
            Promocion p = CUBuscar.Buscar(id);
            return View(p);
        }

        // POST: Promocions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Promocion p)
        {
            try
            {
                CUBaja.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Mensaje = "Ocurrió un error, no se pudo realizar accion";
                return View();
            }
        }
    }
}
