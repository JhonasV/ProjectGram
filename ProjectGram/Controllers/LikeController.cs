using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectGram.Models;
using ProjectGram.Models.LikeViewModels;
using ProjectGram.Services.Interfaces;

namespace ProjectGram.Controllers
{
    public class LikeController : Controller
    {

        private readonly ILikeRepository _likeRepository;
        public LikeController(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }
        public async Task<IActionResult> SaveLike(String UserId, int FotoId)
        {
            var like = new Likes
            {
                ApplicationUserId = UserId,
                FotoId = FotoId
            };

            var isLikeAdded = await _likeRepository.SaveLike(like);
            var likeCount = await _likeRepository.GetLikeCount(FotoId);

            var saveLikeResponse = new LikeViewModel
            {
                LikeCount = likeCount,
                IsLikeAdded = isLikeAdded
            };
            return Ok(saveLikeResponse);
        }
    }
}