using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.Models.Data;
using SIS.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIS.Controllers
{
    public class MajorController : Controller
    {
        private readonly ILogger<MajorController> _logger;
        private readonly MajorRepository _majorRepository;

        public MajorController(ILogger<MajorController> logger, MajorRepository majorRepository)
        {
            _logger = logger;
            _majorRepository = majorRepository;
        }

        public IActionResult Index()
        {
            var allMajors = _majorRepository.GetAllMajors();
            return View(allMajors);
        }

        public IActionResult Create()
        {
            var newMajor = new Major();
            return View(newMajor);
        }

        [HttpPost]
        public IActionResult Create(Major newMajor)
        {
            newMajor = _majorRepository.AddMajor(newMajor.MajorName);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var editMajor = _majorRepository.GetMajor(id);
            return View(editMajor);
        }

        [HttpPost]
        public IActionResult Edit(Major editMajor)
        {
            editMajor = _majorRepository.EditMajor(editMajor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _majorRepository.RemoveMajor(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
