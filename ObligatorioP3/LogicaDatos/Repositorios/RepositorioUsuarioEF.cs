using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionesPropias;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioUsuarioEF(LibreriaContext contexto)
        {
            Contexto = contexto;
        }

        public Usuario Login(string email, string password)
        {
            Usuario buscado = Contexto.Usuarios
                .Where(usu => usu.Email == email && usu.Contrasenia == password)
                .FirstOrDefault();

            return buscado;
        }

        public void Add(Usuario nuevo)
        {
            if (nuevo != null)
            {
                nuevo.Validar();
                if (FindByEmail(nuevo.Email) == null)
                {
                    Contexto.Usuarios.Add(nuevo);
                    Contexto.SaveChanges();
                }
                else { throw new DatosInvalidosException("El mail ya esta en uso"); }
            }
        }

        public List<Usuario> FindAll()
        {
            return Contexto.Usuarios.ToList();
        }

        public Usuario FindByEmail(string email)
        {
            return Contexto.Usuarios
                   .Where(Usuario => Usuario.Email.ToLower() == email.ToLower())
                   .SingleOrDefault();
        }

        public void Update(Usuario obj)
        {
            obj.Validar();
            Contexto.Update(obj);
            Contexto.SaveChanges();
        }

        public Usuario FindById(int id)
        {
            return Contexto.Usuarios     
                 .Where(usuario => usuario.Id == id)
                 .SingleOrDefault();
        }

        public void Remove(int id)
        {
            Usuario aBorrar = Contexto.Usuarios.Find(id);
            if (aBorrar != null)
            {
                Contexto.Usuarios.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }
    }
}
