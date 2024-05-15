using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoPedido
{
    public class CUCalcularTotal : ICUCalcularTotal
    {
        public IRepositorioPedido Repo { get; set; }

        public CUCalcularTotal(IRepositorioPedido repo)
        {
            Repo = repo;
        }

        public void CalcularTotal(int id) 
        {
            Repo.CalcularTotal(id);
        }
    }
}
