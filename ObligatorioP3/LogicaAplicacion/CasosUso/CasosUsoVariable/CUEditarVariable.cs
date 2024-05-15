using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoIva
{
    public class CUEditarVariable : ICUModificar<Variable>
    {
        public IRepositorioVariable Repo { get; set; }

        public CUEditarVariable(IRepositorioVariable repo)
        {
            Repo = repo;
        }
        public void Modificar(Variable vari)
        {
            Repo.Update(vari);
        }
    }
}
