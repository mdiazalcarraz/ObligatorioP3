﻿using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio.Dominio
{
    public class Pedido : IValidable
    {
        public int? Iva {  get; set; }
        public string? Estado { get; set; }
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }

        public DateTime FechaPrometida { get; set; }
        public int ClienteId { get; set; } 
        public virtual Cliente? Cliente { get; set; }
        public virtual List<Linea>? Lineas { get; set; }
        public int? Total { get; set; }
        public string Tipo { get; set; }   

        public Pedido()
        {
            Iva = 0;
            Estado = "En proceso";
            FechaPedido = DateTime.Now;
            Lineas = new List<Linea>();
            Total = 0;
        }

        public void Validar()
        {
            //implementar
        }
    }
    
}
