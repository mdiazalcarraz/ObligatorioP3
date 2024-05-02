using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoUsuario
{
    public class CUBuscarUsuarioPorId : ICUBuscarPorId<Usuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUBuscarUsuarioPorId(IRepositorioUsuario repo)
        {
            Repo = repo;
        }
        public Usuario Buscar(int id)
        {
            return Repo.FindById(id);
        }
    }
}
