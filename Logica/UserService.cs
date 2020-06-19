using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Logica
{
    public class UserService
    {
        private readonly ProductosContext _context;
        public UserService(ProductosContext context)=> _context = context;

        public User Validate(string userName, string password) 
        {
            return _context.Users.FirstOrDefault(t => t.UserName == userName && t.Password == password && t.Estado == "AC");
        }

        public GuardarUserResponse Guardar(User user)
        {
            try
            {
                var userAux = _context.Users.Find(user.IdUser);
                if (userAux != null)
                {
                    return new GuardarUserResponse($"Error de la Aplicacion: El user ya se encuentra registrado!");
                }               
                _context.Users.Add(user);
                _context.SaveChanges();
                return new GuardarUserResponse(user);
            }
            catch (Exception e)
            {
                return new GuardarUserResponse($"Error de la Aplicacion: {e.Message}");
            }
        }
        public List<User> ConsultarTodos()
        {         
            List<User> users = _context.Users.ToList();
            return users;
        }
        public string Eliminar(string idUser)
        {
            try
            {       
                var user = _context.Users.Find(idUser);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    return ($"El registro {user.UserName} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {idUser} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
        }
        public string Modificar(User userNuevo)
        {
            try
            {
                var userViejo = _context.Users.Find(userNuevo.IdUser);
                if (userViejo != null)
                {
                    _context.Users.Update(userNuevo);
                    return ($"El registro {userNuevo.UserName} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {userNuevo.IdUser} no se encuentra registrado.");
                }
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación: {e.Message}";
            }

        }
        public User BuscarxIdentificacion(string idUser)
        {    
            User user = _context.Users.Find(idUser);
            return user;
        }
    }

    public class GuardarUserResponse 
    {
        public GuardarUserResponse(User user)
        {
            Error = false;
            User = user;
        }
        public GuardarUserResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public User User { get; set; }
    }
    
}