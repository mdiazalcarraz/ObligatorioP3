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
    public class CUBorrarUsuario : ICUBaja
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUBorrarUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }
        public void Baja(int id)
        {
            Repo.Remove(id);
        }
    }
}
