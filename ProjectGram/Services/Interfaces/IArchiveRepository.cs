using ProjectGram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGram.Services.Interfaces
{
    public interface IArchiveRepository
    {
        Task<bool> Archive(Archive archive);
        Task<List<Archive>> Archives();

        Task<bool> DeleteArchive(int id);

        Task<Archive> GetArchive(int id);
    }
}
