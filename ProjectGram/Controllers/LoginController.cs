using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectGram.Models;

namespace ProjectGram.Controllers
{
    public class LoginController : Controller
    {
        LoginDAO dao = new LoginDAO();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        //public IActionResult AddUser(User user)
        //{
        //    UserViewModel model = new UserViewModel();
          
        //    int exito = dao.AddUser(user);
        //    if (exito == 3)
        //    {
        //        model.User = null;
        //        model.Mensaje = "";
        //        model.Mensaje = "Se ha registrado exitosamente";
        //        return View("Index", model);
        //    }
        //    else if(exito == 0)
        //    {
        //        model.User = user;
        //        model.User.Password = "";
        //        model.Mensaje = "";
        //        model.Mensaje = "El Email introducido ya está en uso";
        //        return View("Registro", model);
        //    }else if(exito == 1)
        //    {
        //        model.User = user;
        //        model.User.Password = "";
        //        model.Mensaje = "";
        //        model.Mensaje = "El NickName introducido ya está en uso";
        //        return View("Registro", model);
        //    }else if(exito == 2)
        //    {
        //        model.User = user;
        //        model.User.Password = "";
        //        model.Mensaje = "";
        //        model.Mensaje = "El NickName y el Email introducido ya están en uso";
        //        return View("Registro", model);
        //    }
        //    else
        //    {
        //        model.User = user;
        //        model.User.Password = "";

        //        model.Mensaje = "Error al registrarse";
        //        return View("Registro", model);
        //    }

            
           
        //}

        //public IActionResult Autorizacion(User user)
        //{
        //    UserViewModel model = new UserViewModel();
        //    User detalles = dao.Autorizacion(user);
        //    if(detalles != null)
        //    {
        //        HttpContext.Session.SetString("email", detalles.Email);
        //        HttpContext.Session.SetInt32("id", detalles.Id);

        //        return RedirectToAction("Actividad", "Home");
        //    }
        //    else
        //    {
        //        model.User = user;
        //        model.User.Password = "";
        //        model.Mensaje = "Email y/o contraseña incorrecta";
        //        return View("Index", model);
        //    }
           
        //}

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}