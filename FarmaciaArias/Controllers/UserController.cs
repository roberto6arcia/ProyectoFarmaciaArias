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
using FarmaciaArias.Hubs;
using Microsoft.AspNetCore.SignalR;


namespace FarmaciaArias.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly UserService _userService;
        private readonly IHubContext<SignalHub> _hubContext;
        public UserController(ProductosContext context, IHubContext<SignalHub> hubContext)
        {
            _userService = new UserService(context);
            _hubContext = hubContext;
        }

        [Authorize(Roles="Administrador")]
         // GET: api/User
        [HttpGet]
        public IEnumerable<UserViewModel> Gets()
        {
            var users = _userService.ConsultarTodos().Select(p=> new UserViewModel(p));
            return users;
        }

        [Authorize(Roles="Administrador")]
        // GET: api/User/5
        [HttpGet("{idUser}")]
        public ActionResult<UserViewModel> Get(string idUser)
        {
            var user = _userService.BuscarxIdentificacion(idUser);
            if (user == null) return NotFound();
            var userViewModel = new UserViewModel(user);
            return userViewModel;
        }
        
        [Authorize(Roles="Administrador")]
        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserViewModel>> PostAsync(UserInputModel userInput)
        {
            User user = MapearUser(userInput);
            var response = _userService.Guardar(user);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            var userViewModel = new UserViewModel(user);
            await _hubContext.Clients.All.SendAsync("UserRegistrado", userViewModel);
            return Ok(response.User);
        }
      
        [Authorize(Roles="Administrador")]
        // DELETE: api/User/5
        [HttpDelete("{idUser}")]
        public ActionResult<string> Delete(string idUser)
        {
            string mensaje = _userService.Eliminar(idUser);
            return Ok(mensaje);
        }

        private User MapearUser(UserInputModel userInput)
        {
            var user = new User
            {
                UserName = userInput.UserName,
                Password = userInput.Password,
                Estado = userInput.Estado,
                FirstName = userInput.FirstName,
                LastName = userInput.LastName,
                IdUser = userInput.IdUser,
                Email = userInput.Email,
                MobilePhone = userInput.MobilePhone,
                Role = userInput.Role,
            };
            return user;
        }

        [Authorize(Roles="Administrador")]
        // PUT: api/User/5
        [HttpPut("{idUser}")]
        public ActionResult<string> Put(string idUser, User user)
        {
            throw new NotImplementedException();
        }
    }
    
}