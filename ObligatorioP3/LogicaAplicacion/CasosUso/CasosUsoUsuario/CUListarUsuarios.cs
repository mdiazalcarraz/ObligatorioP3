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
    public class CUListarUsuarios : ICUListado<Usuario>
    {
        public IRepositorioUsuario RepoUsuarios { get; set; }

        public CUListarUsuarios(IRepositorioUsuario repo)
        {
            RepoUsuarios = repo;
        }
        public List<Usuario> ObtenerListado()
        {
            return RepoUsuarios.FindAll();
        }
    }
}
