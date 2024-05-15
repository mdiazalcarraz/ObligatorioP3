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

        public List<Pedido> FindAll()
        {
            return Contexto.Pedidos.Include(l => l.Cliente).Include(p => p.Lineas).ToList();
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
            return Contexto.Pedidos.Include(p => p.Lineas)
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
        public void CalcularTotal(int id)
        {
            Pedido pedido = Contexto.Pedidos.Find(id);
            double sumaLineas = 0;
            double difPorTipo = 0;
            TimeSpan diferenciaFechasPedido = pedido.FechaPrometida - pedido.FechaPedido;

            if (pedido.Lineas != null && pedido.Lineas.Any())
            {
                sumaLineas = pedido.Lineas.Sum(linea => linea.SubTotal);
            }
            else
            {
                sumaLineas = 0;
            }
            if (pedido.Tipo == "Pedido Comun") 
            {   
                if (pedido.Cliente.Direccion.DistanciaDeposito > 100) 
                {
                    difPorTipo = 1.05;
                }
            } else if (pedido.Tipo == "Pedido Express") 
            {
                if ((int)diferenciaFechasPedido.TotalDays == 0)
                {
                    difPorTipo = 1.15;
                } else
                {
                    difPorTipo = 1.10;
                }
            }
            //pedido.Iva = IVA;
            //pedido.Total = sumaLineas * difPorTipo * IVA;
            Contexto.Update(pedido);
            Contexto.SaveChanges();
        }
    }
}
