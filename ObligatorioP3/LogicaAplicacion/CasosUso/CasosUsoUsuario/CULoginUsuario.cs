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
    public class CULoginUsuario : ICULoginUsuario
    {
        public IRepositorioUsuario Repo { get; set; }

        public CULoginUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }
        public Usuario Login(string mail, string pass)
        {
            return Repo.Login(mail, pass);
        }

    }
}
