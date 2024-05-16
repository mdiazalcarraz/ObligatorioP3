using LogicaNegocio.Dominio;
using LogicaNegocio.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperUsuarios
    {
        public static Usuario ToUsuario(DTOAltaUsuario dto)
        {
            return new Usuario()
            {
                Administrador = dto.Administrador,
                Email = dto.Email,
                NombreYApellido = new NombreUsuario(dto.NombreYApellido),
                Contrasenia = dto.Contrasenia,
                ContraseniaEncriptada = dto.ContraseniaEncriptada
            };
        }
        public static Usuario ToUsuario(DTOEditarUsuario dto)
        {
            return new Usuario()
            {
                Administrador = dto.Administrador,
                Email = dto.Email,
                NombreYApellido = new NombreUsuario(dto.NombreYApellido),
                Contrasenia = dto.Contrasenia,
                ContraseniaEncriptada = dto.ContraseniaEncriptada,
                Id = dto.Id,
            };
        }
    }    
    
}
