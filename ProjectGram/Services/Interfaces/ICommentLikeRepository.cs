using ProjectGram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Services.Interfaces
{
    public interface ICommentLikeRepository
    {
        Task<bool> SaveCommentLike(CommentLikes commentLike);

        Task<bool> RemoveCommentLike(int commentLikeId);
        Task<bool> RemoveCommentLike(CommentLikes commentLike);
        Task<CommentLikes> GetCommentLikes(int commentLikeId);
        Task<CommentLikes> GetCommentLikes(CommentLikes commentLike);
        Task<List<CommentLikes>> GetCommentLikes();
    }
}
