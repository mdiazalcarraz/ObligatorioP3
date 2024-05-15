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
    public class CUBorrarLinea : ICUBaja<Linea>
    {
        public IRepositorioPedido Repo { get; set; }

        public CUBorrarLinea(IRepositorioPedido repo)
        {
            Repo = repo;
        }
        public void Baja(int id)
        {
            Repo.RemoveLinea(id);
        }
    }
}
