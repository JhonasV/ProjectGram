using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ProjectGram.Infraestructure;
using ProjectGram.Models;
using ProjectGram.Models.Data;
using ProjectGram.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Services.Repositories
{
    public class FotoRepositories : IFotoRepository
    {
        private IHubContext<SignalRServer> _hubContext;
        private readonly GramDbContext _context;
        public FotoRepositories(GramDbContext context, IHubContext<SignalRServer> _hubContext)
        {
            _context = context;
            this._hubContext = _hubContext;
        }

        public async Task<bool> BorrarFotoAlbum(int fotoId)
        {
            bool success = false;
            
            try
            {
                Foto detalles =await _context.Foto.Where(x => x.Id == fotoId)
                                .Include(f => f.Likes)
                                .Include(f => f.Comments)
                                .Include(f => f.Archives)
                                .FirstOrDefaultAsync();

                _context.Foto.Remove(detalles);
                await _context.SaveChangesAsync();
                success = true;
            }
            catch (Exception)
            {
            }
          
            return success;
        }

        public void DeleteProfilePictureFile(string avatar)
        {
            try
            {
                if (File.Exists(avatar))
                {
                    File.Delete(avatar);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> EliminarFotoPerfil(string userId)
        {
            bool success = false;
           
            try
            {
                var u = new ApplicationUser();
                u = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
                DeleteProfilePictureFile(u.Avatar);
                u.Avatar = "/images/avatar.jpeg";

                _context.Users.Attach(u);

                var entry = _context.Entry(u);

                entry.Property(e => e.Avatar).IsModified = true;

                await _context.SaveChangesAsync();

                
                success = true;
            }
            catch (Exception e)
            {

                e.ToString();
            }
            
            return success;
        }

        public async Task<bool> FotoUploader(Models.Foto foto)
        {
            bool success = false;
           
            try
            {
                _context
                    .Foto
                    .Add(foto);

                await _context
                    .SaveChangesAsync();
                success = true;
            }
            catch (Exception e)
            {

                e.ToString();
            }
            
            return success;

        }

        public async Task<List<Foto>> GetAllFotos()
        {
            List<Foto> detalles = new List<Foto>();
           
                try
                {
                    detalles = await _context
                    .Foto
                    .Include(x => x.ApplicationUser)
                    .Include(x=> x.Comments)
                    .Include(x => x.Likes)
                    .Include(x=>x.Archives)
                    .OrderByDescending(x => x.Fecha)
                    .ToListAsync();

                detalles.ForEach(d =>
                {
                    d.Comments.ForEach(async c =>
                    {
                        c.CommentLikes = await _context
                        .CommentLikes
                        .Where(cm => cm.CommentId.Equals(c.Id))
                        .ToListAsync();
                    });
                });
                }
                catch (Exception e)
                {

                    e.ToString();
                }
           
            return detalles;
        }

        public async Task<List<Foto>> GetAllFotosByUserId(string id)
        {
            List<Foto> lista = new List<Foto>();
          
                try
                {
                    lista = await _context
                    .Foto.Where(x => x.ApplicationUserId == id)
                    .Include(x => x.Comments)
                    .Include(x => x.Likes)
                    .ToListAsync();

                }
                catch (Exception)
                {

                    throw;
                }

            
            return lista;
        }

        public async Task<Foto> GetFotoById(int id)
        {
            var foto = new Foto();
            try
            {
                var list = await this.GetAllFotos();
                list.ForEach(f =>
                {
                    f.Comments.ForEach(async c =>
                    {
                        if(c.ApplicationUser == null)
                        {
                            c.ApplicationUser = await _context
                            .Users.Where(u => u.Id.Equals(c.ApplicationUserId))
                            .FirstOrDefaultAsync();
                        }
                    });
                });
                foto = list
                    .Where(e => e.Id.Equals(id))
                    .FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return foto;
        }

        public async Task UpdateProfilePicture(ApplicationUser u)
        {
                try
                {
                    _context.Users.Attach(u);

                    var entry = _context.Entry(u);

                    entry.Property(e => e.Avatar).IsModified = true;

                    await _context.SaveChangesAsync();

                }
                catch (Exception e)
                {

                    e.ToString();
                }
            
        }
    }
}
