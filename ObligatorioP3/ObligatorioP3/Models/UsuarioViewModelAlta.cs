using LogicaNegocio.VOs;
using System.ComponentModel.DataAnnotations;

namespace ObligatorioP3.Models
{
    public class UsuarioViewModelAlta
    {
        public bool Administrador { get; set; }
        public string Email { get; set; }

        [Display(Name = "Nombre y Apellido")]
        public string NombreYApellido { get; set; }

        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }
    }
}
