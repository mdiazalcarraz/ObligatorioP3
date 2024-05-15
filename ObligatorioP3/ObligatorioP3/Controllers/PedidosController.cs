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
using System.Drawing.Drawing2D;
using LogicaAplicacion.CasosUsoPedido;

namespace ObligatorioP3.Controllers
{
    public class PedidosController : Controller
    {
        public ICUListado<Pedido> CUListado { get; set; }

        public ICUAlta<Pedido> CUAlta { get; set; }

        public ICUAlta<Linea> CUAltaLinea { get; set; }

        public ICUBuscarPorId<Pedido> CUBuscar { get; set; }

        public ICUListado<Promocion> CUListadoPromocion { get; set; }

        public ICUListado<Articulo> CUListadoArticulo { get; set; }

        public ICUListado<Cliente> CUListadoClientes { get; set; }

        public ICUBuscarPorId<Articulo> CUBuscarArticulo { get; set; }

        public ICUBuscarPorId<Promocion> CUBuscarPromocion { get; set; }

        public ICUBuscarPorId<Cliente> CUBuscarCliente { get; set; }

        public ICUListarPedidosAnulados CUListarPedidosAnulados { get; set; }

        public ICUAnularPedido CUAnularPedido { get; set; }

        public ICUCalcularTotal CUCalcularTotal { get; set; }


        public PedidosController(ICUListado<Pedido> cuListado, ICUAlta<Pedido> cuAlta, ICUBuscarPorId<Pedido> cUBuscar, ICUListado<Cliente> cUListadoClientes, ICUListado<Promocion> cUListadoPromocion, ICUListado<Articulo> cUListadoArticulo, ICUBuscarPorId<Cliente> cUBuscarCliente, ICUBuscarPorId<Articulo> cUBuscarArticulo, ICUBuscarPorId<Promocion> cUBuscarPromocion, ICUAlta<Linea> cUAltaLinea, ICUListarPedidosAnulados cUListarPedidosAnulados, ICUAnularPedido cUAnularPedido, ICUCalcularTotal cUCalcularTotal)
        {
            CUListado = cuListado;
            CUAlta = cuAlta;
            CUBuscar = cUBuscar;
            CUListadoClientes = cUListadoClientes;
            CUListadoPromocion = cUListadoPromocion;
            CUListadoArticulo = cUListadoArticulo;
            CUBuscarArticulo = cUBuscarArticulo;
            CUBuscarPromocion = cUBuscarPromocion;
            CUBuscarCliente = cUBuscarCliente;
            CUAltaLinea = cUAltaLinea;
            CUListarPedidosAnulados = cUListarPedidosAnulados;
            CUAnularPedido = cUAnularPedido;
            CUCalcularTotal = cUCalcularTotal;
        }

        // GET: Pedidos
        public ActionResult Index()
        {
            List<Pedido> Pedidos = CUListado.ObtenerListado();
            return View(Pedidos);
        }

        public IActionResult ListarPedidosAnulados()
        {
            List<Pedido> PedidosAnulados = CUListarPedidosAnulados.ListarPedidosAnulados();
            return View("Index", PedidosAnulados);
        }


        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewBag.Articulos = CUListadoArticulo.ObtenerListado();
            ViewBag.Promociones = CUListadoPromocion.ObtenerListado();
            ViewBag.Clientes = CUListadoClientes.ObtenerListado();
            return View();
        }

        // POST: Pedidos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoViewModel pedidoViewModel)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                pedidoViewModel.Linea.Articulo = CUBuscarArticulo.Buscar(pedidoViewModel.Linea.ArticuloId);
                pedidoViewModel.Linea.Promocion = CUBuscarPromocion.Buscar(pedidoViewModel.Linea.PromocionId);
                pedidoViewModel.Pedido.Cliente = CUBuscarCliente.Buscar(pedidoViewModel.Pedido.ClienteId);
                pedidoViewModel.Pedido.FechaPrometida = pedidoViewModel.Pedido.FechaPedido.AddDays(pedidoViewModel.DiasParaEntrega);
                CUAlta.Alta(pedidoViewModel.Pedido);
                pedidoViewModel.Linea.Pedido = pedidoViewModel.Pedido;
                CUAltaLinea.Alta(pedidoViewModel.Linea);
                return RedirectToAction(nameof(Index));
                //}
            }
            catch (DatosInvalidosException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado. No se hizo el alta de Pedido";
            }

            return View(pedidoViewModel.Pedido);
        }

        [HttpPost]
        public IActionResult AnularPedido(int id)
        {
            CUAnularPedido.AnularPedido(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CalcularTotal(int id)
        {
            CUAnularPedido.AnularPedido(id);
            return RedirectToAction("Index");
        }


        private bool PedidoExists(int id)
        {
            Pedido p = CUBuscar.Buscar(id);

            if (p == null) return false;


            return true;
        }
    }
}

