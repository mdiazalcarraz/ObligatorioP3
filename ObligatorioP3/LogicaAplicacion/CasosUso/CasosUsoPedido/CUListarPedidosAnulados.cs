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
        public List<Pedido> ListarPedidosAnulados()
        {
            return Repo.ListarPedidosAnulados();
        }

        List<Pedido> ICUListarPedidosAnulados.ListarPedidosAnulados()
        {
            return Repo.ListarPedidosAnulados();
        }
    }
}
