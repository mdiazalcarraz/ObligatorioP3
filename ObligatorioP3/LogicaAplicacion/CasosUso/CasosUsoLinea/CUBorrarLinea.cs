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
        public IRepositorioLinea Repo { get; set; }

        public CUBorrarLinea(IRepositorioLinea repo)
        {
            Repo = repo;
        }
        public void Baja(int id)
        {
            Repo.Remove(id);
        }
    }
}
