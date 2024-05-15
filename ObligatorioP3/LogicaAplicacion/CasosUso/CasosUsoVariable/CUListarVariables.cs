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
    public class CUListarVariables : ICUListado<Variable>
    {
        public IRepositorioVariable Repo { get; set; }

        public CUListarVariables(IRepositorioVariable repo)
        {
            Repo = repo;
        }
        public List<Variable> ObtenerListado()
        {
            return Repo.FindAll();
        }
    }
}
