using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaArias.Models
{
    public class ProductoInputModel
    {
        [Required]
        public int ProductoId { get; set; }
        [Required(ErrorMessage="El Nombre es requerido")]
        public string NombreP { get; set; }
        [Required(ErrorMessage="El Laboratorio es requerido")]
        public string LaboratorioP { get; set; }
        [Required(ErrorMessage="La Fecha de vencimiento es requerido")]
        public DateTime Fechadevencimiento { get; set; }
        [Required]
        [Range(1,99, ErrorMessage ="La cantidad debe ser entre 1 y 99")]
        public int CantidadP { get; set; }
              
    }

    public class ProductoViewModel : ProductoInputModel
    {
        public ProductoViewModel()
        {
        }
        public ProductoViewModel(Producto producto)
        {
            ProductoId = producto.ProductoId;
            NombreP = producto.NombreP;
            LaboratorioP = producto.LaboratorioP;
            Fechadevencimiento = producto.Fechadevencimiento;
            CantidadP = producto.CantidadP;
        }
    }
}