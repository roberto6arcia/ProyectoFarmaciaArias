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
        public string CodigoP { get; set; }
        public int CantidadV { get; set; }
        public float PrecioV { get; set; }
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
                   detalleVenta.CodigoP=item.CodigoP;
                   detalleVenta.CantidadV=item.CantidadV;
                   detalleVenta.PrecioV=item.PrecioV;                 
                   detalleVenta.TotalVenta=item.TotalVenta;
                   DetallesView.Add(detalleVenta);
             }
        }
        public int VentaId { get; set; }
        public List<DetalleVentaViewModel> DetallesView { get; set; } = new List<DetalleVentaViewModel>();
    }

    public class DetalleVentaViewModel
    {
        public string CodigoP { get; set; }
        public int CantidadV { get; set; }
        public float PrecioV { get; set; }
        public float TotalVenta { get; set; }
    }
}