using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectGram.Models;

namespace ProjectGram.Controllers
{
    public class SocialController : Controller
    {
        SocialDAO dao = new SocialDAO();
        public JsonResult Follow(Follows follows)
        {
            var successCode = dao.AddFollow(follows);
            return Json(successCode);
        }
    }
}