using Microsoft.EntityFrameworkCore;
using ProjectGram.Models;
using ProjectGram.Models.Data;
using ProjectGram.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Services.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly GramDbContext _context;

        public LikeRepository(GramDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteLike(Likes like)
        {
            bool isLikeDeleted = false;
            try
            {
                like = await GetLikeDetails(like);
                _context.Likes.Remove(like);
                await _context.SaveChangesAsync();
                isLikeDeleted = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isLikeDeleted;
        }

        public async Task<int> GetLikeCount(int fotoId)
        {
            int counter = 0;
            try
            {
                var fotos = await _context.Foto.Where(l => l.Id.Equals(fotoId))
                    .Include(l => l.Likes)
                    .FirstOrDefaultAsync();

                counter = fotos.Likes.Count();
            }
            catch (Exception)
            {

                throw;
            }
            return counter;
        }

        public async Task<Likes> GetLikeDetails(Likes like)
        {

            try
            {
                return await _context
                .Likes
                .Where(l => l.ApplicationUserId.Equals(like.ApplicationUserId) && l.FotoId.Equals(like.FotoId))
                .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                return new Likes();
            }
        }

        public async Task<bool> SaveLike(Likes like)
        {
            bool isLikeSaved = false;
            try
            {
                var likeRegistered = await GetLikeDetails(like);
                if (likeRegistered != null)
                {
                    return await DeleteLike(like);
                }

               await  _context.Likes.AddAsync(like);
               await _context.SaveChangesAsync();
               isLikeSaved = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isLikeSaved;
        }
    }
}
