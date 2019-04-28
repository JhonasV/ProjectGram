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
    public class ArchiveRepository : IArchiveRepository
    {
        private readonly GramDbContext _context;

        public ArchiveRepository(GramDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Archive(Archive archive)
        {
            bool isArchive = false;
            try
            {
                var archived =await GetArchive(archive);
                if(archived != null)
                {
                    return await DeleteArchive(archived.Id);
                }

                await _context.Archives.AddAsync(archive);
                await _context.SaveChangesAsync();
                isArchive = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isArchive;
        }

        public async Task<List<Archive>> Archives()
        {
            List<Archive> archives = new List<Archive>();
            try
            {
                archives = await _context
                    .Archives
                    .Include(a => a.Foto)
                    .Include(a => a.ApplicationUser)
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return archives;
        }

        public async Task<bool> DeleteArchive(int id)
        {
            bool isDeleted = false;
            try
            {
                var archive = await this.GetArchive(id);
                _context.Archives.Remove(archive);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isDeleted;
        }

        public async Task<Archive> GetArchive(int id)
        {
            try
            {
                return await _context.Archives.SingleAsync(a => a.Id.Equals(id));
            }
            catch (Exception)
            {

                return new Archive();
            }
        }
        public async Task<Archive> GetArchive(Archive archive)
        {

            try
            {
                return await _context
                    .Archives
                    .Where(a => a.ApplicationUserId.Equals(archive.ApplicationUserId) && a.FotoId.Equals(archive.FotoId))
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                return new Archive();
            }
           
        }
    }
}
