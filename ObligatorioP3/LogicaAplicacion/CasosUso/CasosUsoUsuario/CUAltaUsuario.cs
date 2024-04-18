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
    public class CUAltaUsuario : ICUAlta<Usuario>
    {
        public IRepositorio<Usuario> Repo { get; set; }

        public CUAltaUsuario(IRepositorio<Usuario> repo)
        {
            Repo = repo;
        }

        public void Alta(Usuario usuario)
        {
            Repo.Add(usuario);
        }
    }
}
