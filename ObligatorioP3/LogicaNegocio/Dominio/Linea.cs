using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Linea : IValidable
    {
        public virtual int Id { get; set; }

        public virtual int ArticuloId { get; set; }
        [ForeignKey("ArticuloId")]
        public virtual Articulo Articulo { get; set; }

        public virtual int Cantidad { get; set; }
        public virtual int PedidoId { get; set; }
        [ForeignKey("PedidoId")]
        public virtual Pedido Pedido { get; set; }
        public virtual int PromocionId { get; set; }

        public virtual Promocion Promocion { get; set; }

        public virtual double SubTotal { get; set; }

        public Linea()
        {

        }

        public void Validar()
        {
            //
        }
    }
}
