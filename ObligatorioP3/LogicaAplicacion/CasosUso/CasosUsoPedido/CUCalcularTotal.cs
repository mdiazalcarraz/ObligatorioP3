using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoPedido
{
    public class CUCalcularTotal
    {
        public IRepositorioPedido Repo { get; set; }

        public CUCalcularTotal(IRepositorioPedido repo)
        {
            Repo = repo;
        }

        public int CalcularTotal() 
        {
            return Repo.CalcularTotal();
        }
    }
}
