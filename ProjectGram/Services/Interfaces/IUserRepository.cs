using ProjectGram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectGram.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> Get();
        Task<ApplicationUser> GetById(string id);
        Task<ApplicationUser> GetByUserName(string userName);
        Task<ApplicationUser> GetCurrentUser(ClaimsPrincipal claimsPrincipal);

    }
}
