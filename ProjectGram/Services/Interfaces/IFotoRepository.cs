using ProjectGram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Services.Interfaces
{
    public interface IFotoRepository
    {
        Task<List<Foto>> GetAllFotos();
        Task<List<Foto>> GetAllFotosByUserId(string id);
        Task<Foto> GetFotoById(int id);
        Task<bool> BorrarFotoAlbum(int fotoId);
        Task<bool> EliminarFotoPerfil(string userId);
        void DeleteProfilePictureFile(string avatar);
        Task<bool> FotoUploader(Foto foto);
        Task UpdateProfilePicture(ApplicationUser u);

    }
}
