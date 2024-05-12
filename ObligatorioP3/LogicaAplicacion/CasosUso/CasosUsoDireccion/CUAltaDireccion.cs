using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoDireccion
{
    public class CUAltaDireccion : ICUAlta<Direccion>
    {
        public IRepositorioDireccion Repo { get; set; }

        public CUAltaDireccion(IRepositorioDireccion repo)
        {
            Repo = repo;
        }
        public void Alta(Direccion dire)
        {
            Repo.Add(dire);
        }
    }
}
