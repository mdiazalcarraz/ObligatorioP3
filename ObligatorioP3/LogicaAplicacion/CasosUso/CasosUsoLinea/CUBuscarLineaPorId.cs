using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoLinea
{
    public class CUBuscarLineaPorId : ICUBuscarPorId<Linea>
    {
        public IRepositorioPedido Repo { get; set; }

        public CUBuscarLineaPorId(IRepositorioPedido repo)
        {
            Repo = repo;
        }
        public Linea Buscar(int id)
        {
            return Repo.FindByIdLinea(id);
        }
    }
}
