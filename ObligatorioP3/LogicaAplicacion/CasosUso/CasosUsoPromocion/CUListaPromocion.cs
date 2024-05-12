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
    public class CUListaPromocion : ICUListado<Promocion>
    {
        public IRepositorioPromocion Repo { get; set; }

        public CUListaPromocion(IRepositorioPromocion repo)
        {
            Repo = repo;
        }
        public List<Promocion> ObtenerListado()
        {
            return Repo.FindAll();
        }
    }
}
