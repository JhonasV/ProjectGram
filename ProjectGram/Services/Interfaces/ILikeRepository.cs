using ProjectGram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Services.Interfaces
{
    public interface ILikeRepository
    {
        Task<bool> SaveLike(Likes like);
        Task<bool> DeleteLike(Likes like);

        Task<Likes> GetLikeDetails(Likes like);
        Task<int> GetLikeCount(int fotoId);
    }
}
