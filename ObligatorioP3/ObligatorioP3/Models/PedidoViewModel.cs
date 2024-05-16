using LogicaNegocio.Dominio;

namespace ObligatorioP3.Models
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
