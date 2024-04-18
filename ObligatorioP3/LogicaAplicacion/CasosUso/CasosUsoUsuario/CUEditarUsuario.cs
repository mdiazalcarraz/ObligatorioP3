using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUsoUsuario
{
    public class CUEditarUsuario : ICUModificar<Usuario>
    {
        public IRepositorio<Usuario> Repo { get; set; }

        public CUEditarUsuario(IRepositorio<Usuario> repo)
        {
            Repo = repo;
        }
        public void Modificar(Usuario usuario)
        {
            Repo.Update(usuario);
        }
    }
}
