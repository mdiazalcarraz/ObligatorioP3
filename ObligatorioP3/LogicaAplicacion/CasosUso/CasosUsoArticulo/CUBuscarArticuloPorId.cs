using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoArticulo
{
    public class CUBuscarArticuloPorId : ICUBuscarPorId<Articulo>
    {
        public IRepositorioArticulo Repo { get; set; }

        public CUBuscarArticuloPorId(IRepositorioArticulo repo)
        {
            Repo = repo;
        }

        public Articulo Buscar(int id)
        {
            return Repo.FindById(id);
        }
    }
}
