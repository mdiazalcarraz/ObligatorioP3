using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoVariable
{
    public class CUBuscarVariablePorId : ICUBuscarPorId<Variable>
    {
        public IRepositorioVariable Repo { get; set; }

        public CUBuscarVariablePorId(IRepositorioVariable repo)
        {
            Repo = repo;
        }
        public Variable Buscar(int id)
        {
            return Repo.FindById(id);
        }
    }
}
