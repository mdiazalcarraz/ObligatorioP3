using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
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

        public IRepositorioVariable RepoVariable { get; set; }

        public CUCalcularTotal(IRepositorioPedido repo, IRepositorioVariable repoVariable)
        {
            Repo = repo;
            RepoVariable = repoVariable;
        }

        public void CalcularTotal(int id) 
        {
            Pedido pedido = Repo.FindById(id);
            double sumaLineas = 0;
            double difPorTipo = 0;
            TimeSpan diferenciaFechasPedido = pedido.FechaPrometida - pedido.FechaPedido;
            int distanciaDeposito = pedido.Cliente.Direccion.DistanciaDepositoKM;

            if (pedido.Lineas != null && pedido.Lineas.Any())
            {
                sumaLineas = pedido.Lineas.Sum(linea => linea.SubTotal);
            }
            else
            {
                sumaLineas = 0;
            }
            if (pedido.Tipo == "Pedido Comun")
            {
                if (distanciaDeposito > 100)
                {
                    difPorTipo = 1.05;
                }
                else
                {
                    difPorTipo = 1;
                }
            }
            else if (pedido.Tipo == "Pedido Express")
            {
                if ((int)diferenciaFechasPedido.TotalDays == 0)
                {
                    difPorTipo = 1.15;
                }
                else
                {
                    difPorTipo = 1.10;
                }
            }
            pedido.Iva = RepoVariable.FindByNombre("IVA").Valor;
            pedido.Total = sumaLineas * difPorTipo * pedido.Iva;
            Repo.Update(pedido);
        }
    }
}
