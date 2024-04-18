using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuario
    {
        public static List<Usuario> Usuarios { get; set; } = new List<Usuario>();

        public void Add(Usuario usuario)
        {
            if (usuario != null)
            {
                usuario.Validar();
                Usuarios.Add(usuario);
            }
        }

        public List<Usuario> FindAll()
        {
            return Usuarios;
        }

        public void Remove(string email)
        {
            Usuario aBorrar = FindByEmail(email);

            if (aBorrar != null)
            {
                Usuarios.Remove(aBorrar);
            }
            else
            {
                throw new Exception("El usuario con el email " + email + " no existe");
            }
        }

        public Usuario FindByEmail(string email)
        {
            return Usuarios
                    .Where(Usuario => Usuario.Email == email)
                    .SingleOrDefault();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }

}
