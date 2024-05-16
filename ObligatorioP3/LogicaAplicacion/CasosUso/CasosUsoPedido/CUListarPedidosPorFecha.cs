using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoPedido
{
    public class CUListarPedidosPorFecha : ICUListarPedidosPorFecha
    {
        public IRepositorioPedido Repo { get; set; }

        public CUListarPedidosPorFecha(IRepositorioPedido repo)
        {
            Repo = repo;
        }
        public List<Pedido> FiltrarPedidosPorFecha(DateTime? dateTime)
        {
            List<Pedido> pedidos = Repo.FindAll();
            if (dateTime.HasValue)
            {
                pedidos = pedidos.Where(p => p.Estado != "Anulado"
                                              && p.FechaPedido.Date == dateTime.Value.Date
                                              && p.FechaPrometida > DateTime.Now).ToList();
            }
            return pedidos;
        }
    }
}
