using DTOs;
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
    public class CUEditarUsuario : ICUModificar<DTOEditarUsuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUEditarUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }
        public void Modificar(DTOEditarUsuario DTOusuario)
        {
            Usuario usuario = MapperUsuarios.ToUsuario(DTOusuario);
            Repo.Update(usuario);
        }
    }
}
