using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Linea : IValidable
    {
        public int Id { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnitarioVigente { get; set; }

        public Linea()
        {
            
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
