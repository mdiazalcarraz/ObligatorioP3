using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Usuario : IValidable
    {
		public int Id { get; set; }

		public bool Administrador { get; set; }
        public string Email { get; set; }
        public string NombreYApellido { get; set; }
        public string Contrasenia { get; set; }
        public Usuario()
        {
            
        }

        public void Validar()
        {
          // Pendiente
        }
    }
}
