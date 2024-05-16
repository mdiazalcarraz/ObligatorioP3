using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOEditarUsuario
    {
        public bool Administrador { get; set; }
        public string Email { get; set; }
        public string NombreYApellido { get; set; }
        public string Contrasenia { get; set; }
        public string ContraseniaEncriptada { get; set; }

        public int Id { get; set; }
    }
}
