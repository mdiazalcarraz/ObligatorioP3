using LogicaNegocio.ExcepcionesPropias;
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
            if (string.IsNullOrEmpty(Calle))
            {
                throw new DatosInvalidosException("La calle no puede estar vacía.");
            }

            if (string.IsNullOrEmpty(Ciudad))
            {
                throw new DatosInvalidosException("La ciudad no puede estar vacía.");
            }

            if (Numero <= 0)
            {
                throw new DatosInvalidosException("El número de la dirección debe ser mayor que cero.");
            }

            if (DistanciaDepositoKM < 0)
            {
                throw new DatosInvalidosException("La distancia al depósito no puede ser negativa.");
            }
        }
    }
}
