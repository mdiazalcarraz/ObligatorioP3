using LogicaNegocio.ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Promocion : IValidable
    {
        public int Id { get; set; }

        [Display(Name = "Descuento %")]
        public int Descuento { get; set; }
        public string Nombre { get; set; }

        public Promocion()
        {
            
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new DatosInvalidosException("El nombre de la promoción no puede ser nulo o vacío.");
            }

            if (Descuento < 0)
            {
                throw new DatosInvalidosException("El descuento de la promoción no puede ser negativo.");
            }
            if (Descuento > 100)
            {
                throw new DatosInvalidosException("El descuento de la promoción no puede ser mayor que 100.");
            }
        }
    }
}
