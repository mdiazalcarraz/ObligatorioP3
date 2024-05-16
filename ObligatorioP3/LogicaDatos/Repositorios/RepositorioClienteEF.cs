using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ExcepcionesPropias;

namespace LogicaDatos.Repositorios
{
    public class RepositorioClienteEF : IRepositorioCliente
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioClienteEF(LibreriaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Cliente cliente)
        {
            if (cliente != null)
            {
                cliente.Validar();
                if (FindByRUT(cliente.Rut) == null)
                {
                    Contexto.Clientes.Add(cliente);
                    Contexto.SaveChanges();
                }
                else { throw new DatosInvalidosException("El RUT ya esta en uso"); }
            }
        }

        public List<Cliente> FindAll()
        {
            return Contexto.Clientes.ToList();
        }

        public void Remove(int id)
        {
            Cliente aBorrar = Contexto.Clientes.Find(id);
            if (aBorrar != null)
            {
                Contexto.Clientes.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(Cliente cliente)
        {
            cliente.Validar();
            Contexto.Update(cliente);
            Contexto.SaveChanges();
        }

        public Cliente FindById(int id)
        {
            return Contexto.Clientes
                 .Where(Cliente => Cliente.Id == id)
                 .SingleOrDefault();
        }
        public Cliente BuscarClienteNombre(string RazonSocial)
        {
            return Contexto.Clientes
                       .Where(Cliente => Cliente.RazonSocial == RazonSocial)
                   .SingleOrDefault();
        }

        public Cliente BuscarClientePorMonto(int monto)
        {
            var pedido = Contexto.Pedidos.FirstOrDefault(p => p.Total == monto);
            return pedido?.Cliente;
        }

        public Cliente FindByRUT(long RUT)
        {
            {
                return Contexto.Clientes
                       .Where(Cliente => Cliente.Rut == RUT)
                   .SingleOrDefault();
            }
        }

        public List<Cliente> ListaByRazonSocial(string RazonSocial)
        {
            return Contexto.Clientes
           .Where(cliente => cliente.RazonSocial.Contains(RazonSocial))
           .ToList();
        }
    }
}
