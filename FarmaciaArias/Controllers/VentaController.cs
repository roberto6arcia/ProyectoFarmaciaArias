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

using System.Net;

namespace FarmaciaArias.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController: ControllerBase
    {
         private readonly VentaService _ventaService;
        public VentaController(ProductosContext context)
        {
            _ventaService = new VentaService(context);
        }

        [Authorize(Roles="Administrador,Vendedor")]
         // GET: api/Venta
        [HttpGet]
        public IEnumerable<VentaViewModel> Gets()
        {
            var ventas = _ventaService.ConsultarTodos().Select(p=> new VentaViewModel(p));
            return ventas;
        }

        [Authorize(Roles="Administrador,Vendedor")]
        // GET: api/Venta/5
        [HttpGet("{codigoV}")]
        public ActionResult<VentaViewModel> Get(string codigoV)
        {
            var venta = _ventaService.BuscarxIdentificacion(codigoV);
            if (venta == null) return NotFound();
            var ventaViewModel = new VentaViewModel(venta);
            return ventaViewModel;
        }
        
        [Authorize(Roles="Administrador,Vendedor")]
        // POST: api/Venta
        [HttpPost]
        public ActionResult<VentaViewModel> Post(VentaInputModel ventaInput)
        {
            Venta venta = MapearVenta(ventaInput);
            var response = _ventaService.Guardar(venta);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Venta);
        }

        private Venta MapearVenta(VentaInputModel ventaInput)
        {
            var venta = new Venta
            {
                Fechadeventa = ventaInput.Fechadeventa,
                Estado = ventaInput.Estado,
                Total = ventaInput.Total,
            };

            foreach (var item in ventaInput.Detalles)
            {    
                   var detalleVenta= new DetalleVenta();
                   detalleVenta.ProductoId=item.ProductoId;
                   detalleVenta.Cantidad=item.Cantidad;
                   detalleVenta.Precio=item.Precio;                  
                   detalleVenta.CalcularVenta() ;
                   venta.Detalles.Add(detalleVenta);
             }
            return venta;
        }

        [Authorize(Roles="Administrador,Vendedor")]
        // PUT: api/Venta/5
        [HttpPut("{codigoV}")]
        public ActionResult<string> Put(string codigoV, Venta venta)
        {
            throw new NotImplementedException();
        }
    }
        
}