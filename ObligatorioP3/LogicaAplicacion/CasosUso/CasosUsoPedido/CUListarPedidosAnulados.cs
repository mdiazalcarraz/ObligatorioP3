using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUsoPedido
{
    public class CUListarPedidosAnulados : ICUListarPedidosAnulados
    {
        public IRepositorioPedido Repo { get; set; }

        public CUListarPedidosAnulados(IRepositorioPedido repo)
        {
            Repo = repo;
        }
        public List<DTOPedidoSimple> ListarPedidosAnulados()
        {
            List<Pedido> pedidosAnulados = Repo.ListarPedidosAnulados(); 
            List<DTOPedidoSimple> DTOPedidos = MapperPedidos.ToListaDTOAutorSimple(pedidosAnulados);
            return DTOPedidos;
        }
    }
}
