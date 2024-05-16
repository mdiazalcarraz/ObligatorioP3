using LogicaNegocio.ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Usuario : IValidable
    {
		public int Id { get; set; }

		public bool Administrador { get; set; }
        public string Email { get; set; }
        public NombreUsuario NombreYApellido { get; set; }
        public string Contrasenia { get; set; }
        public string ContraseniaEncriptada { get; set; }
        public Usuario()
        {
            
        }

        // Validaciones hechas con ayuda de ChatGPT:

        //Prompt : Como podemos validar que strings ingresados tengan las siguientes caracteristicas: contraseña que tenga un largo mínimo de 6
        //caracteres, al menos una letra mayúscula, una minúscula, un dígito y un carácter de puntuación: punto, punto y
        //coma, coma, signo de admiración de cierre.

        public void Validar()
        {
            if (!IsValidEmail(Email))
            {
                throw new DatosInvalidosException("El formato del email no es válido.");
            }
            if (string.IsNullOrEmpty(Contrasenia) || Contrasenia.Length < 6 ||
                !HasRequiredCharacters(Contrasenia))
            {
                throw new DatosInvalidosException("La contraseña no cumple con los requisitos mínimos.");
            }
        }
        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email,
                @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }
        private bool HasRequiredCharacters(string password)
        {
            return Regex.IsMatch(password,
                @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.,;!])[A-Za-z\d.,;!]{6,}$");
        }
    }
}
