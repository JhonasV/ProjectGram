using ProjectGram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Services.Interfaces
{
    public interface ICommentRepository
    {
        Task<bool> AddComment(Comment comment);
        Task<List<Comment>> GetAllComments();
    }
}
