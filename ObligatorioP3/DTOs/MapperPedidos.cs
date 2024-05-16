using LogicaNegocio.Dominio;
using LogicaNegocio.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperPedidos
    {
        public static DTOPedidoSimple ToDTOPedidoSimple(Pedido pedido)
        {
            return new DTOPedidoSimple()
            {
                Estado = pedido.Estado,
                Id = pedido.Id,
                FechaPedido = pedido.FechaPedido,
                FechaPrometida = pedido.FechaPrometida,
                Cliente = pedido.Cliente,
                Total = pedido.Total
            };
        }

        public static List<DTOPedidoSimple> ToListaDTOAutorSimple(List<Pedido> pedidos)
        {
            return pedidos.Select(pedido => ToDTOPedidoSimple(pedido)).ToList();
        }
    }
}