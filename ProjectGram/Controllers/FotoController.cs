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
            model.listaAlbumes = dao.GetAlbumsById(user);
            model.User = new LoginDAO().GetUserById(id);
            return View("Album", model);
        }



        public IActionResult FotoPerfil(IFormFile formFile)
        {
            string photoName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpeg";

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
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreateAlbum(Album album, IFormFile formFile)
        {
            AlbumViewModel model = new AlbumViewModel();
            string photoName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpeg";
            string photoPath = "wwwroot/images/" + photoName;
            if(formFile != null)
            {
                using(var stream = new FileStream(photoPath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }

                string photoPathBd = "/images/" + photoName;
                album.Portada = photoPathBd;
                album.UserId = (int)HttpContext.Session.GetInt32("id");
                album.Fecha = DateTime.Now;
                model.Mensaje = dao.CreateAlbum(album);

            }
            
            return RedirectToAction("Index", model);
        }
    }
}