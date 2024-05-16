using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoLinea
{
    public class CUAltaLinea : ICUAlta<Linea>
    {
        public IRepositorioPedido Repo { get; set; }

        public CUAltaLinea(IRepositorioPedido repo)
        {
            Repo = repo;
        }
        public void Alta(Linea linea)
        {
            double promo = (double)1 - (linea.Promocion.Descuento / 100.0);
            linea.SubTotal = linea.Articulo.Precio * linea.Cantidad * promo;
            if (linea.Pedido == null)
            {
                Pedido pedido = Repo.FindById(linea.PedidoId);
                linea.Pedido = pedido;
            }
            Repo.AddLinea(linea);
        }
    }
}
