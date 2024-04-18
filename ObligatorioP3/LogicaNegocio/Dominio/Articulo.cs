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
        public string Codigo { get; set; }
        public string Descripcion   { get; set; }
        public int Precio   { get; set; }
        public int Stock   { get; set; }

        public Articulo()
        {
            
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
