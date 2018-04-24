using Microsoft.EntityFrameworkCore;
using ProjectGram.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models
{
    public class LoginDAO
    {

        public int AddUser(User user)
        {
            /*0 = correo en uso, 1 = nickname en uso, 2 = correo y nickname en uso, 3 = datos correctos*/
            int exito = 0;

            using(GramDbContext db = new GramDbContext())
            {
                try
                {
                    /*Validamos que el Email no este en uso*/
                    var detalles = db.Usuario.Where(x => x.Email == user.Email).FirstOrDefault();
                    var detalles2 = db.Usuario.Where(x => x.NickName == user.NickName).FirstOrDefault();
                    if (detalles == null && detalles2 == null)
                    {
                        user.Avatar = "/images/avatar.jpeg";
                        db.Usuario.Add(user);
                        db.SaveChanges();
                        exito = 3;
                    } else if (detalles != null)
                    {
                        exito = 0;
                    } else if (detalles2 != null)
                    {
                        exito = 1;
                    } else if (detalles != null && detalles2 != null)
                    {
                        exito = 2;
                    }

                    
                   
                }
                catch (Exception e)
                {

                    e.ToString();
                }
            }
            return exito;
        }

        public User Autorizacion(User user)
        {
            User detalles = new User();
            using(GramDbContext db = new GramDbContext())
            {
                try
                {
                    detalles = db.Usuario.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

                }
                catch (Exception e)
                {

                    e.ToString();
                }
            }
            return detalles;
        }
        public User GetUserById(int id)
        {
            User detalles = new User();
            using(GramDbContext db = new GramDbContext())
            {
                
                try
                {
                    detalles = db.Usuario.Where(x => x.Id == id).Include(x=> x.Foto).FirstOrDefault();
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
