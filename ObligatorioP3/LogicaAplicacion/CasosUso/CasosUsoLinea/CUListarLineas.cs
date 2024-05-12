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
    public class CUListarLineas : ICUListado<Linea>
    {
        public IRepositorioLinea Repo { get; set; }

        public CUListarLineas(IRepositorioLinea repo)
        {
            Repo = repo;
        }
        public List<Linea> ObtenerListado()
        {
            return Repo.FindAll();
        }
    }
}
