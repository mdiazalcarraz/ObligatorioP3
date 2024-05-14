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
        public class RepositorioLineaEF : IRepositorioLinea
        {
            public LibreriaContext Contexto { get; set; }

            public RepositorioLineaEF(LibreriaContext contexto)
            {
                Contexto = contexto;
            }

            public void Add(Linea linea)
            {
                if (linea != null)
                {
                    linea.Validar();
                    if (FindById(linea.Id) == null)
                    {
                    //linea.PrecioUnitarioVigente = linea.Articulo.Precio;

                    Contexto.Lineas.Add(linea);
                    Contexto.SaveChanges();
                    }
                    else { throw new DatosInvalidosException("La linea ya fue creado"); }
                }
            }

            public List<Linea> FindAll()
            {
                return Contexto.Lineas.ToList();
            }

            public void Remove(int id)
            {
                Linea aBorrar = Contexto.Lineas.Find(id);
                if (aBorrar != null)
                {
                    Contexto.Lineas.Remove(aBorrar);
                    Contexto.SaveChanges();
                }
            }

            public void Update(Linea linea)
            {
                linea.Validar();
                Contexto.Update(linea);
                Contexto.SaveChanges();
            }

            public Linea FindById(int id)
            {
                return Contexto.Lineas
                     .Where(Linea => Linea.Id == id)
                     .SingleOrDefault();
            }
        }
    }
