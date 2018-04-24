using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectGram.Models;

namespace ProjectGram.Controllers
{
    public class HomeController : Controller
    {
        LoginDAO dao = new LoginDAO();
        public IActionResult Index()
        {
            int id = (int)HttpContext.Session.GetInt32("id");
            UserViewModel model = new UserViewModel();
            model.User = dao.GetUserById(id);

            return View(model);
        }
        

        public IActionResult Album()
        {
            return RedirectToAction("Index", "Foto");
        }

   
    }
}
