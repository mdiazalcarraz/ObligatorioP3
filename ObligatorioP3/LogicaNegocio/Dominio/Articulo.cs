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
        public int Codigo { get; set; }
        public string Descripcion   { get; set; }
        public int Precio   { get; set; }
        public int Stock   { get; set; }

        public Articulo()
        {
            
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre) || Nombre.Length < 10 || Nombre.Length > 200) { throw new DatosInvalidosException("El nombre no esta entre 10 y 200 caracteres o es vacio"); }
        }
    }
}
