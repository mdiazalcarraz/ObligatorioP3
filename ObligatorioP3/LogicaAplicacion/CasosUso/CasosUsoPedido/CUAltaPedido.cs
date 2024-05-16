using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUsoPedido
{
    public   class CUAltaPedido : ICUAlta<Pedido>
    {
        public IRepositorioPedido Repo { get; set; }

        public IRepositorioVariable RepositorioVariable { get; set; }
        public CUAltaPedido(IRepositorioPedido repo, IRepositorioVariable repositorioVariable)
        {
            Repo = repo;
            RepositorioVariable = repositorioVariable;
        }

  
        public void Alta(Pedido pedido)
        {
            TimeSpan diferenciaFechasPedido = pedido.FechaPrometida - pedido.FechaPedido;
            if (pedido.Tipo == "Pedido Express" && (int)diferenciaFechasPedido.TotalDays != 0)
            {
                double sumaDiasFechaPrometida = RepositorioVariable.FindByNombre("DIASEXPRESS").Valor;
                pedido.FechaPrometida = pedido.FechaPedido.AddDays(sumaDiasFechaPrometida);
            }
            Repo.Add(pedido);
         
        }
    }
}
