using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectGram.Models;
using ProjectGram.Services.Interfaces;

namespace ProjectGram.Controllers
{
    public class CommentLikeController : Controller
    {
        private readonly ICommentLikeRepository _commentLikeRepository;
        public CommentLikeController(ICommentLikeRepository commentLikeRepository)
        {
            _commentLikeRepository = commentLikeRepository;
        }
        public async Task<IActionResult> SaveCommentLike(CommentLikes commentLikes)
        {

            var isAdded = await _commentLikeRepository.SaveCommentLike(commentLikes);
            return Json(isAdded);
        }


    }
}