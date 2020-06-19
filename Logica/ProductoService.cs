using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Logica
{
    public class ProductoService
    {
        private readonly ProductosContext _context;
        public ProductoService(ProductosContext context)
        {
           _context = context;
        }
        public GuardarProductoResponse Guardar(Producto producto)
        {
            try
            {
                /*var productoAux = _context.Productos.Find(producto.CodigoP);
                if (productoAux != null)
                {
                    return new GuardarProductoResponse($"Error de la Aplicacion: El producto ya se encuentra registrado!");
                }*/               
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return new GuardarProductoResponse(producto);
            }
            catch (Exception e)
            {
                return new GuardarProductoResponse($"Error de la Aplicacion: {e.Message}");
            }
        }

        public List<Producto> ConsultarTodos()
        {         
            List<Producto> productos = _context.Productos.ToList();
            return productos;
        }

        public string Eliminar(string codigoP)
        {
            try
            {       
                var producto = _context.Productos.Find(codigoP);
                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    return ($"El registro {producto.NombreP} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {codigoP} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
        }
        public string Modificar(Producto productoNuevo)
        {
            try
            {
                var productoViejo = _context.Productos.Find(productoNuevo.ProductoId );
                if (productoViejo != null)
                {
                    _context.Productos.Update(productoNuevo);
                    return ($"El registro {productoNuevo.NombreP} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {productoNuevo.ProductoId } no se encuentra registrado.");
                }
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación: {e.Message}";
            }

        }

        public Producto BuscarxIdentificacion(string codigoP)
        {    
            Producto producto = _context.Productos.Find(codigoP);
            return producto;
        }
    }

    public class GuardarProductoResponse 
    {
        public GuardarProductoResponse(Producto producto)
        {
            Error = false;
            Producto = producto;
        }
        public GuardarProductoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Producto Producto { get; set; }
    }
}