using DTOs;
using LogicaAplicacion.CasosUso.CasosUsoUsuario;
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
    public class CUAltaUsuario : ICUAlta<DTOAltaUsuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUAltaUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public void Alta(DTOAltaUsuario value)
        {
            Usuario usuario = MapperUsuarios.ToUsuario(value);
            Repo.Add(usuario);
        }
    }
}
