using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        public ICUListarPedidosAnulados CUListadoAnulados { get; set; }


        public PedidosController(ICUListarPedidosAnulados cuListado)
        {
            CUListadoAnulados = cuListado;
        }

        // GET: Articulos
        public IActionResult Get()
        {
            try
            {
                List<Pedido> pedidos = CUListadoAnulados.ListarPedidosAnulados();
                pedidos = pedidos.OrderBy(u => u.FechaPedido)
                         .ToList();
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
