using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUsoPedido
{
    public   class CUAltaPedido
    {
        public RepositorioPedidos RepoPedido { get; set; }

        public CUAltaPedido()
        {
            RepoPedido = new RepositorioPedidos();
        }
        public void Alta(Pedido pedido)
        {
            RepoPedido.Add(pedido);
            
        }
    }
}
