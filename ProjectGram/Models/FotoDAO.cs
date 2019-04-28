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

        //public void UpdateProfilePicture(User u)
        //{
            
        //    using (GramDbContext db = new GramDbContext())
        //    {
        //        try
        //        {
        //            db.Usuario.Attach(u);

        //            var entry = db.Entry(u);

        //            entry.Property(e => e.Avatar).IsModified = true;

        //            db.SaveChanges();

        //        }
        //        catch (Exception e)
        //        {

        //            e.ToString();
        //        }
        //    }
        //}

        public bool FotoUploader(Foto foto)
        {
            bool exito = false;
            using(GramDbContext db = new GramDbContext())
            {
                try
                {
                    db.Foto.Add(foto);
                    db.SaveChanges();
                    exito = true;
                }
                catch (Exception e)
                {

                    e.ToString();
                }
            }
            return exito;
        }


        //public bool EliminarFotoPerfil(int userId)
        //{
        //    bool exito = false;
        //    using (GramDbContext db = new GramDbContext())
        //    {
        //        try
        //        {
        //            User u = new User();
        //            u = db.Usuario.Where(x => x.Id == userId).FirstOrDefault();
        //            u.Avatar = "/images/avatar.jpeg";

        //            db.Usuario.Attach(u);

        //            var entry = db.Entry(u);

        //            entry.Property(e => e.Avatar).IsModified = true;

        //            db.SaveChanges();
        //            exito = true;
        //        }
        //        catch (Exception e)
        //        {

        //            e.ToString();
        //        }
        //    }
        //    return exito;
        //}

        public bool BorrarFotoAlbum(int fotoId)
        {
            bool exito = false;

            using(GramDbContext db = new GramDbContext())
            {

                try
                {
                    Foto detalles = db.Foto.Where(x => x.Id == fotoId).FirstOrDefault();
                    db.Foto.Remove(detalles);
                    db.SaveChanges();
                    exito = true;
                }
                catch (Exception e)
                {

                    e.ToString();
                }
               
            }
            return exito;
        }

        //public List<Foto> GetAllFotosByUserId(String id)
        //{
        //    List<Foto> lista = new List<Foto>();
        //    using(GramDbContext db = new GramDbContext())
        //    {
        //        try
        //        {
        //            lista = db.Foto.Where(x => x.ApplicationUserId == id).ToList();
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
                
        //    }
        //    return lista;
        //}

        //public List<Foto> GetAllFotos()
        //{
        //    List<Foto> detalles = new List<Foto>();
        //    using (GramDbContext db = new GramDbContext())
        //    {

        //        try
        //        {
        //            detalles = db.Foto.Include(x => x.User).OrderByDescending(x=> x.Fecha).ToList();
        //        }
        //        catch (Exception e)
        //        {

        //            e.ToString();
        //        }
        //    }
        //    return detalles;

        //}

        public bool AddComment(Comment comment)
        {
            using(GramDbContext db = new GramDbContext())
            {
              
                try
                {
                    db.Comment.Add(comment);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                    e.ToString();
                }
            }
            return false;
        }
        public List<Comment> GetAllComments()
        {
            List<Comment> detalles = new List<Comment>();
            using (GramDbContext db = new GramDbContext())
            {

                try
                {
                    detalles = db.Comment.Include(x=> x.User).Include(x=> x.Foto).ToList();
                }
                catch (Exception e)
                {

                    e.ToString();
                }
            }
            return detalles;

        }
    }
}
