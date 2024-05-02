using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUsoArticulo
{
    public class CUListaArticuloOrden : ICUListado<Articulo>
    {
        public IRepositorioArticulo RepoArticulos { get; set; }

        public CUListaArticuloOrden(IRepositorioArticulo repo)
        {
            RepoArticulos = repo;
        }
        public List<Articulo> ObtenerListado()
        {
            return RepoArticulos.FindAll();
        }
    }
}
