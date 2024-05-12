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
using LogicaAplicacion.CasosUso.CasosUsoPromocion;

namespace ObligatorioP3.Controllers
{
    public class PedidosController : Controller
    {
        public ICUListado<Pedido> CUListado { get; set; }

        public ICUAlta<Pedido> CUAlta { get; set; }

        public ICUBuscarPorId<Pedido> CUBuscar { get; set; }

        public ICUListado<Cliente> CUListadoClientes { get; set; }

        public PedidosController(ICUListado<Pedido> cuListado, ICUAlta<Pedido> cuAlta, ICUBuscarPorId<Pedido> cUBuscar, ICUListado<Cliente> cUListadoClientes)
        {
            CUListado = cuListado;
            CUAlta = cuAlta;
            CUBuscar = cUBuscar;
            CUListadoClientes = cUListadoClientes;
        }

        // GET: Pedidos
        public ActionResult Index()
        {
            List<Pedido> Pedidos = CUListado.ObtenerListado();
            return View(Pedidos);
        }


        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewBag.Clientes = CUListadoClientes.ObtenerListado();
            return View();
        }

        // POST: Pedidos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pedido nuevo)
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
                ViewBag.Mensaje = "Ocurrió un error inesperado. No se hizo el alta de Pedido";
            }

            return View(nuevo);
        }



        private bool PedidoExists(int id)
        {
            Pedido p = CUBuscar.Buscar(id);

            if (p == null) return false;

            return true;
        }
    }
}
