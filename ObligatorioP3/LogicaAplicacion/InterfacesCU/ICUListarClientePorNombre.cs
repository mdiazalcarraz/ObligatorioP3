using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface ICUListarClientePorNombre
    {
        public List<Cliente> BuscarPorNombre(string nombre);
    }
}
