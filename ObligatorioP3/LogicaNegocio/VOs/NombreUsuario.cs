using LogicaNegocio.ExcepcionesPropias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.VOs
{
    [Owned]
    public class NombreUsuario
    {
        public string NombreValue { get; init; }

        public NombreUsuario(string nombreValue) 
        {
            NombreValue = nombreValue;
            Validar();
        }
        private NombreUsuario() { }
        private void Validar()
        {
            if (!IsValidName(NombreValue))
            {
                throw new DatosInvalidosException("El formato del nombre y apellido no es válido.");
            }
        }
        private bool IsValidName(string name)
        {
            return Regex.IsMatch(name,
                @"^(?![\s'-.])[\p{L}\s'-]*(?<![\s'-.])$");
        }

        public override bool Equals(object? obj)
        {
            if (obj is NombreUsuario nombre)
            {
                return nombre.NombreValue == this.NombreValue;
            }
            return false;
        }
    }
}
