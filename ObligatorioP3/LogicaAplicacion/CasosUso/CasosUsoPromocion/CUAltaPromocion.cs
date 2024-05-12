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
    public class CUAltaPromocion : ICUAlta<Promocion>
    {
        public IRepositorioPromocion Repo { get; set; }

        public CUAltaPromocion(IRepositorioPromocion repo)
        {
            Repo = repo;
        }
        public void Alta(Promocion promo)
        {
            Repo.Add(promo);
        }
    }
}
