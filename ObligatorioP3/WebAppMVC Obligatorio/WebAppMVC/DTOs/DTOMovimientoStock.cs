using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOMovimientoStock
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }

        public string NombreArticulo { get; set; }
        public int IdTipoMovimiento { get; set; }

        public string NombreTipoMovimiento { get; set; }
        public int IdUsuario { get; set; }

        public int EmailUsuario { get; set; }
        public int CantidadUnidades { get; set; }
    }
}
