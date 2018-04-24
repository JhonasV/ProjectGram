using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectGram.Models;

namespace ProjectGram.Controllers
{
    public class FotoController : Controller
    {
        FotoDAO dao = new FotoDAO();
        public IActionResult Index(UserViewModel mensaje)
        {
            UserViewModel model = new UserViewModel();
            int id = (int)HttpContext.Session.GetInt32("id");

            User user = new User
            {
                Id = id
            };
           
            model.User = new LoginDAO().GetUserById(id);
            return View("Album", model);
        }



        public JsonResult FotoPerfil(IFormFile formFile)
        {
            string photoName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpeg";
            bool exito = false;
            var imagePath = "wwwroot/images/" + photoName;
            if(formFile != null)
            {
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }

                var imagePathBd = "/images/" + photoName;
                User avatar = new User
                {
                    Id = (int)HttpContext.Session.GetInt32("id"),
                    Avatar = imagePathBd
                };

                dao.UpdateProfilePicture(avatar);
                return Json(imagePathBd);
            }
            return Json(exito);
            
        }

        public JsonResult EliminarFotoPerfil(int userId)
        {
            bool exito = dao.EliminarFotoPerfil(userId);
            return Json(exito);
        }

        public JsonResult BorrarFotoAlbum(int fotoId)
        {
            bool exito = dao.BorrarFotoAlbum(fotoId);

            return Json(exito);
        }
        public JsonResult CreateAlbum(Foto foto)
        {
           
            string photoName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpeg";
            string photoPath = "wwwroot/images/" + photoName;
            bool exito = false;
            if(foto.Img != null && foto.Descripcion != null)
            {
                using(var stream = new FileStream(photoPath, FileMode.Create))
                {
                    foto.Img.CopyTo(stream);
                }

                string photoPathBd = "/images/" + photoName;
                foto.Ruta = photoPathBd;
                
                exito = dao.FotoUploader(foto);
                return Json(exito);
            }
            
            return Json(exito);
        }

        public PartialViewResult MostrarFotos(int id)
        {
            return PartialView("FotoViewer", dao.GetAllFotos(id));
        }


    }
}