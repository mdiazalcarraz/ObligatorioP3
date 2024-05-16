using LogicaNegocio.ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Variable
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public double Valor { get; set; }

        public Variable()
        { 
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new DatosInvalidosException("El nombre no puede ser nulo o vacío.");
            }

            if (Valor == 0)
            {
                throw new DatosInvalidosException("El valor no puede ser cero.");
            }

            if (Nombre == "DIASEXPRESS" && (Valor < 1 || Valor > 5))
            {
                throw new DatosInvalidosException("Para DIASEXPRESS, el valor debe estar entre 1 y 5.");
            }
        }
    }
}
