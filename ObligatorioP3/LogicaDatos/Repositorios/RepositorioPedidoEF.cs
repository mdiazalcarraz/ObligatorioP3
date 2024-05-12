using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionesPropias;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioPedidoEF : IRepositorioPedido
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioPedidoEF(LibreriaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Pedido pedido)
        {
            if (pedido != null)
            {
                pedido.Validar();
                if (FindById(pedido.Id) == null)
                {
                    pedido.Total = CalcularTotal();
                    Contexto.Pedidos.Add(pedido);
                    Contexto.SaveChanges();
                }
                else { throw new DatosInvalidosException("El pedido ya fue creado"); }
            }
        }

        public List<Pedido> FindAll() 
        {
            return Contexto.Pedidos.Include(p=>p.Lineas).ToList();
        }

        public void Remove(int id)
        {
            Pedido aBorrar = Contexto.Pedidos.Find(id);
            if (aBorrar != null)
            {
                Contexto.Pedidos.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(Pedido pedido)
        {
            pedido.Validar();
            Contexto.Update(pedido);
            Contexto.SaveChanges();
        }

        public Pedido FindById(int id)
        {
            return Contexto.Pedidos.Include(p=>p.Lineas)
                 .Where(Pedido => Pedido.Id == id)
                 .SingleOrDefault();
        }
        public void AnularPedido(int ID)
        {

            Pedido pedido = Contexto.Pedidos.Find(ID);
            if (pedido != null)
            {
                pedido.Estado = "Anulado";
                Contexto.Update(pedido);
            }
            else { throw new DatosInvalidosException("No se logro encontrar el pedido"); }
        }
        public List<Pedido> ListarPedidosAnulados()
        {
            return Contexto.Pedidos
           .Where(pedido => pedido.Estado.Contains("Anulado"))
           .ToList();
        }
        public int CalcularTotal() 
        {
            int total = 0;
            return total;
        }
    }
}
