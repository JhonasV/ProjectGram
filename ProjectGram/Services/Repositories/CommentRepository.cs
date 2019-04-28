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
    public class CommentRepository : ICommentRepository
    {

        private readonly GramDbContext _context;
        public CommentRepository(GramDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddComment(Comment comment)
        {           
            try
            {
                _context.Comment.Add(comment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                e.ToString();
            }
          
            return false;
        }

        public  async Task<List<Comment>> GetAllComments()
        {
            List<Comment> detalles = new List<Comment>();
           

            try
            {
                detalles = await _context
                    .Comment
                    .Include(x => x.User)
                    .Include(x => x.Foto)
                    .OrderBy(x => x.Id)
                    .ToListAsync();
            }
            catch (Exception e)
            {

                e.ToString();
            }
            
            return detalles;
        }
    }
}
