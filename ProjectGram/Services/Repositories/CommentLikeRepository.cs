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
    public class CommentLikeRepository :ICommentLikeRepository
    {
        private readonly GramDbContext _context;

        public CommentLikeRepository(GramDbContext context)
        {
            _context = context;
        }

        public async Task<CommentLikes> GetCommentLikes(int commentLikeId)
        {
            var commentLike = new CommentLikes();
            try
            {
                commentLike = await _context
                    .CommentLikes
                    .Where(c => c.Id.Equals(commentLikeId))
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return commentLike;
        }

        public async Task<List<CommentLikes>> GetCommentLikes()
        {
            var commentLikes = new List<CommentLikes>();
            try
            {
                commentLikes = await _context
                    .CommentLikes
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return commentLikes;
        }

        public async Task<CommentLikes> GetCommentLikes(CommentLikes comment)
        {
            var commentLike = new CommentLikes();
            try
            {
                commentLike = await _context
                    .CommentLikes
                    .Where(c => c.CommentId.Equals(comment.CommentId) && c.ApplicationUserId.Equals(comment.ApplicationUserId))
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return commentLike;
        }

        public async Task<bool> RemoveCommentLike(int commentLikeId)
        {
            var isDeleted = false;
            try
            {
                var commentLike = await this.GetCommentLikes(commentLikeId);
                _context.CommentLikes.Remove(commentLike);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isDeleted;
        }

        public async Task<bool> RemoveCommentLike(CommentLikes commentLike)
        {
            var isDeleted = false;
            try
            {
                _context.CommentLikes.Remove(commentLike);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isDeleted;
        }

        public async Task<bool> SaveCommentLike(CommentLikes commentLike)
        {
            bool isCommentLikeAdded = false;

            try
            {
                var isCommentLikeExists = await this.GetCommentLikes(commentLike);
                if(isCommentLikeExists != null)
                {
                    return await this.RemoveCommentLike(isCommentLikeExists);
                }

                await _context.CommentLikes.AddAsync(commentLike);
                await _context.SaveChangesAsync();
                isCommentLikeAdded = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isCommentLikeAdded;
        }
    }
}
