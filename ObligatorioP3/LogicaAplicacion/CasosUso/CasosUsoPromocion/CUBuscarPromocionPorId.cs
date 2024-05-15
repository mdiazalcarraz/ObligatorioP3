using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoPromocion
{
    public class CUBuscarPromocionPorId : ICUBuscarPorId<Promocion>
    {
        public IRepositorioPromocion Repo { get; set; }

        public CUBuscarPromocionPorId(IRepositorioPromocion repo)
        {
            Repo = repo;
        }
        public Promocion Buscar(int id)
        {
            return Repo.FindById(id);
        }
    }
}
