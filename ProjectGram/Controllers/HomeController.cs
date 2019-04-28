using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGram.Models;
using ProjectGram.Models.Data;
using ProjectGram.Models.HomeViewModels;
using ProjectGram.Services.Interfaces;

namespace ProjectGram.Controllers
{
    public class HomeController : Controller
    {
        LoginDAO dao = new LoginDAO();
        private readonly IFotoRepository _fotoRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly GramDbContext _context;
        public HomeController(
            IFotoRepository fotoRepository,
            ICommentRepository commentRepository,
            IUserRepository userRepository,
            UserManager<ApplicationUser> userManager,
            GramDbContext context
            )
        {
            _fotoRepository = fotoRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _userManager = userManager;
            _context = context;

        }

        public async Task<ApplicationUser> GetCurrentUser()
        {
            var claimsPrincipal = this.User;
            var currentUser = await _userRepository.GetCurrentUser(claimsPrincipal);
            return currentUser;
        }
        public async Task<IActionResult> Index()
        {
            //int id = (int)HttpContext.Session.GetInt32("id");
            //var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            UserViewModel model = new UserViewModel();
           var currentUser = await GetCurrentUser();
            model.ApplicationUser = await _userRepository.GetById(currentUser.Id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Account(string UserName)
        {
            //int id = (int)HttpContext.Session.GetInt32("id");
            UserViewModel model = new UserViewModel();

            var currentUser = await GetCurrentUser();
            model.ApplicationUser = await _userRepository.GetById(currentUser.Id);

            model.ApplcationUserSecond = await _userRepository.GetByUserName(UserName);
            model.isFollow = new SocialDAO().IsFollow(model.ApplicationUser.Id,model.ApplcationUserSecond.Id);
            if (model.ApplicationUser.Id.Equals(model.ApplcationUserSecond.Id))
            {
                return RedirectToAction("Index");
            }

            return View("Perfil", model);
        }
        #region "UserManager"
        //public async Task<ApplicationUser> GetUser(string nickName)
        //{
        //    var user = new ApplicationUser();
        //    try
        //    {
        //        user =await _context.Users.Where(u => u.UserName.Equals(nickName))
        //            .Include(u => u.FollowedList)
        //            .Include(u => u.Follows)
        //            .Include(u => u.Foto)
        //            .FirstOrDefaultAsync();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return user;
        //}
        public async Task<ApplicationUser> GetUser()
        {
            var user = new ApplicationUser();
            try
            {
                var userPrincipal = this.User;
                var currentUser = await _userManager.GetUserAsync(userPrincipal);
                user =await _context.Users.Where(e => e.Id.Equals(currentUser.Id))
                    .Include(l => l.FollowedList)
                    .Include(f => f.Follows)
                    .Include(f => f.Foto)
                    .Include(a => a.Archives)
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return user;
        }

        #endregion
        [Authorize]
        public IActionResult Album()
        {
            return RedirectToAction("Index", "Foto");
        }

        [Authorize]
        public async Task<IActionResult> Actividad()
        {
            UserViewModel model = new UserViewModel();
            //model.User = dao.GetUserById(id);
            var currentUser = await GetCurrentUser();
            model.ApplicationUser = await _userRepository.GetById(currentUser.Id);
            return View(model);
        }

        public async Task<PartialViewResult> ActividadPartial()
        {
            var currentUser = await GetCurrentUser();
            var model = new ActividadPartialViewModel
            {
                Fotos = await _fotoRepository.GetAllFotos(),
                ApplicationUser = await _userRepository.GetById(currentUser.Id)
            };
           
            return PartialView(model);
        }
    }
}
