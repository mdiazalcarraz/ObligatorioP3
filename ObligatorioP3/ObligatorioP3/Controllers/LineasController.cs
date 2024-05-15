﻿using System;
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
using System.Drawing.Drawing2D;
using LogicaAplicacion.CasosUso.CasosUsoLinea;
using LogicaAplicacion.CasosUso.CasosUsoArticulo;

namespace ObligatorioP3.Controllers
{
    public class LineasController : Controller
    {
        public ICUListado<Linea> CUListado { get; set; }

        public ICUListado<Promocion> CUListadoPromocion { get; set; }

        public ICUListado<Articulo> CUListadoArticulo { get; set; }

        public ICUAlta<Linea> CUAlta { get; set; }

        public ICUBaja<Linea> CUBaja { get; set; }

        public ICUBuscarPorId<Linea> CUBuscar { get; set; }

        public ICUBuscarPorId<Articulo> CUBuscarArticulo { get; set; }

        public ICUBuscarPorId<Promocion> CUBuscarPromocion { get; set; }


        public LineasController(ICUListado<Linea> cuListado, ICUAlta<Linea> cuAlta, ICUBaja<Linea> cuBaja, ICUBuscarPorId<Linea> cUBuscarPorId, ICUListado<Promocion> cUListadoPromocion, ICUListado<Articulo> cUListadoArticulo, ICUBuscarPorId<Articulo> cUBuscarArticulo, ICUBuscarPorId<Promocion> cUBuscarPromocion)
        {
            CUListado = cuListado;
            CUAlta = cuAlta;
            CUBaja = cuBaja;
            CUBuscar = cUBuscarPorId;
            CUListadoPromocion = cUListadoPromocion;
            CUListadoArticulo = cUListadoArticulo;
            CUBuscarArticulo = cUBuscarArticulo;
            CUBuscarPromocion = cUBuscarPromocion;
        }

        // GET: Lineas
        public ActionResult Index(int id)
        {
            TempData["PedidoId"] = id;
            List<Linea> lineas = CUListado.ObtenerListado();
            lineas = lineas.Where(l => l.PedidoId == id).ToList();
            return View(lineas);
        }

        // GET: Lineas/Create
        public IActionResult Create()
        {
            ViewBag.PedidoId = (int)TempData["PedidoId"];
            ViewBag.Articulos = CUListadoArticulo.ObtenerListado();
            ViewBag.Promociones = CUListadoPromocion.ObtenerListado();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Linea nueva)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    nueva.Articulo = CUBuscarArticulo.Buscar(nueva.ArticuloId);
                    nueva.Promocion = CUBuscarPromocion.Buscar(nueva.PromocionId);
                    CUAlta.Alta(nueva);
                    List<Linea> lineas = CUListado.ObtenerListado();
                    lineas = lineas.Where(l => l.PedidoId == nueva.PedidoId).ToList();
                    return RedirectToAction("Index", new { id = nueva.PedidoId, lineas = lineas });
                //}
            }
            catch (DatosInvalidosException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado. No se hizo el alta de Linea";
            }

            return View(nueva);
        }

        // GET: Lineas/Delete/5
        public ActionResult Delete(int id)
        {
            Linea p = CUBuscar.Buscar(id);
            return View(p);
        }

        // POST: Lineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Linea p)
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
