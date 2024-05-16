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
    public class CUListarClienteNombre : ICUListarClientePorNombre
    {
        public IRepositorioCliente Repo { get; set; }

        public CUListarClienteNombre(IRepositorioCliente repo)
        {
            Repo = repo;
        }

        public List<Cliente> BuscarPorNombre(string nombre)
        {
            List<Cliente> lista = Repo.FindAll();
            return lista.Where(cliente => cliente.RazonSocial.Contains(nombre)).ToList();
        }
    }
}
