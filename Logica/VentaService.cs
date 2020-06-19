using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Logica
{

    public class VentaDto
    {
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado{ get; set; }
        public float Total{ get; set; }
        public List<DetalleVentaDto> Detalles { get; set; } = new List<DetalleVentaDto>();
    }

    public class DetalleVentaDto
    {
        public int ProductoId { get; set; }
        public int CantidadV { get; set; }
        public float PrecioV { get; set; }
        public float TotalVenta { get; set; }
    }

    public class VentaService
    {
        private readonly ProductosContext _context;
        public VentaService(ProductosContext context)
        {
           _context = context;
        }

        public GuardarVentaResponse Guardar(Venta ventaDto)
        {
           try
            {
                 /*var ventaAux = _context.Ventas.Find(venta.CodigoV);
                if (ventaAux != null)
                {
                    return new GuardarVentaResponse($"Error de la Aplicacion: La venta ya se encuentra registrado!");
                } 

            venta.CalcularVenta();      
              
                _context.Ventas.Add(venta);
                _context.SaveChanges();
                return new GuardarVentaResponse(venta);*/ 

            foreach (var item in ventaDto.Detalles)
              {
                  var productoVendido = _context.Productos.Find(item.ProductoId);
                  /*var productoVendido = _context.Productos.FirstOrDefault(x => x.CodigoP == item.CodigoP);*/
                  if(productoVendido == null)
                  {
                       return new GuardarVentaResponse($"Error de la aplicacion: esta venta no contiene productos vendidos!");
                  }
              }

              _context.Ventas.Add(ventaDto);
              _context.SaveChanges();
              return new GuardarVentaResponse(ventaDto);

            }
            catch (Exception e)
            {
                return new GuardarVentaResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

        public List<Venta> ConsultarTodos()
        {
            
             var ventas = _context.Ventas.Include(d => d.Detalles).ToList();
            return ventas;
        }
        
        
        public Venta BuscarxIdentificacion(string codigoV)
        {
            
            Venta venta = _context.Ventas.Find(codigoV);
            return venta;
        }
    }

    public class GuardarVentaResponse 
    {
        public GuardarVentaResponse(Venta venta)
        {
            Error = false;
            Venta = venta;
        }
        public GuardarVentaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Venta Venta { get; set; }
        
    }
}