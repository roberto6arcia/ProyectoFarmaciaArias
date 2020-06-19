using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using FarmaciaArias.Models;
using Microsoft.AspNetCore.Authorization;

namespace FarmaciaArias.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController: ControllerBase
    {
        private readonly ProductoService _productoService;
        public ProductoController(ProductosContext context)
        {
            _productoService = new ProductoService(context);
        }

        [Authorize(Roles="Administrador,Vendedor")]
         // GET: api/Producto
        [HttpGet]
        public IEnumerable<ProductoViewModel> Gets()
        {
            var productos = _productoService.ConsultarTodos().Select(p=> new ProductoViewModel(p));
            return productos;
        }

        [Authorize(Roles="Administrador,Vendedor")]
        // GET: api/Producto/5
        [HttpGet("{codigoP}")]
        public ActionResult<ProductoViewModel> Get(string codigoP)
        {
            var producto = _productoService.BuscarxIdentificacion(codigoP);
            if (producto == null) return NotFound();
            var productoViewModel = new ProductoViewModel(producto);
            return productoViewModel;
        }
        
        [Authorize(Roles="Administrador,Vendedor")]
        // POST: api/Producto
        [HttpPost]
        public ActionResult<ProductoViewModel> Post(ProductoInputModel productoInput)
        {
            Producto producto = MapearProducto(productoInput);
            var response = _productoService.Guardar(producto);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Producto);
        }
      
        [Authorize(Roles="Administrador,Vendedor")]
        // DELETE: api/Producto/5
        [HttpDelete("{codigoP}")]
        public ActionResult<string> Delete(string codigoP)
        {
            string mensaje = _productoService.Eliminar(codigoP);
            return Ok(mensaje);
        }
        private Producto MapearProducto(ProductoInputModel productoInput)
        {
            var producto = new Producto
            {
                CodigoP = productoInput.CodigoP,
                NombreP = productoInput.NombreP,
                LaboratorioP = productoInput.LaboratorioP,
                Fechadevencimiento = productoInput.Fechadevencimiento,
                CantidadP = productoInput.CantidadP
            };
            return producto;
        }

        [Authorize(Roles="Administrador,Vendedor")]
        // PUT: api/Producto/5
        [HttpPut("{codigoP}")]
        public ActionResult<string> Put(string codigoP, Producto producto)
        {
            var id=_productoService.BuscarxIdentificacion(producto.CodigoP);
            if(id==null){
                return BadRequest("No encontrado");
            }
            var mensaje=_productoService.Modificar(producto);
           return Ok(mensaje) ;
        }
    }
}