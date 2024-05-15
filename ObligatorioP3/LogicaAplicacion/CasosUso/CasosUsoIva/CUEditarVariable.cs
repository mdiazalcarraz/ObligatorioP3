using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoIva
{
    public class CUEditarVariable : ICUModificar<Variables>
    {
        public void Modificar(Variables vari)
        {
            Repo.Update(vari);
        }
    }
}
