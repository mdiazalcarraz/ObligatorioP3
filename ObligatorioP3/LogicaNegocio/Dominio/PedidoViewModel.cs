using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class PedidoViewModel
    {
        public Pedido Pedido { get; set; }
        public Linea Linea { get; set; }
        public int DiasParaEntrega { get; set; }

        public PedidoViewModel()
        {
            Linea = new Linea();
            Pedido = new Pedido();
        }
    }

}
