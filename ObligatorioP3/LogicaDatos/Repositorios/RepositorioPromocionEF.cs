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
    public class RepositorioPromocionEF : IRepositorioPromocion
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioPromocionEF(LibreriaContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Promocion promo)
        {
            if (promo != null)
            {
                promo.Validar();
                if (FindById(promo.Id) == null)
                {
                    Contexto.Promociones.Add(promo);
                    Contexto.SaveChanges();
                }
                else { throw new DatosInvalidosException("La promocion ya fue creado"); }
            }
        }

        public List<Promocion> FindAll()
        {
            return Contexto.Promociones.ToList();
        }

        public void Remove(int id)
        {
            Promocion aBorrar = Contexto.Promociones.Find(id);
            if (aBorrar != null)
            {
                Contexto.Promociones.Remove(aBorrar);
                Contexto.SaveChanges();
            }
        }

        public void Update(Promocion promo)
        {
            promo.Validar();
            Contexto.Update(promo);
            Contexto.SaveChanges();
        }

        public Promocion FindById(int id)
        {
            return Contexto.Promociones
                 .Where(promo => promo.Id == id)
                 .SingleOrDefault();
        }
    }
}
