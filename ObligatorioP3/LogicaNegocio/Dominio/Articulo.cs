using LogicaNegocio.ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Articulo : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public long Codigo { get; set; }
        public string Descripcion   { get; set; }
        public int Precio   { get; set; }
        public int Stock   { get; set; }

        public Articulo()
        {
            
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Descripcion) || Descripcion.Length < 5)
            {
                throw new DatosInvalidosException("La descripción debe tener al menos 5 caracteres.");
            }
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new DatosInvalidosException("El nombre no puede ser vacío.");
            }
            if (Codigo <= 0 || Codigo.ToString().Length != 13)
            {
                throw new DatosInvalidosException("El código debe ser un número positivo de exactamente 13 dígitos significativos.");
            }
            if (Precio <= 0)
            {
                throw new DatosInvalidosException("El precio debe ser un número positivo.");
            }
            if (Stock < 0)
            {
                throw new DatosInvalidosException("El stock no puede ser negativo.");
            }
        }
    }
}
