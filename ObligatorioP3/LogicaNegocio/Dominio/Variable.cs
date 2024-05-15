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
            // Pendiente
        }
    }
}
