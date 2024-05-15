using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionesPropias;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
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
                    linea.SubTotal = linea.Articulo.Precio * linea.Cantidad * (1 - (linea.Promocion.Descuento / 100));

                    if (linea.Pedido == null) 
                    {
                        Pedido pedido = Contexto.Pedidos.Find(linea.PedidoId);
                        pedido.Lineas.Add(linea);
                        Contexto.SaveChanges();
                    } else 
                    {
                        linea.Pedido.Lineas.Add(linea);
                        Contexto.SaveChanges();
                    }
                }
                    else { throw new DatosInvalidosException("La linea no pudo ser creada"); }
                }
            }

            public List<Linea> FindAll()
            {
                return Contexto.Lineas
                .Include(l => l.Articulo)
                .Include(l => l.Promocion)
                .ToList();
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
