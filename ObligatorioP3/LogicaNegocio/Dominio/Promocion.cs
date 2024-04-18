using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Promocion : IValidable
    {
        public int Id { get; set; }
        public int Descuento { get; set; }

        public Promocion()
        {
            
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
