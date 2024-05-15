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
    public class CUBuscarClientePorId : ICUBuscarPorId<Cliente>
    {
        public IRepositorioCliente Repo { get; set; }

        public CUBuscarClientePorId(IRepositorioCliente repo)
        {
            Repo = repo;
        }
        public Cliente Buscar(int id)
        {
            return Repo.FindById(id);
        }

    }
}
