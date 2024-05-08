using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoClientes
{
    internal class CUListarClientes : ICUListado<Cliente>
    {
        public IRepositorioCliente Repo { get; set; }

        public CUListarClientes(IRepositorioCliente repo)
        {
            Repo = repo;
        }
        public List<Cliente> ObtenerListado()
        {
            return Repo.FindAll();
        }
    }
}
