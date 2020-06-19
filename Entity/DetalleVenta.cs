using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Entity
{
    public class DetalleVenta
    {
        [Key]
        public int DetalleVentaId { get; set; }
        public int CantidadV { get; set; }
        public float PrecioV { get; set; }
        public float TotalVenta { get; set; }
        public void CalcularVenta() 
        {
            TotalVenta = PrecioV*CantidadV;
        }

        public string CodigoP { get; set; }
        public Producto Producto { get; set; }

        public int VentaId { get; set; }
        public Venta Venta { get; set; }
        
        
    }
}