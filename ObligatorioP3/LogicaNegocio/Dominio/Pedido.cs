using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Pedido : IValidable
    {
        public static int? Iva = null;

        public static string Estado = "En proceso";
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public Cliente? Cliente { get; set; }
        public List<Linea>? Lineas { get; set; }
        public int Total { get; set; }
        public string Tipo { get; set; }   

        public Pedido()
        {
            
            
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
    
}
