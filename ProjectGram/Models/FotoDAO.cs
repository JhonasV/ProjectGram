using Microsoft.EntityFrameworkCore;
using ProjectGram.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models
{
    public class FotoDAO
    {

        public void UpdateProfilePicture(User u)
        {
            using(GramDbContext db = new GramDbContext())
            {
                try
                {
                    db.Usuario.Attach(u);

                    var entry = db.Entry(u);

                    entry.Property(e => e.Avatar).IsModified = true;

                    db.SaveChanges();
                    
                }
                catch (Exception e)
                {

                    e.ToString();
                }
            }
        }

        public string CreateAlbum(Album album)
        {
            string mensaje = "Error al crear el album";
            using(GramDbContext db = new GramDbContext())
            {
                try
                {
                    db.Album.Add(album);
                    db.SaveChanges();
                    mensaje = "Album creado satisfactoriamente";
                }
                catch (Exception e)
                {

                    e.ToString();
                }
            }
            return mensaje;
        }

        public List<Album> GetAlbumsById(User user)
        {
            List<Album> lista = new List<Album>();
            using(GramDbContext db = new GramDbContext())
            {
                try
                {
                    lista = db.Album.Where(x => x.UserId == user.Id).Include(x=> x.User).ToList();
                }
                catch (Exception e)
                {

                    e.ToString();
                }
            }
            return lista;
        }
    }
}
