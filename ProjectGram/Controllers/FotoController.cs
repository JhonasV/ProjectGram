using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectGram.Models;
using ProjectGram.Services.Interfaces;

namespace ProjectGram.Controllers
{
    public class FotoController : Controller
    {
        private readonly IFotoRepository _fotoRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public FotoController(IFotoRepository fotoRepositorie, IUserRepository userRepository, UserManager<ApplicationUser> userManager)
        {
            _fotoRepository = fotoRepositorie;
            _userRepository = userRepository;
            _userManager = userManager;
        }
        FotoDAO dao = new FotoDAO();
        //public IActionResult Index(UserViewModel mensaje)
        //{
        //    UserViewModel model = new UserViewModel();
        //    int id = (int)HttpContext.Session.GetInt32("id");

        //    User user = new User
        //    {
        //        Id = id
        //    };
           
        //    model.User = new LoginDAO().GetUserById(id);
        //    return View("Album", model);
        //}



        public async Task<JsonResult> FotoPerfil(IFormFile formFile)
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
                var userPrincipal = this.User;
                var currentUser = await _userManager.GetUserAsync(userPrincipal);
                var user = new ApplicationUser
                {
                    Id = currentUser.Id,
                    Avatar = imagePathBd
                };

                //dao.UpdateProfilePicture(avatar);
                await _fotoRepository.UpdateProfilePicture(user);
                return Json(imagePathBd);
            }
            return Json(exito);
            
        }

        public async Task<JsonResult> EliminarFotoPerfil(int userId)
        {
            var userPrincipal = this.User;
            var currentUser = await _userManager.GetUserAsync(userPrincipal);
            var isDeleted = await _fotoRepository.EliminarFotoPerfil(currentUser.Id);
            return Json(isDeleted);
        }

        public async  Task<JsonResult> BorrarFotoAlbum(int fotoId)
        {
            //bool exito = dao.BorrarFotoAlbum(fotoId);
            var isDeleted = await _fotoRepository.BorrarFotoAlbum(fotoId);
            return Json(isDeleted);
        }
        public async Task<JsonResult> CreateAlbum(Foto foto)
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

                //exito = dao.FotoUploader(foto);
                 await _fotoRepository.FotoUploader(foto);
                
                return Json(photoPathBd);
            }
            
            return Json(exito);
        }

        public async Task<IActionResult> GetFoto(int id)
        {
            var foto = await _fotoRepository.GetFotoById(id);
            return Json(foto);
        }

        public async Task<PartialViewResult> MostrarFotos(string id)
        {
            var userPrincipal = this.User;
            var currentUser =await _userManager.GetUserAsync(userPrincipal);


            var model = new FotoViewerViewModel
            {
                Fotos = await _fotoRepository.GetAllFotosByUserId(id),
                CurrentUser = await _userRepository.GetById(currentUser.Id)
            };
            return PartialView("FotoViewer", model);
        }

        
    }
}