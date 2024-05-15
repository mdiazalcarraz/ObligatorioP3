using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Direccion : IValidable
    {
		public int Id { get; set; }
		public string Calle { get; set; }
        public string Ciudad { get; set; }
        public int Numero { get; set; }
        public int DistanciaDepositoKM { get; set; }
        public int? ClienteId { get; set; }

        public Direccion()
        {
            
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
