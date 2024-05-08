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
    internal class CUListarPedidos : ICUListado<Pedido>
    {

        public IRepositorioPedido Repo { get; set; }

        public CUListarPedidos(IRepositorioPedido repo)
        {
            Repo = repo;
        }
  
        List<Pedido> ICUListado<Pedido>.ObtenerListado()
        {
            return Repo.FindAll();
        }
    }
}
