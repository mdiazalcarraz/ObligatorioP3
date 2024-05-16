using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUsoClientes
{
    public class CUListarClienteMontoPedido : ICUListarClientePorMonto
    {
        public IRepositorioCliente Repo { get; set; }

        public IRepositorioPedido RepoPedido { get; set; }

        public CUListarClienteMontoPedido(IRepositorioCliente repo, IRepositorioPedido repoPedido)
        {
            Repo = repo;
            RepoPedido = repoPedido;
        }

        public List<Cliente> ListarClientePorMonto(long monto)
        {
            List<Cliente> clientesConPedidosSuperioresAlMonto = new List<Cliente>();

            foreach (var cliente in Repo.FindAll())
            {
                List<Pedido> listaPedidoPorCliente = RepoPedido.FindByIdCliente(cliente.Id);

                double totalMontoPedidos = listaPedidoPorCliente.Sum(pedido => pedido.Total);

                if (totalMontoPedidos > monto)
                {
                    clientesConPedidosSuperioresAlMonto.Add(cliente);
                }
            }
            return clientesConPedidosSuperioresAlMonto;
        }
    }
}
