using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUsoPedido
{
    public class CUAnularPedido : ICUAnularPedido
    {
        public IRepositorioPedido Repo { get; set; }

        public CUAnularPedido(IRepositorioPedido repo)
        {
            Repo = repo;
        }
        public void AnularPedido(int ID)
        {
            Repo.AnularPedido(ID);
        }
    }
}
