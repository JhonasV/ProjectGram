using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectGram.Models;
using ProjectGram.Services.Interfaces;

namespace ProjectGram.Controllers
{
    public class ArchiveController : Controller
    {
        private readonly IArchiveRepository _archiveRepository;

        public ArchiveController(IArchiveRepository archiveRepository)
        {
            _archiveRepository = archiveRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ArchivePicture(Archive archive)
        {
            var isArchived = await _archiveRepository.Archive(archive);

            return Json(isArchived);
        }

        [HttpGet]
        public async Task<IActionResult> GetArchives()
        {
            var archives = await _archiveRepository.Archives();

            return Json(archives);
        }
    }
}