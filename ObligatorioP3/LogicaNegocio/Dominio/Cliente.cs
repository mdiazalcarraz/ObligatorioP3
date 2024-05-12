using LogicaNegocio.ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio.Dominio
{
    public class Cliente : IValidable
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public int Rut { get; set; }
        public Direccion Direccion { get; set; }
        public Cliente()
        {
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(RazonSocial)) { throw new DatosInvalidosException("Validaciones pendientes"); }
        }
    }
}
