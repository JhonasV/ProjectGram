using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectGram.Models;
using ProjectGram.Models.Data;
using ProjectGram.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectGram.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GramDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserRepository(GramDbContext  context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetCurrentUser(ClaimsPrincipal claimsPrincipal)
        {
            var currentUser = new ApplicationUser();
            try
            {
                currentUser = await _userManager.GetUserAsync(claimsPrincipal);
            }
            catch (Exception)
            {

                throw;
            }
            return currentUser;
        }

        public async Task<List<ApplicationUser>> Get()
        {

            try
            {
                return await _context.Users
                    .Include(x => x.Foto)
                    .Include(x => x.Follows)
                    .Include(x => x.FollowedList)
                    .Include(x => x.Archives)
                    .ToListAsync();
            }
            catch (Exception)
            {

                return new List<ApplicationUser>();
            }
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            var detalles = new ApplicationUser();

            try
            {
                var users = await this.Get();
                detalles = users
                    .Where(u => u.Id.Equals(id))
                    .FirstOrDefault();
            }
            catch (Exception e)
            {

                e.ToString();
            }
            
            return detalles;
        }

        public async Task<ApplicationUser> GetByUserName(string userName)
        {
            var user = new ApplicationUser();
            try
            {
                var users = await this.Get();
                user = users
                    .Where(u => u.UserName.Equals(userName))
                    .FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return user;
        }
    }
}
