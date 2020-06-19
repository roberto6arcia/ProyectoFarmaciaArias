using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaArias.Models
{
    public class VentaInputModel
    {
        [Required(ErrorMessage="La Fecha de venta es requerido")]
        public DateTime Fechadeventa { get; set; }
        [Required(ErrorMessage="El estado es requerido")]
        public string Estado { get; set; }
        [Required]
        public List<DetalleVentaInputModel> Detalles { get; set; } = new List<DetalleVentaInputModel>();
        public float Total { get; set; }

    }

    public class DetalleVentaInputModel
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public float TotalVenta { get; set; }
    }


    public class VentaViewModel : VentaInputModel
    {
        public VentaViewModel()
        {
        }
        public VentaViewModel(Venta venta)
        {
            VentaId = venta.VentaId;     
            Fechadeventa = venta.Fechadeventa;
            Estado = venta.Estado;
            Total = venta.Total;

            foreach (var item in venta.Detalles)
            {    
                   var detalleVenta= new DetalleVentaViewModel();
                   detalleVenta.ProductoId=item.ProductoId;
                   detalleVenta.Cantidad=item.Cantidad;
                   detalleVenta.Precio=item.Precio;                 
                   detalleVenta.TotalVenta=item.TotalVenta;
                   DetallesView.Add(detalleVenta);
             }
        }
        public int VentaId { get; set; }
        public List<DetalleVentaViewModel> DetallesView { get; set; } = new List<DetalleVentaViewModel>();
    }

    public class DetalleVentaViewModel
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public float TotalVenta { get; set; }
    }
}