using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOMovimientoStock
    {
        public int Id { get; set; }

        [Display(Name = "Articulo")]
        public int IdArticulo { get; set; }
        public string NombreArticulo { get; set; }

        [Display(Name = "Tipo de Movimiento")]
        public int IdTipoMovimiento { get; set; }
        public string NombreTipoMovimiento { get; set; }
        public int IdUsuario { get; set; }

        [Display(Name = "Email de Usuario")]
        public string EmailUsuario { get; set; }
        public int CantidadUnidades { get; set; }
    }
}
