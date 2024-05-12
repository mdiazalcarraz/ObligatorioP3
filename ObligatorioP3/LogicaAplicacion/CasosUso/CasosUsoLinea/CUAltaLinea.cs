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
    public class CUAltaLinea : ICUAlta<Linea>
    {
        public IRepositorioLinea Repo { get; set; }

        public CUAltaLinea(IRepositorioLinea repo)
        {
            Repo = repo;
        }
        public void Alta(Linea linea)
        {
            Repo.Add(linea);
        }
    }
}
