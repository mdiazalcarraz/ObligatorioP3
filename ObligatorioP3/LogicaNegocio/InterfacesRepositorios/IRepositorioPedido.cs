using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPedido : IRepositorio<Pedido>
    {
       void AnularPedido(int ID);

       List<Pedido> ListarPedidosAnulados();

        List<Linea> LineasFindAll();

        void AddLinea(Linea linea);

        public void RemoveLinea(int id);

        public void UpdateLinea(Linea linea);

        public Linea FindByIdLinea(int id);

        public List<Pedido> FindByIdCliente(int id);
    }
}
