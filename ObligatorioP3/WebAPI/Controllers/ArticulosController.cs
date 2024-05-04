using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        public ICUListado<Articulo> CUListado { get; set; }

  
        public ArticulosController(ICUListado<Articulo> cuListado)
        {
            CUListado = cuListado;
        }

        // GET: Articulos
        public IActionResult Get()
        {
            try
            {
                List<Articulo> articulos = CUListado.ObtenerListado();
                articulos = articulos.OrderBy(u => u.Nombre).ToList();
                return Ok(articulos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
