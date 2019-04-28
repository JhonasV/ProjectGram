using Microsoft.EntityFrameworkCore;
using ProjectGram.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Models
{
    public class SocialDAO
    {

        public enum State
        {
            noFollow= 0,
            followRequested = 1,
            isfollow = 2
        }

        public int AddFollow(Follows follows)
        {
            int state = 0;
            using(GramDbContext db = new GramDbContext())
            {
                try
                {
                    Follows detalles = db
                        .Follows
                        .Where(x => x.ApplicationUserId == follows.ApplicationUserId && x.Followed.ApplicationUserId== follows.Followed.ApplicationUserId)
                        .Include(x => x.Followed)
                        .FirstOrDefault();

                    if (detalles == null)
                    {
                        db.Follows.Add(follows);             
                    }
                    else
                    {                     
                        db.Follows.Remove(detalles);
                        db.Followed.Remove(detalles.Followed);
                    }

                    db.SaveChanges();


                    state = this.IsFollow(follows.ApplicationUserId, follows.Followed.ApplicationUserId) ?  (int)State.isfollow : (int)State.noFollow;

                    
                }
                catch (Exception)
                {

                    
                }
            }
            return state;
        }

        public bool IsFollow(string  followId, string followedId)
        {
            using(GramDbContext db = new GramDbContext())
            {
                try
                {
                    Follows detalles = db
                        .Follows
                        .Where(x => x.ApplicationUserId == followId && x.Followed.ApplicationUserId == followedId)
                        .Include(x => x.Followed)
                        .FirstOrDefault();

                    if (detalles != null)
                    {
                        return true;
                    }
                   
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }

       


    }
}
