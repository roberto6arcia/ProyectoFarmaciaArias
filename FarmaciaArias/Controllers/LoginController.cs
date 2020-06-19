using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FarmaciaArias.Config;
using FarmaciaArias.Models;

using System.Linq;
using System.Collections.Generic;

namespace FarmaciaArias.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        ProductosContext _context;
        UserService _userService;
        JwtService _jwtService;
        public LoginController(ProductosContext context, IOptions<AppSetting> appSettings)
        {
            _context = context;
            //var admin = _context.Users.Find("admin");
            var admin = _context.Users.FirstOrDefault(x => x.UserName == "admin");
            if (admin == null) 
            {
                _context.Users.Add(new User() 
                { 
                    //UserId = 1,
                    UserName="admin", 
                    Password="admin", 
                    Estado="AC", 
                    FirstName="Adminitrador", 
                    LastName="Adminitrador",
                    Email="admin@gmail.com",
                    MobilePhone="31800000000",
                    Role="Administrador"}
                );
                var registrosGuardados=_context.SaveChanges();
            }
            _userService = new UserService(context);
            _jwtService = new JwtService(appSettings);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginInputModel model)
        {
            var user = _userService.Validate(model.UserName, model.Password);
            if (user == null) return BadRequest("UserName or password is incorrect");
            var response= _jwtService.GenerateToken(user);
            return Ok(response);
        }
    }
    
}