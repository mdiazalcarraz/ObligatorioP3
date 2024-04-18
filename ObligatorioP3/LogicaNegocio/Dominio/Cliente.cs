using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Cliente : IValidable
    {
        public string RazonSocial { get; set; }
        public int Rut { get; set; }
        public Direccion Direccion { get; set; }

        public Cliente()
        {
            
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
