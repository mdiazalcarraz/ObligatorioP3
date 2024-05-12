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
    public class BuscarDireccionPorId : ICUBuscarPorId<Direccion>
    {
        public IRepositorioDireccion Repo { get; set; }

        public BuscarDireccionPorId(IRepositorioDireccion repo)
        {
            Repo = repo;
        }
        public Direccion Buscar(int id)
        {
            return Repo.FindById(id);
        }
    }
}
