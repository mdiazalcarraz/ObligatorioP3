using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUsoPedido
{
    public   class CUAltaPedido : ICUAlta<Pedido>
    {
        public IRepositorioPedido Repo { get; set; }

        public CUAltaPedido(IRepositorioPedido repo)
        {
            Repo = repo;
        }
        public void Alta(Pedido pedido)
        {
            Repo.Add(pedido);
         
        }
    }
}
