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
    public class RepositorioArticulosEF : IRepositorioArticulo
    {

        public LibreriaContext Contexto { get; set; }

        public RepositorioArticulosEF(LibreriaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Articulo art)
        {
            if (art != null)
            {
                art.Validar();
                if(FindById(art.Codigo) == null)
                {
                    Contexto.Articulos.Add(art);
                    Contexto.SaveChanges();
                }
                else { throw new DatosInvalidosException("El Codigo ya esta en uso"); }
            }
        }

        public List<Articulo> FindAll()
        {
            return Contexto.Articulos.ToList();
        }

        public void Remove(int id)
        {
            Articulo aBorrar = Contexto.Articulos.Find(id);
            if (aBorrar != null)
            {
                Contexto.Articulos.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(Articulo articulo)
        {
            articulo.Validar();
            Contexto.Update(articulo);
            Contexto.SaveChanges();
        }

        public Articulo FindById(int Id)
        {
            return Contexto.Articulos
                 .Where(Articulo => Articulo.Id == Id)
                 .SingleOrDefault();
        }
    }
}
