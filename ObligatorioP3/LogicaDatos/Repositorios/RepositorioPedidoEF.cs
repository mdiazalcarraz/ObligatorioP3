using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
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
                    Contexto.Pedidos.Add(pedido);
                    Contexto.SaveChanges();
                }
                else { throw new DatosInvalidosException("El pedido no pudo ser creado"); }
            }
        }

        public void AddLinea(Linea linea)
        {
            if (linea != null)
            {
                linea.Validar();
                if (FindById(linea.Id) == null)
                {
                    Contexto.Lineas.Add(linea);
                    Contexto.SaveChanges();
                }
                else { throw new DatosInvalidosException("La linea no pudo ser creada"); }
            }
        }



        public List<Pedido> FindAll()
        {
            return Contexto.Pedidos.Include(l => l.Cliente).Include(p => p.Lineas).ToList();
        }

        public List<Linea> LineasFindAll()
        {
            return Contexto.Lineas
            .Include(l => l.Articulo)
            .Include(l => l.Promocion)
            .ToList();
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

        public void RemoveLinea(int id)
        {
            Linea aBorrar = Contexto.Lineas.Find(id);
            if (aBorrar != null)
            {
                Contexto.Lineas.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(Pedido pedido)
        {
            pedido.Validar();
            Contexto.Update(pedido);
            Contexto.SaveChanges();
        }

        public void UpdateLinea(Linea linea)
        {
            linea.Validar();
            Contexto.Update(linea);
            Contexto.SaveChanges();
        }

        public Pedido FindById(int id)
        {
            return Contexto.Pedidos.Include(p => p.Lineas)
        .Include(p => p.Cliente)
            .ThenInclude(c => c.Direccion)
        .Where(pedido => pedido.Id == id)
        .SingleOrDefault();
        }

        public Linea FindByIdLinea(int id)
        {
            return Contexto.Lineas
                 .Where(Linea => Linea.Id == id)
                 .SingleOrDefault();
        }

        public void AnularPedido(int ID)
        {
            Pedido pedido = Contexto.Pedidos.Find(ID);
            if (pedido != null)
            {
                pedido.Estado = "Anulado";
                Contexto.Update(pedido);
                Contexto.SaveChanges();
            }
            else { throw new DatosInvalidosException("No se logro encontrar el pedido"); }
        }
        public List<Pedido> ListarPedidosAnulados()
        {
            return Contexto.Pedidos
           .Where(pedido => pedido.Estado.Contains("Anulado"))
           .ToList();
        }
    }
}
