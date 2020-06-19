using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Entity
{
    public class Producto
    {
        [Key]
        public int ProductoId  { get; set; }
        public string NombreP { get; set; }
        public string LaboratorioP { get; set; }
        public DateTime Fechadevencimiento { get; set; }
        public int CantidadP { get; set; }

        public List<DetalleVenta> Ventas { get; set;} = new List<DetalleVenta>();
    }

}