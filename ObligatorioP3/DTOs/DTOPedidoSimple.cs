using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOPedidoSimple
    {
        public string Estado { get; set; }
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaPrometida { get; set; }
        public virtual Cliente Cliente { get; set; }
        public double Total { get; set; }
    }
}
