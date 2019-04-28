using Microsoft.AspNetCore.Mvc;
using ProjectGram.Models;
using ProjectGram.Services.Interfaces;
using ProjectGram.Services.Repositories;
using System;
using System.Threading.Tasks;

namespace ProjectGram.Controllers
{
    public class CommentController : Controller
    {

        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<JsonResult> AddComment(CommentViewModel c)
        {
            var comment = new Comment
            {
                Created_at = DateTime.Now,
                FotoId = c.FotoId,
                Text = c.Text,
                ApplicationUserId = c.UserId,
            };
           
            bool isAdded = await _commentRepository.AddComment(comment);
            return Json(isAdded);
        }

        public async Task<JsonResult> GetAllComments()
        {
            return Json(await _commentRepository.GetAllComments());
        }
    }
}
