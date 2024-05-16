using LogicaNegocio.VOs;

namespace DTOs
{
    public class DTOAltaUsuario
    {
        public bool Administrador { get; set; }
        public string Email { get; set; }
        public string NombreYApellido { get; set; }
        public string Contrasenia { get; set; }
        public string ContraseniaEncriptada { get; set; }
    }
}
