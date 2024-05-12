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
    public class CUBorrarPromocion : ICUBaja<Promocion>
    {
        public IRepositorioPromocion Repo { get; set; }

        public CUBorrarPromocion(IRepositorioPromocion repo)
        {
            Repo = repo;
        }
        public void Baja(int id)
        {
            Repo.Remove(id);
        }
    }
}
